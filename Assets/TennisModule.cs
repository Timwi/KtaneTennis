using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using KModkit;
using Tennis;
using UnityEngine;
using Rnd = UnityEngine.Random;

/// <summary>
/// On the Subject of Tennis
/// Created by Timwi
/// </summary>
public partial class TennisModule : MonoBehaviour
{
    public KMBombInfo Bomb;
    public KMBombModule Module;
    public KMAudio Audio;

    public Texture[] Courts;
    public Texture[] Trophies;
    public Texture[] TennisBalls;
    public MeshRenderer Main;
    public MeshRenderer TennisBall;
    public GameObject ScoresGroup;
    public GameObject GameScore1;   // 30–15
    public GameObject GameScore2;   // Deuce/Advantage
    public GameObject SetScoresGroup;
    public GameObject TrophyGroup;
    public GameObject TieBreak;

    public TextMesh Player1Display;
    public TextMesh Player2Display;

    public KMSelectable[] BtnsSetScores1;
    public KMSelectable[] BtnsSetScores2;
    public KMSelectable BtnGameScore1;
    public KMSelectable BtnGameScore2;
    public KMSelectable BtnGameScore3;
    public KMSelectable BtnRacket;
    public KMSelectable BtnPlayer1;
    public KMSelectable BtnPlayer2;

    private static int _moduleIdCounter = 1;
    private int _moduleId;
    private Tournament _tournament;
    private bool _isMensPlay;
    private string _player1;
    private string _player2;
    private GameStateScores _initialState;
    private GameStateScores _currentState;
    private GameState _solutionState;
    private bool _isSolved = false;

    void Start()
    {
        var _rnd = new System.Random(Rnd.Range(0, int.MaxValue));

        _moduleId = _moduleIdCounter++;
        _tournament = (Tournament) _rnd.Next(0, 3);
        _isMensPlay = _rnd.Next(0, 2) != 0;

        var players = Data.All[_tournament][_isMensPlay].Keys.ToArray();
        _player1 = players[_rnd.Next(0, players.Length)];
        var opponents = Data.All[_tournament][_isMensPlay][_player1].Keys.ToArray();
        _player2 = opponents[_rnd.Next(0, opponents.Length)];
        var player1Goodness = calcGoodness(Data.All[_tournament][_isMensPlay], _player1, _player2);
        if (_rnd.Next(0, 2) == 0)
        {
            var t = _player1;
            _player1 = _player2;
            _player2 = t;
            player1Goodness = 1 - player1Goodness;
        }

        Debug.LogFormat(@"[Tennis #{0}] Welcome to the {1}’s singles final here at {2}.", _moduleId, _isMensPlay ? "men" : "women",
            _tournament == Tournament.FrenchOpenRolandGarros ? "the French Open Roland-Garros" :
            _tournament == Tournament.USOpenFlushingMeadows ? "the US Open at Flushing Meadows" :
            _tournament == Tournament.Wimbledon ? "The Championships, Wimbledon" : "some ghost tournament that nobody realizes exists");

        Debug.LogFormat(@"[Tennis #{0}] Playing: {1} vs. {2}.", _moduleId, _player1, _player2);
        Player1Display.text = _player1;
        Player2Display.text = _player2;

        var max = _isMensPlay ? _rnd.Next(55, 95) : _rnd.Next(35, 55);
        tryAgain:
        var initialState = GameState.GetInitial(_isMensPlay, _tournament);
        for (int i = 0; i < max; i++)
        {
            var initialStateScore = (GameStateScores) initialState;
            initialState = initialStateScore.PlayerScores((_rnd.NextDouble() > player1Goodness) ^ initialStateScore.IsPlayer1Serving);
            if (initialState is GameStateVictory)
            {
                max /= 2;
                player1Goodness = (player1Goodness + .5) / 2;
                goto tryAgain;
            }
        }
        _initialState = ((GameStateScores) initialState).Normalize();

        _solutionState = _currentState = _initialState;
        _currentState.Setup(this);

        var serial = Bomb.GetSerialNumber();
        var binary = new List<bool>();
        for (int i = 0; i < serial.Length; i++)
        {
            var ch = serial[i];
            int num;
            if (ch >= '0' && ch <= '9')
                num = ch - '0';
            else
                num = 6 + ch - 'A';
            binary.AddRange(Enumerable.Range(0, 5).Select(j => ((1 << (4 - j)) & num) != 0));
        }
        var logLines = new List<string>();
        for (int i = 0; i < binary.Count && !(_solutionState is GameStateVictory); i++)
        {
            if (i % 5 == 0)
                logLines.Add(string.Format(@"[Tennis #{0}] {1} = {2}", _moduleId, serial[i / 5], string.Join("", binary.Skip(i).Take(5).Select(b => b ? "1" : "0").ToArray())));
            _solutionState = ((GameStateScores) _solutionState).PlayerScores(binary[i]);
            logLines.Add(string.Format(@"[Tennis #{0}] {1} → {2}", _moduleId, binary[i] ? "1=srv" : "0=opp", _solutionState));
        }
        if (_solutionState is GameStateScores && (((GameStateScores) _solutionState).Player1Score > 99 || ((GameStateScores) _solutionState).Player2Score > 99))
            goto tryAgain;
        if (_solutionState is GameStateVictory && (((GameStateVictory) _solutionState).Player1Wins ? _player1 : _player2) == "Serena Williams")
            goto tryAgain;

        Debug.LogFormat(@"[Tennis #{0}] Initial score: {1}", _moduleId, initialState);
        foreach (var line in logLines)
            Debug.Log(line);

        for (int i = 0; i < 5; i++)
        {
            SetDelegateForSetScore(BtnsSetScores1[i], i, true);
            SetDelegateForSetScore(BtnsSetScores2[i], i, false);
        }
        SetDelegate(BtnGameScore1, st => st.ClickGameScore(true), st => st.LongClickGameScore());
        SetDelegate(BtnGameScore2, st => st.ClickGameScore(false), st => st.LongClickGameScore());
        SetDelegate(BtnGameScore3, st => st.ClickGameScore2(), st => st);
        SetDelegate(BtnRacket, st => st.ClickRacket(), st => _initialState);
        BtnPlayer1.OnInteract = MakeWinnerDelegate(BtnPlayer1, true);
        BtnPlayer2.OnInteract = MakeWinnerDelegate(BtnPlayer2, false);
    }

    private double calcGoodness(Dictionary<string, Dictionary<string, int>> dictionary, string player1, string player2)
    {
        // There’s no real purpose in this, but the idea here is that if Player 1 has beaten Player 2 more times than not,
        // Player 1 should actually be better and thus the initial score on the module should be skewed towards one
        // in which Player 1 is in the lead. So we’re calculating a crude probability of winning any particular rally and
        // use that probability to generate the module’s initial score.
        var player1Won = dictionary.ContainsKey(player1) && dictionary[player1].ContainsKey(player2) ? dictionary[player1][player2] : 0;
        var player2Won = dictionary.ContainsKey(player2) && dictionary[player2].ContainsKey(player1) ? dictionary[player2][player1] : 0;
        return (player1Won + 1) / (double) (player1Won + player2Won + 2);
    }

    private KMSelectable.OnInteractHandler MakeWinnerDelegate(KMSelectable btn, bool isPlayer1)
    {
        return delegate
        {
            Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, btn.transform);
            btn.AddInteractionPunch();
            if (_isSolved)
                return false;

            if (_solutionState is GameStateVictory && ((GameStateVictory) _solutionState).Player1Wins == isPlayer1)
            {
                Debug.LogFormat(@"[Tennis #{0}] Module solved.", _moduleId);
                _solutionState.Setup(this);
                Module.HandlePass();
                Audio.PlaySoundAtTransform(string.Format("Play{0}", Rnd.Range(1, 3)), transform);
                StartCoroutine(delayedCheer());
                TennisBall.material.mainTexture = TennisBalls[1];
                _isSolved = true;
            }
            else
            {
                Debug.LogFormat(@"[Tennis #{0}] You clicked {1}, which is incorrect.", _moduleId, isPlayer1 ? _player1 : _player2);
                Module.HandleStrike();
                TennisBall.material.mainTexture = TennisBalls[2];
                StartCoroutine(resetTennisBall());
            }
            return false;
        };
    }

    private IEnumerator delayedCheer()
    {
        yield return new WaitForSeconds(.5f);
        Audio.PlaySoundAtTransform("Crowd cheer", transform);
    }

    private IEnumerator resetTennisBall()
    {
        yield return new WaitForSeconds(1f);
        TennisBall.material.mainTexture = TennisBalls[1];
    }

    private void SetDelegateForSetScore(KMSelectable btn, int set, bool isPlayer1)
    {
        SetDelegate(btn, st => st.ClickSetScore(set, isPlayer1), st => st.LongClickSetScore(set));
    }

    private void SetDelegate(KMSelectable btn, Func<GameStateScores, GameStateScores> shortClick, Func<GameStateScores, GameStateScores> longClick)
    {
        Coroutine coroutine = null;

        btn.OnInteract = delegate
        {
            Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, btn.transform);
            btn.AddInteractionPunch();
            if (_isSolved)
                return false;

            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = StartCoroutine(initiateLongPress(btn, longClick, () => { var isActive = coroutine != null; coroutine = null; return isActive; }));
            return false;
        };

        btn.OnInteractEnded = delegate
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
                executeStateChange(shortClick);
            }
        };
    }

    private void executeStateChange(Func<GameStateScores, GameStateScores> stateChange)
    {
        _currentState = stateChange(_currentState);
        _currentState.Setup(this);
        if (_currentState.IsCorrect(_solutionState))
        {
            Debug.LogFormat(@"[Tennis #{0}] Module solved.", _moduleId);
            Module.HandlePass();
            TennisBall.material.mainTexture = TennisBalls[1];
            Audio.PlaySoundAtTransform(string.Format("Play{0}", Rnd.Range(1, 3)), transform);
            _isSolved = true;
        }
    }

    private IEnumerator initiateLongPress(KMSelectable btn, Func<GameStateScores, GameStateScores> longClick, Func<bool> stillActive)
    {
        yield return new WaitForSeconds(.5f);
        if (stillActive())
            executeStateChange(longClick);
    }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use “!{0} command command command”. Valid commands are: “P1”/“P2” = player names up top. “R” = tennis racket. “S1”/“S2” = game score boxes for player 1/player 2 (only valid when deuce/advantage is not in effect). “S” = deuce/advantage box. “S11”/“S12” = first set score box (player 1/player 2), “S21”/“S22” = second set, etc. Prefix a button name with “L” for a long press, e.g. “LR” = long press on the racket.";
#pragma warning restore 414

    sealed class TPCommand
    {
        public KMSelectable Button { get; private set; }
        public bool LongPress { get; private set; }
        public TPCommand(KMSelectable btn, bool longPress) { Button = btn; LongPress = longPress; }
    }
    IEnumerator ProcessTwitchCommand(string command)
    {
        var list = new List<TPCommand>();
        foreach (var pieceRaw in command.ToLowerInvariant().Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
        {
            var piece = pieceRaw;
            var longPress = false;
            if (piece.StartsWith("l"))
            {
                longPress = true;
                piece = piece.Substring(1);
            }
            KMSelectable button;
            switch (piece)
            {
                case "p1": button = BtnPlayer1; longPress = false; break;
                case "p2": button = BtnPlayer2; longPress = false; break;
                case "r": button = BtnRacket; break;
                case "s1": button = BtnGameScore1; break;
                case "s2": button = BtnGameScore2; break;
                case "s": button = BtnGameScore3; break;
                default:
                    var m = Regex.Match(piece, @"^s([1-5])([12])$");
                    if (!m.Success)
                        yield break;
                    button = (m.Groups[2].Value == "1" ? BtnsSetScores1 : BtnsSetScores2)[int.Parse(m.Groups[1].Value) - 1];
                    break;
            }
            list.Add(new TPCommand(button, longPress));
        }

        foreach (var cmd in list)
        {
            yield return null;
            yield return cmd.Button;
            yield return new WaitForSeconds(cmd.LongPress ? 1f : .1f);
            yield return cmd.Button;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        var v = _solutionState as GameStateVictory;
        if (v != null)
        {
            (v.Player1Wins ? BtnPlayer1 : BtnPlayer2).OnInteract();
            yield return new WaitForSeconds(.1f);
        }
        else
        {
            BtnRacket.OnInteract();
            yield return new WaitForSeconds(1f);
            BtnRacket.OnInteractEnded();

            var scores = _solutionState as GameStateScores;
            for (var i = 0; i < scores.Sets.Length; i++)
            {
                while (_currentState.Sets.Length <= i || _currentState.Sets[i].Player1Score < scores.Sets[i].Player1Score)
                {
                    BtnsSetScores1[i].OnInteract();
                    yield return new WaitForSeconds(.1f);
                    BtnsSetScores1[i].OnInteractEnded();
                }
                while (_currentState.Sets[i].Player2Score < scores.Sets[i].Player2Score)
                {
                    BtnsSetScores2[i].OnInteract();
                    yield return new WaitForSeconds(.1f);
                    BtnsSetScores2[i].OnInteractEnded();
                }
            }

            if (scores.IsTieBreak)
            {
                while (!_currentState.IsTieBreak)
                {
                    BtnRacket.OnInteract();
                    yield return new WaitForSeconds(.1f);
                    BtnRacket.OnInteractEnded();
                }
                while (_currentState.Player1Score < scores.Player1Score)
                {
                    BtnGameScore1.OnInteract();
                    yield return new WaitForSeconds(.1f);
                    BtnGameScore1.OnInteractEnded();
                }
                while (_currentState.Player2Score < scores.Player2Score)
                {
                    BtnGameScore2.OnInteract();
                    yield return new WaitForSeconds(.1f);
                    BtnGameScore2.OnInteractEnded();
                }
            }
            // In normal play: [0,2] = 0–30; or [3,3] = 40–40; [4,3] = advantage Player 1; [4,4] = deuce
            else if (scores.Player1Score == 4 || scores.Player2Score == 4)
            {
                while ((_currentState.Player1Score != 4 && _currentState.Player2Score != 4) || _currentState.IsTieBreak)
                {
                    BtnRacket.OnInteract();
                    yield return new WaitForSeconds(.1f);
                    BtnRacket.OnInteractEnded();
                }
                while (_currentState.Player1Score != scores.Player1Score || _currentState.Player2Score != scores.Player2Score)
                {
                    BtnGameScore3.OnInteract();
                    yield return new WaitForSeconds(.1f);
                    BtnGameScore3.OnInteractEnded();
                }
            }
            else
            {
                while (_currentState.Player1Score == 4 || _currentState.Player2Score == 4 || _currentState.IsTieBreak)
                {
                    BtnRacket.OnInteract();
                    yield return new WaitForSeconds(.1f);
                    BtnRacket.OnInteractEnded();
                }
                while (_currentState.Player1Score != scores.Player1Score)
                {
                    BtnGameScore1.OnInteract();
                    yield return new WaitForSeconds(.1f);
                    BtnGameScore1.OnInteractEnded();
                }
                while (_currentState.Player2Score != scores.Player2Score)
                {
                    BtnGameScore2.OnInteract();
                    yield return new WaitForSeconds(.1f);
                    BtnGameScore2.OnInteractEnded();
                }
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public MeshRenderer Main;
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

        var max = _isMensPlay ? _rnd.Next(110, 150) : _rnd.Next(65, 80);
        tryAgain:
        var initialState = GameState.GetInitial(_isMensPlay, _tournament);
        for (int i = 0; i < max; i++)
        {
            initialState = ((GameStateScores) initialState).PlayerScores(_rnd.NextDouble() <= player1Goodness);
            if (initialState is GameStateVictory)
            {
                max /= 2;
                player1Goodness = (player1Goodness + .5) / 2;
                goto tryAgain;
            }
        }
        _initialState = ((GameStateScores) initialState).Normalize();
        Debug.LogFormat(@"[Tennis #{0}] Initial score: {1}", _moduleId, initialState);

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
        for (int i = 0; i < binary.Count && !(_solutionState is GameStateVictory); i++)
        {
            _solutionState = ((GameStateScores) _solutionState).PlayerScores(binary[i]);
            Debug.LogFormat(@"[Tennis #{0}] {1} → {2}", _moduleId, binary[i] ? "1=srv" : "0=opp", _solutionState);
        }

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
                Module.HandlePass();
                _isSolved = true;
            }
            else
            {
                Debug.LogFormat(@"[Tennis #{0}] You clicked {1}, which is incorrect.", _moduleId, isPlayer1 ? _player1 : _player2);
                Module.HandleStrike();
            }
            return false;
        };
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
            _isSolved = true;
        }
    }

    private IEnumerator initiateLongPress(KMSelectable btn, Func<GameStateScores, GameStateScores> longClick, Func<bool> stillActive)
    {
        yield return new WaitForSeconds(.5f);
        if (stillActive())
            executeStateChange(longClick);
    }
}

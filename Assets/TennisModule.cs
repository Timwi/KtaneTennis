using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KModkit;
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
    private TennisPlayer _player1;
    private TennisPlayer _player2;
    private GameStateScores _initialState;
    private GameStateScores _currentState;
    private GameState _solutionState;
    private bool _isSolved = false;

    void Start()
    {
        _moduleId = _moduleIdCounter++;
        _tournament = (Tournament) Rnd.Range(0, 3);
        _isMensPlay = Rnd.Range(0, 2) != 0;

        Debug.LogFormat(@"[Tennis #{0}] Welcome to the {1}’s final here at {2}.", _moduleId, _isMensPlay ? "men" : "women",
            _tournament == Tournament.FrenchOpenRolandGarros ? "the French Open Roland-Garros" :
            _tournament == Tournament.USOpenFlushingMeadows ? "the US Open at Flushing Meadows" :
            _tournament == Tournament.Wimbledon ? "The Championships, Wimbledon" : "some ghost tournament that nobody realizes exists");

        var max = _isMensPlay ? Rnd.Range(110, 150) : Rnd.Range(65, 80);
        tryAgain:
        var initialState = GameState.GetInitial(_isMensPlay, _tournament);
        for (int i = 0; i < max; i++)
        {
            initialState = ((GameStateScores) initialState).PlayerScores(Rnd.Range(0, 2) == 1);
            if (initialState is GameStateVictory)
            {
                max /= 2;
                goto tryAgain;
            }
        }
        _initialState = ((GameStateScores) initialState).Normalize();
        Debug.LogFormat(@"[Tennis #{0}] Initial score: {1}", _moduleId, initialState);

        _solutionState = _currentState = _initialState;
        _player1 = new TennisPlayer { FullName = "Roger Federer", Surname = "Federer" };
        _player2 = new TennisPlayer { FullName = "Novak Djokovic", Surname = "Djokovic" };

        _currentState.Setup(this, _player1, _player2);

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
                Debug.LogFormat(@"[Tennis #{0}] You clicked {1}, which is incorrect.", _moduleId, isPlayer1 ? _player1.FullName : _player2.FullName);
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
        _currentState.Setup(this, _player1, _player2);
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

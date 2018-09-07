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

    private static int _moduleIdCounter = 1;
    private int _moduleId;
    private Tournament _tournament;
    private bool _isMensPlay;
    private GameState _solutionState;

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
        initialState.Setup(this, "Roger Federer", "Novak Djokovic");
        Debug.LogFormat(@"[Tennis #{0}] Initial score: {1}", _moduleId, initialState);

        _solutionState = initialState;
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
            Debug.LogFormat(@"[Tennis #{0}] {1} → {2}", _moduleId, binary[i] ? "srv" : "opp", _solutionState);
        }
    }
}

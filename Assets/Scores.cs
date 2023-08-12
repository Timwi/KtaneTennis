using System.Linq;
using Tennis;
using UnityEngine;
using Rnd = UnityEngine.Random;

public partial class TennisModule
{
    sealed class SetScores
    {
        public int Player1Score { get; private set; }
        public int Player2Score { get; private set; }
        public SetScores() { Player1Score = 0; Player2Score = 0; }
        public SetScores(int player1Score, int player2Score) { Player1Score = player1Score; Player2Score = player2Score; }
        public int ScoreOf(bool player1) { return player1 ? Player1Score : Player2Score; }
        public SetScores Inc(bool player1) { return new SetScores(Player1Score + (player1 ? 1 : 0), Player2Score + (player1 ? 0 : 1)); }
        public override string ToString() { return string.Format("[{0}-{1}]", Player1Score, Player2Score); }
    }
    abstract class GameState
    {
        public static GameState GetInitial(bool isMensPlay, Tournament tournament) { return new GameStateScores(isMensPlay, tournament, new SetScores[] { new SetScores() }); }
        public abstract void Setup(TennisModule module);
    }
    sealed class GameStateScores : GameState
    {
        public SetScores[] Sets { get; private set; }

        // In normal play: [0,2] = 0–30; or [3,3] = 40–40; [4,3] = advantage Player 1; [4,4] = deuce
        // In tie break: normal tiebreak scores
        public int Player1Score { get; private set; }
        public int Player2Score { get; private set; }
        public bool IsTieBreak { get; private set; }

        public bool IsMensPlay { get; private set; }
        public Tournament Tournament { get; private set; }

        public GameStateScores(bool isMensPlay, Tournament tournament, SetScores[] sets) { IsMensPlay = isMensPlay; Tournament = tournament; Sets = sets; }
        public GameStateScores(bool isMensPlay, Tournament tournament, SetScores[] sets, int player1Score, int player2Score, bool tiebreak = false) { IsMensPlay = isMensPlay; Tournament = tournament; Sets = sets; Player1Score = player1Score; Player2Score = player2Score; IsTieBreak = tiebreak; }

        public bool IsPlayer1Serving
        {
            get
            {
                return (Sets.Sum(set => set.Player1Score + set.Player2Score) % 2 == 0) ^ (IsTieBreak && (Player1Score + Player2Score + 1) % 4 >= 2);
            }
        }

        public GameStateScores Normalize()
        {
            if (Tournament != Tournament.FrenchOpenRolandGarros && !IsTieBreak && Player1Score == 3 && Player2Score == 3)
                return new GameStateScores(IsMensPlay, Tournament, Sets, 4, 4);
            return this;
        }

        public GameState PlayerScores(bool server)
        {
            var isPlayer1 = !(server ^ IsPlayer1Serving);
            var thisPlayer = isPlayer1 ? Player1Score : Player2Score;
            var otherPlayer = isPlayer1 ? Player2Score : Player1Score;

            // Does player win a game?
            if ((IsTieBreak && thisPlayer >= 6 && thisPlayer > otherPlayer) ||  // winning a tie break
                (!IsTieBreak && thisPlayer == 3 && otherPlayer < 3) ||  // winning from 40–0 to 40–30
                (!IsTieBreak && thisPlayer == 4 && otherPlayer == 3))   // winning from Advantage
            {
                // Does player win a set?
                var thisPlayerSet = isPlayer1 ? Sets.Last().Player1Score : Sets.Last().Player2Score;
                var otherPlayerSet = isPlayer1 ? Sets.Last().Player2Score : Sets.Last().Player1Score;
                if ((thisPlayerSet >= 5 && thisPlayerSet > otherPlayerSet) || IsTieBreak)
                {
                    // Does player win the match?
                    if (Sets.Take(Sets.Length - 1).Count(set => isPlayer1 ? set.Player1Score > set.Player2Score : set.Player2Score > set.Player1Score) + 1 >= (IsMensPlay ? 3 : 2))
                        return new GameStateVictory { Player1Wins = isPlayer1 };

                    // Just the set
                    return new GameStateScores(IsMensPlay, Tournament, Sets.Take(Sets.Length - 1).Concat(new[] { Sets.Last().Inc(isPlayer1), new SetScores() }).ToArray());
                }

                // Just the game.
                // Does this start a tie break?
                if (thisPlayerSet + 1 == 6 && otherPlayerSet == 6 && (Tournament == Tournament.USOpenFlushingMeadows || Sets.Length < (IsMensPlay ? 5 : 3)))
                    return new GameStateScores(IsMensPlay, Tournament, Sets.Take(Sets.Length - 1).Concat(new[] { Sets.Last().Inc(isPlayer1) }).ToArray(), 0, 0, tiebreak: true);
                return new GameStateScores(IsMensPlay, Tournament, Sets.Take(Sets.Length - 1).Concat(new[] { Sets.Last().Inc(isPlayer1) }).ToArray());
            }

            // Just a point. Are we going from Deuce to Advantage?
            if (thisPlayer == 4 && otherPlayer == 4 && !IsTieBreak)
                return new GameStateScores(IsMensPlay, Tournament, Sets, isPlayer1 ? 4 : 3, isPlayer1 ? 3 : 4);
            return new GameStateScores(IsMensPlay, Tournament, Sets, Player1Score + (isPlayer1 ? 1 : 0), Player2Score + (isPlayer1 ? 0 : 1), IsTieBreak);
        }

        public GameStateScores ClickGameScore(bool isPlayer1)
        {
            if (IsTieBreak)
                return new GameStateScores(IsMensPlay, Tournament, Sets, Player1Score + (isPlayer1 && Player1Score < 99 ? 1 : 0), Player2Score + (!isPlayer1 && Player2Score < 99 ? 1 : 0), tiebreak: true);
            return new GameStateScores(IsMensPlay, Tournament, Sets, (Player1Score + (isPlayer1 ? 1 : 0)) % 4, (Player2Score + (isPlayer1 ? 0 : 1)) % 4);
        }

        public GameStateScores LongClickGameScore()
        {
            return new GameStateScores(IsMensPlay, Tournament, Sets, 0, 0, IsTieBreak);
        }

        public GameStateScores ClickGameScore2()
        {
            if (Player1Score == 4 && Player2Score == 4)
                return new GameStateScores(IsMensPlay, Tournament, Sets, 4, 3);
            if (Player1Score == 4 && Player2Score == 3)
                return new GameStateScores(IsMensPlay, Tournament, Sets, 3, 4);
            return new GameStateScores(IsMensPlay, Tournament, Sets, 4, 4);
        }

        public GameStateScores ClickRacket()
        {
            if (IsTieBreak)
                return new GameStateScores(IsMensPlay, Tournament, Sets, 0, 0);
            if (Player1Score == 4 || Player2Score == 4)
                return new GameStateScores(IsMensPlay, Tournament, Sets, 0, 0, tiebreak: true);
            return new GameStateScores(IsMensPlay, Tournament, Sets, 4, 4);
        }

        public GameStateScores ClickSetScore(int setIx, bool isPlayer1)
        {
            if (setIx < Sets.Length)
                return new GameStateScores(IsMensPlay, Tournament, Sets.Select((set, ix) => ix != setIx ? set : new SetScores(set.Player1Score + (isPlayer1 && set.Player1Score < 99 ? 1 : 0), set.Player2Score + (!isPlayer1 && set.Player2Score < 99 ? 1 : 0))).ToArray(), Player1Score, Player2Score, IsTieBreak);
            if (setIx == Sets.Length)
                return new GameStateScores(IsMensPlay, Tournament, Sets.Concat(new[] { new SetScores() }).ToArray(), Player1Score, Player2Score, IsTieBreak);
            return this;
        }

        public GameStateScores LongClickSetScore(int setIx)
        {
            if (setIx < Sets.Length)
                return new GameStateScores(IsMensPlay, Tournament, Sets.Take(setIx).ToArray(), Player1Score, Player2Score, IsTieBreak);
            return this;
        }

        private static readonly string[] ScoreNames = new[] { "0", "15", "30", "40" };
        public override string ToString()
        {
            if (IsTieBreak)
                return string.Format("•P{0} {1} Tie break {2}-{3}", IsPlayer1Serving ? "1" : "2", string.Join(" ", Sets.Select(s => s.ToString()).ToArray()), Player1Score, Player2Score);
            if (Player1Score == 4 && Player2Score == 4 || (Player1Score == 3 && Player2Score == 3 && Tournament != Tournament.FrenchOpenRolandGarros))
                return string.Format("•P{0} {1} Deuce", IsPlayer1Serving ? "1" : "2", string.Join(" ", Sets.Select(s => s.ToString()).ToArray()));
            if (Player1Score == 4)
                return string.Format("•P{0} {1} Advantage Player 1", IsPlayer1Serving ? "1" : "2", string.Join(" ", Sets.Select(s => s.ToString()).ToArray()));
            if (Player2Score == 4)
                return string.Format("•P{0} {1} Advantage Player 2", IsPlayer1Serving ? "1" : "2", string.Join(" ", Sets.Select(s => s.ToString()).ToArray()));
            return string.Format("•P{0} {1} {2}-{3}", IsPlayer1Serving ? "1" : "2", string.Join(" ", Sets.Select(s => s.ToString()).ToArray()), ScoreNames[Player1Score], ScoreNames[Player2Score]);
        }

        public override void Setup(TennisModule module)
        {
            module.ScoresGroup.SetActive(true);
            module.TrophyGroup.SetActive(false);
            module.TieBreak.SetActive(IsTieBreak);

            module.Main.material.mainTexture = module.Courts[(int) Tournament];
            if (IsTieBreak || (Player1Score != 4 && Player2Score != 4))
            {
                module.GameScore1.SetActive(true);
                module.GameScore2.SetActive(false);
                module.GameScore1.transform.Find("ScoreBox1").Find("Score").GetComponent<TextMesh>().text = IsTieBreak ? Player1Score.ToString() : ScoreNames[Player1Score];
                module.GameScore1.transform.Find("ScoreBox2").Find("Score").GetComponent<TextMesh>().text = IsTieBreak ? Player2Score.ToString() : ScoreNames[Player2Score];
            }
            else
            {
                module.GameScore1.SetActive(false);
                module.GameScore2.SetActive(true);

                var p1 = Data.ShortNames[module._player1];
                var p2 = Data.ShortNames[module._player2];
                var i = 0;
                while (p1 == p2)
                {
                    i++;
                    p1 = string.Format("{0}. {1}", module._player1.Substring(0, i), Data.ShortNames[module._player1]);
                    p2 = string.Format("{0}. {1}", module._player2.Substring(0, i), Data.ShortNames[module._player2]);
                }

                module.GameScore2.transform.Find("Score").GetComponent<TextMesh>().text =
                    Player1Score == 3 ? (Tournament == Tournament.FrenchOpenRolandGarros ? "Avantage\n" : "Advantage\n") + p2 :
                    Player2Score == 3 ? (Tournament == Tournament.FrenchOpenRolandGarros ? "Avantage\n" : "Advantage\n") + p1 :
                    (Tournament == Tournament.FrenchOpenRolandGarros ? "Égalité" : "Deuce");
                module.GameScore2.transform.Find("Score").GetComponent<TextMesh>().fontSize = Player1Score == 3 || Player2Score == 3 ? 80 : 128;
            }

            for (int i = 0; i < 5; i++)
            {
                module.SetScoresGroup.transform.Find(string.Format("Set{0}Score", i + 1)).Find(string.Format("Set{0}ScoreBox1", i + 1)).Find("Score").GetComponent<TextMesh>().text = i < Sets.Length ? Sets[i].Player1Score.ToString() : "";
                module.SetScoresGroup.transform.Find(string.Format("Set{0}Score", i + 1)).Find(string.Format("Set{0}ScoreBox2", i + 1)).Find("Score").GetComponent<TextMesh>().text = i < Sets.Length ? Sets[i].Player2Score.ToString() : "";
            }
        }

        public bool IsCorrect(GameState solution)
        {
            if (!(solution is GameStateScores))
                return false;
            var sol = (GameStateScores) solution;
            if (Sets.Length != sol.Sets.Length)
                return false;
            for (int i = 0; i < Sets.Length; i++)
                if (Sets[i].Player1Score != sol.Sets[i].Player1Score || Sets[i].Player2Score != sol.Sets[i].Player2Score)
                    return false;
            if (IsTieBreak != sol.IsTieBreak)
                return false;

            // Special case: outside of Roland Garros, 40–40 is supposed to be notated as Deuce
            if (Tournament != Tournament.FrenchOpenRolandGarros && !IsTieBreak && sol.Player1Score == 3 && sol.Player2Score == 3)
                return Player1Score == 4 && Player2Score == 4;
            return Player1Score == sol.Player1Score && Player2Score == sol.Player2Score;
        }
    }
    sealed class GameStateVictory : GameState
    {
        public bool Player1Wins;

        public override void Setup(TennisModule module)
        {
            module.ScoresGroup.SetActive(false);
            module.TrophyGroup.SetActive(true);
            module.TrophyGroup.transform.Find("Trophy").GetComponent<MeshRenderer>().material.mainTexture = module.Trophies[Rnd.Range(0, module.Trophies.Length)];
            module.TrophyGroup.transform.Find("Winner").Find("Name").GetComponent<TextMesh>().text = (Player1Wins ? module._player1 : module._player2);
        }

        public override string ToString()
        {
            return string.Format("Player {0} wins.", Player1Wins ? 1 : 2);
        }
    }
}

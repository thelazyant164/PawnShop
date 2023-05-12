using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.Move
{
    public readonly struct MatchStatistic
    {
        public readonly TimeSpan TotalTimeElapsed;
        public readonly TimeSpan TimeElapsed;
        public readonly TimeSpan AverageTurnDuration;
        public readonly int TurnNo = 0;
        public readonly int CoinCollected = 0;
        public readonly int CoinSpent = 0;
        public readonly int PieceCaptured = 0;
        public readonly int PiecePawned = 0;
        public readonly int PieceUpgraded = 0;
        private readonly IReadOnlyList<Turn> history;

        public MatchStatistic(BasePlayer player) 
        {
            history = GameManager.Instance.History.MatchHistory;

            TotalTimeElapsed = (history.Last().Date - history.First().Date).Duration();
            TurnNo = (int)MathF.Ceiling(history.Count / 2);

            TimeSpan turnDuration = new TimeSpan();
            for (int i = 0; i < history.Count; i++)
            {
                Turn t = history[i];
                if (t.Side != player.Side) continue;
                if (t.Move is Move)
                {
                    CoinCollected += (t.Move as Move)!.Coin != null ? 1 : 0;
                }
                else if (t.Move is Capture)
                {
                    CoinCollected += (t.Move as Capture)!.Coin != null ? 1 : 0;
                    PieceCaptured++;
                }
                else if (t.Move is Buy)
                {
                    CoinSpent++;
                    PiecePawned++;
                }
                else if (t.Move is Upgrade)
                {
                    CoinSpent += (t.Move as Upgrade)!.Cost;
                    PieceUpgraded++;
                }
                Turn t0 = i - 1 >= 0 ? history[i - 1] : t;
                turnDuration += (t.Date - t0.Date).Duration();
            }

            TimeElapsed = turnDuration;
            AverageTurnDuration = TimeElapsed / TurnNo;
        }
    }
}

using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.System.Gameplay
{
    public class TurnSystem
    {
        public class OnTurnChangeEventArgs : EventArgs
        {
            public BasePlayer.PlayerSide Side;
            public BasePlayer.PlayerType Type;
        }

        public event EventHandler<OnTurnChangeEventArgs> OnTurnChange;

        public BasePlayer.PlayerSide CurrentTurn { get; private set; }

        public BasePlayer.PlayerType CurrentType { get; private set; }

        public BasePlayer CurrentPlayer { get; private set; }

        private readonly List<BasePlayer> activePlayers;

        public TurnSystem(GameManager.GameConfig config)
        {
            activePlayers = new List<BasePlayer>
            {
                new BasePlayer(BasePlayer.PlayerSide.White, config.White),
                new BasePlayer(BasePlayer.PlayerSide.Black, config.Black)
            };
            OnTurnChange += (object sender, OnTurnChangeEventArgs eventArgs) =>
            {
                CurrentTurn = eventArgs.Side;
                CurrentType = eventArgs.Type;
                CurrentPlayer = GetPlayer(CurrentTurn);
            };
            CurrentPlayer = activePlayers[0];
        }

        public void Update()
        {
            foreach (BasePlayer player in activePlayers)
            {
                player.Progress();
            }
        }

        public BasePlayer GetPlayer(BasePlayer.PlayerSide side)
        {
            BasePlayer? activePlayer = activePlayers.Find(player => player.Side == side);
            if (activePlayer != null)
            {
                return activePlayer;
            }
            else
            {
                throw new Exception($"Cannot find player of side {side}");
            }
        }

        public List<Position> GetReign(BasePlayer player)
        {
            return player.Reign;
        }
    }
}

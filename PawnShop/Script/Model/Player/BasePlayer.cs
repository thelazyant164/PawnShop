using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player.Controller;
using PawnShop.Script.System.Gameplay.PlayerState;

namespace PawnShop.Script.Model.Player
{
    public class BasePlayer
    {
        public enum PlayerType
        {
            AI,
            Manual
        }

        public enum PlayerSide
        {
            White,
            Black
        }

        private readonly PlayerInfo info;
        private readonly PlayerStateSystem state;
        private readonly PlayerController controller;

        public PlayerSide Side
        {
            get => info.Side;
        }

        public List<Position> Reign
        {
            get => info.Reign;
        }

        public BasePlayer(PlayerSide side, PlayerType type)
        {
            info = new PlayerInfo(side, type);
            state = new PlayerStateSystem();
            state.SetPlayerState(new AwaitingTurn(state));
            switch (type)
            {
                case PlayerType.Manual:
                    controller = new ManualController();
                    break;
                case PlayerType.AI:
                    controller = new AIController();
                    break;
                default:
                    throw new Exception(
                        "Game config error - incorrect player type declaration during initialization."
                    );
            }
            PieceFactory.OnPieceAdd += Add;
        }

        private void Add(object sender, BasePiece.OnAddPieceEventArgs eventArgs)
        {
            if (eventArgs.Piece.Side == Side)
            {
                info.Add(eventArgs.Piece);
            }
        }

        public void Progress()
        {
            state.Update();
        }
    }
}

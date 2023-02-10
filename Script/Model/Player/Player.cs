using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessUltimate.Script.Model.Player.Controller;
using ChessUltimate.Script.System.Gameplay.GameState;

namespace ChessUltimate.Script.Model.Player
{
    public class Player
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

        public Player(PlayerSide side, PlayerType type)
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
        }

        public void Progress()
        {
            state.Update();
        }
    }
}

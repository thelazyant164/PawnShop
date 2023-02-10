using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessUltimate.Script.Model.Player.Player;

namespace ChessUltimate.Script.Model.Player
{
    public class PlayerInfo
    {
        public PlayerSide Side { get; private set; }

        public PlayerInfo(PlayerSide side, PlayerType type)
        {
            Side = side;
            switch (type)
            {
                case PlayerType.Manual:
                    break;
                case PlayerType.AI:
                    break;
                default:
                    throw new Exception(
                        "Game config error - incorrect player type declaration during initialization."
                    );
            }
        }
    }
}

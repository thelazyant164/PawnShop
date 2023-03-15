using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.Model.Player
{
    public class PlayerInfo
    {
        public PlayerSide Side { get; private set; }

        public List<BasePiece> Pieces { get; private set; }

        public List<Position> Reign { get; private set; }

        public PlayerInfo(PlayerSide side, PlayerType type)
        {
            Side = side;
            Pieces = new List<BasePiece>();
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

        public void Add(BasePiece piece)
        {
            Pieces.Add(piece);
        }

        public void Remove(BasePiece piece)
        {
            Pieces.Remove(piece);
        }

        public void UpdateReign()
        {
            throw new NotImplementedException();
        }

        public bool IsGuarding(Position position)
        {
            return Reign.Contains(position);
        }
    }
}

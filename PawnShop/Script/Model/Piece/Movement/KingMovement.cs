using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.Piece.Movement
{
    public sealed class KingMovement : PieceMovementController
    {
        public KingMovement() {}

        public override List<Position> GetReign(BasePiece piece, Position currentPos)
        {
            List<Position> result = new List<Position>();
            result.AddRange(BoardNavigator.BishopNavigate(currentPos, 1));
            result.AddRange(BoardNavigator.RookNavigate(currentPos, 1));
            return result;
        }
    }
}

using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.Piece.Movement
{
    public class RookMovement : PieceMovementController
    {
        public RookMovement() { }

        public override List<Position> GetReign(BasePiece piece, Position currentPos) => BoardNavigator.RookNavigate(currentPos, 8);
    }
}

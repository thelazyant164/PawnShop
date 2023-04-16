using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.Piece.Movement.PieceMovementController;

namespace PawnShop.Script.Model.Piece.Movement
{
    public class BishopMovement : PieceMovementController
    {
        public BishopMovement() { }

        public override List<Position> GetReign(BasePiece piece, Position currentPos) => BoardNavigator.BishopNavigate(currentPos, 8);
    }
}

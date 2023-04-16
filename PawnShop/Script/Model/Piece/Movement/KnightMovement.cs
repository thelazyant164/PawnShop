using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.Piece.Movement
{
    public sealed class KnightMovement : PieceMovementController
    {
        public KnightMovement() { }

        public override List<Position> GetReign(BasePiece piece, Position currentPos) => BoardNavigator.KnightNavigate(currentPos);
    }
}

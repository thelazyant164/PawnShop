using PawnShop.Script.Model.Board;

namespace PawnShop.Script.Model.Piece.Movement
{
    public class RookMovement : PieceMovementController
    {
        public RookMovement() { }

        public override List<Position> GetReign(BasePiece piece, Position currentPos) => BoardNavigator.RookNavigate(currentPos, 8);
    }
}

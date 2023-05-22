using PawnShop.Script.Model.Board;

namespace PawnShop.Script.Model.Piece.Movement
{
    public class BishopMovement : PieceMovementController
    {
        public BishopMovement() { }

        public override List<Position> GetReign(BasePiece piece, Position currentPos) => BoardNavigator.BishopNavigate(currentPos, 8);
    }
}

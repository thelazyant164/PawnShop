using PawnShop.Script.Model.Board;

namespace PawnShop.Script.Model.Piece.Movement
{
    public sealed class KnightMovement : PieceMovementController
    {
        public KnightMovement() { }

        public override List<Position> GetReign(BasePiece piece, Position currentPos) => BoardNavigator.KnightNavigate(currentPos);
    }
}

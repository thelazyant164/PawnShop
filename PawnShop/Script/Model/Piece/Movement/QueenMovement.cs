using PawnShop.Script.Model.Board;

namespace PawnShop.Script.Model.Piece.Movement
{
    public sealed class QueenMovement : PieceMovementController
    {
        public QueenMovement() { }

        public override List<Position> GetReign(BasePiece piece, Position currentPos)
        {
            List<Position> result = new List<Position>();
            result.AddRange(BoardNavigator.BishopNavigate(currentPos, 8));
            result.AddRange(BoardNavigator.RookNavigate(currentPos, 8));
            return result;
        }
    }
}

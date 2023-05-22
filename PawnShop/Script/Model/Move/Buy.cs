using PawnShop.Script.Model.Piece;
using static PawnShop.Script.Model.Piece.BasePiece;
using static PawnShop.Script.Model.Piece.BasePiece.PieceRole;

namespace PawnShop.Script.Model.Move
{
    public sealed class Buy : BaseMove
    {
        public readonly static int Cost = Costs[Pawn];
        private readonly BasePiece piece;

        public Buy(PieceIdentity pieceID)
        {
            piece = PieceFactory.CreatePiece(pieceID);
            piece.Capture();
        }

        public override void Execute()
        {
            player.Spend(Cost);
            piece.Restore();
        }

        public override void Abort()
        {
            player.Gain(Cost);
            piece.Capture();
        }

        public override string ToString() => $"Created {piece}";
    }
}

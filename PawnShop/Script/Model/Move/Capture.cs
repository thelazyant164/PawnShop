using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using static PawnShop.Script.Model.Piece.BasePiece;
using static PawnShop.Script.Model.Piece.BasePiece.PieceRole;

namespace PawnShop.Script.Model.Move
{
    public sealed class Capture : BaseMove
    {
        private readonly BasePiece piece;
        private readonly BasePiece capturedPiece;
        private readonly Position current;
        private readonly Position target;
        private readonly Coin.Coin? coin;
        public Coin.Coin? Coin => coin;

        public Capture(BasePiece piece, Position target)
        {
            this.piece = piece;
            this.target = target;
            capturedPiece = target.OccupyingPiece!;
            if (GameManager.Instance.Board.TryLocate(piece, out Position? pos))
            {
                current = pos!;
            }
            else
            {
                throw new Exception("Invalid move: piece's current position not found");
            }
            if (piece.Role == King)
            {
                coin = target.Coin;
            }
        }

        public override void Execute()
        {
            if (coin != null)
            {
                coin.Collect();
                player.Gain(coin.Value);
            }
            capturedPiece.Capture();
            player.Gain(capturedPiece.Role == Pawn ? Costs[capturedPiece.Role] : Costs[capturedPiece.Role] + 1);
            piece.MoveTo(target);
        }

        public override void Abort()
        {
            piece.MoveTo(current);
            player.Spend(capturedPiece.Role == Pawn ? Costs[capturedPiece.Role] : Costs[capturedPiece.Role] + 1);
            capturedPiece.Restore();
            if (coin != null)
            {
                coin.Restore();
                player.Spend(coin.Value);
            }
        }

        public override string ToString() => $"{piece} moved from {current} to {target}, capturing {capturedPiece}";
    }
}

using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using static PawnShop.Script.Model.Piece.BasePiece.PieceRole;

namespace PawnShop.Script.Model.Move
{
    public sealed class Move : BaseMove
    {
        private readonly BasePiece piece;
        private readonly Position current;
        private readonly Position target;
        private readonly Coin.Coin? coin;
        public Coin.Coin? Coin => coin;

        public Move(BasePiece piece, Position target)
        {
            this.piece = piece;
            if (GameManager.Instance.Board.TryLocate(piece, out Position? pos))
            {
                current = pos!;
            }
            else
            {
                throw new Exception("Invalid move: piece's current position not found");
            }
            this.target = target;
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
            piece.MoveTo(target);
        }

        public override void Abort()
        {
            piece.MoveTo(current);
            if (coin != null)
            {
                coin.Restore();
                player.Spend(coin.Value);
            }
        }

        public override string ToString() => $"{piece} moved from {current} to {target}";
    }
}

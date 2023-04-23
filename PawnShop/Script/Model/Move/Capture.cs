using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                coin.InvokeOnCollect(this, EventArgs.Empty);
                player.Gain(coin.Value);
            }
            capturedPiece.Capture();
            player.Gain(Costs[capturedPiece.Role]);
            piece.MoveTo(target);
        }

        public override void Abort()
        {
            piece.MoveTo(current);
            player.Spend(Costs[capturedPiece.Role]);
            capturedPiece.Restore();
            if (coin != null)
            {
                coin.InvokeOnRestore(this, EventArgs.Empty);
                player.Spend(coin.Value);
            }
        }

        public override string ToString() => $"{piece} moved from {current} to {target}, capturing {capturedPiece}";
    }
}

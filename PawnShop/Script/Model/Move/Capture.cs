using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PawnShop.Script.Model.Move
{
    public sealed class Capture : BaseMove
    {
        private readonly BasePiece piece;
        private readonly BasePiece capturedPiece;
        private readonly Position current;
        private readonly Position target;

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
        }

        public override void Execute()
        {
            capturedPiece.Capture();
            piece.MoveTo(target);
        }

        public override void Abort()
        {
            piece.MoveTo(current);
            capturedPiece.Restore();
        }

        public override string ToString() => $"{piece} moved from {current} to {target}, capturing {capturedPiece}";
    }
}

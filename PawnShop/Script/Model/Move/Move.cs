using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using static PawnShop.Script.Model.Board.Position;
using static PawnShop.Script.Model.Board.Position.HighlightType;

namespace PawnShop.Script.Model.Move
{
    public sealed class Move : BaseMove
    {
        private readonly BasePiece piece;
        private readonly Position current;
        private readonly Position target;

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
        }

        public override void Execute()
        {
            piece.MoveTo(target);
        }

        public override void Abort()
        {
            piece.MoveTo(current);
        }

        public override string ToString() => $"{piece} moved from {current} to {target}";
    }
}

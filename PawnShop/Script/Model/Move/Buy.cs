using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.System.Gameplay.PieceState;
using static PawnShop.Script.Model.Piece.BasePiece;

namespace PawnShop.Script.Model.Move
{
    public sealed class Buy : BaseMove
    {
        private readonly PieceIdentity pieceID;
        private BasePiece? piece;

        public Buy(PieceIdentity pieceID) 
        {
            this.pieceID = pieceID;
        }

        private void PieceFactory_OnPieceAdd(BasePiece piece) => this.piece = piece;

        public override void Execute()
        {
            PieceFactory.OnPieceAdd += PieceFactory_OnPieceAdd;
            PieceFactory.CreatePiece(pieceID);
            PieceFactory.OnPieceAdd -= PieceFactory_OnPieceAdd;
        }

        public override void Abort()
        {
            piece!.Capture();
        }

        public override string ToString() => $"Created {piece} at {pieceID.StartPosition}";
    }
}

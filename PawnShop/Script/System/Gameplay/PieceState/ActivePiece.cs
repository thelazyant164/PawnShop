using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.System.Gameplay.PieceState
{
    public sealed class ActivePiece : PieceState
    {
        public ActivePiece(PieceStateSystem pieceStateSystem) : base(pieceStateSystem) 
        {
            PieceStateSystem.Piece.ToggleResponseToClick(true);
        }

        public override void Terminate() => PieceStateSystem.Piece.ToggleResponseToClick(false);

        public override void Progress()
        {
            if (PieceStateSystem.TurnSystem.CurrentTurn != PieceStateSystem.Piece.Side)
            {
                PieceStateSystem.SetPieceState(new InactivePiece(PieceStateSystem));
            }
            if (PieceStateSystem.Piece.Equals(PieceStateSystem.Cache.SelectedPiece))
            {
                PieceStateSystem.SetPieceState(new SelectedPiece(PieceStateSystem));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.System.Gameplay.PieceState
{
    public sealed class InactivePiece : PieceState
    {
        public InactivePiece(PieceStateSystem pieceStateSystem) : base(pieceStateSystem) 
        {
            
        }

        public override void Terminate()
        {
            
        }

        public override void Progress()
        {
            if (PieceStateSystem.TurnSystem.CurrentTurn == PieceStateSystem.Piece.Side)
            {
                PieceStateSystem.SetPieceState(new ActivePiece(PieceStateSystem));
            }
        }
    }
}

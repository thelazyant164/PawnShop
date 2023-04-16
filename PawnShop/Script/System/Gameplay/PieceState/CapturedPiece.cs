using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.System.Gameplay.PieceState
{
    public sealed class CapturedPiece : PieceState
    {
        public CapturedPiece(PieceStateSystem pieceStateSystem) : base(pieceStateSystem) {}
    }
}

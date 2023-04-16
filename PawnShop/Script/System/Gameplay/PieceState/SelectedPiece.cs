using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.Board.Position.HighlightType;

namespace PawnShop.Script.System.Gameplay.PieceState
{
    public sealed class SelectedPiece : PieceState
    {
        private readonly BasePiece selectedPiece;
        private readonly Position currentPosition;
        private readonly HashSet<Position>? highlightedPositions;

        public SelectedPiece(PieceStateSystem pieceStateSystem) : base(pieceStateSystem) 
        {
            selectedPiece = PieceStateSystem.Cache.SelectedPiece!;
            GameManager.Instance.Board.TryLocate(PieceStateSystem.Piece, out Position? currentPos);
            currentPosition = currentPos!;

            currentPosition.InvokeOnHighlight(this, Selected);
            highlightedPositions = selectedPiece.GetAllMoves() as HashSet<Position>;
            if (highlightedPositions == null) return;
            foreach (Position position in highlightedPositions)
            {
                position.ToggleResponseToClick(true);
                if (position.IsOccupied) 
                {
                    position.InvokeOnHighlight(selectedPiece, Capturable);
                }
                else
                {
                    position.InvokeOnHighlight(selectedPiece, Movable);
                }
            }
        }

        public override void Terminate()
        {
            currentPosition.InvokeOnHighlight(this, None);
            if (highlightedPositions == null) return;
            foreach (Position position in highlightedPositions) 
            {
                position.ToggleResponseToClick(false);
                position.InvokeOnHighlight(selectedPiece, None);
            }
        }

        public override void Progress()
        {
            if (!PieceStateSystem.Piece.Equals(PieceStateSystem.Cache.SelectedPiece))
            {
                PieceStateSystem.SetPieceState(new ActivePiece(PieceStateSystem));
            }
            if (PieceStateSystem.TurnSystem.CurrentTurn != PieceStateSystem.Piece.Side) 
            {
                PieceStateSystem.SetPieceState(new InactivePiece(PieceStateSystem));
            }
        }
    }
}

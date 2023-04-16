using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Player.Controller;
using static PawnShop.Script.Model.Board.Position.HighlightType;

namespace PawnShop.Script.Model.Cache
{
    public class SelectionCache
    {
        private Board.Board board;

        private BasePiece? selectedPiece;
        public BasePiece? SelectedPiece => selectedPiece;
        private Position? selectedPosition;
        public Position? SelectedPosition => selectedPosition;

        public SelectionCache(PlayerController controller) 
        {
            board = GameManager.Instance.Board;

            controller.OnSelectPiece += SelectPiece;
            controller.OnSelectPosition += SelectPosition;
        }

        public void SelectPiece(object? sender, BasePiece piece)
        {
            board.TryLocate(piece, out Position? piecePosition);
            if (selectedPiece != null && selectedPiece!.Equals(piece)) // click again on selected will deselect
            {
                selectedPiece = null;
                return;
            }
            selectedPiece = piece;
        }

        public void SelectPosition(object? sender, Position position)
        {
            selectedPosition = position;
        }

        public void Clear()
        {
            selectedPiece = null;
            selectedPosition = null;
        }
    }
}

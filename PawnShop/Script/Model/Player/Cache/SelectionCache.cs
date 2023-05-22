using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player.Controller;
using static PawnShop.Script.Model.Piece.BasePiece;

namespace PawnShop.Script.Model.Player.Cache
{
    public class SelectionCache
    {
        public BasePiece? SelectedPiece { get; private set; }
        public Position? SelectedPosition { get; private set; }
        public bool BuyMode { get; private set; }
        public bool UpgradeMode { get; private set; }
        public PieceRole? UpgradeRole { get; private set; }

        public SelectionCache(PlayerController controller)
        {
            controller.OnSelectPiece += SelectPiece;
            controller.OnSelectPosition += SelectPosition;
            controller.OnToggleBuyMode += ToggleBuyMode;
            controller.OnToggleUpgradeMode += ToggleUpgradeMode;
            controller.OnSelectUpgradeRole += SelectUpgradeRole;
        }

        private void SelectPiece(object? sender, BasePiece piece)
        {
            if (SelectedPiece?.Equals(piece) ?? false) // click again on selected will deselect
            {
                SelectedPiece = null;
                return;
            }
            SelectedPiece = piece;
        }

        private void SelectPosition(object? sender, Position position)
        {
            SelectedPosition = position;
        }

        private void ToggleBuyMode(object? sender, bool enable)
        {
            BuyMode = enable;
            if (BuyMode)
            {
                SelectedPiece = null;
            }
        }

        private void ToggleUpgradeMode(object? sender, bool enable)
        {
            UpgradeMode = enable;
        }

        private void SelectUpgradeRole(object? sender, PieceRole role)
        {
            UpgradeRole = role;
        }

        public void Clear()
        {
            SelectedPiece = null;
            SelectedPosition = null;
        }

        public void ExitBuyMode() => BuyMode = false;

        public void ExitUpgradeMode()
        {
            UpgradeMode = false;
            UpgradeRole = null;
        }
    }
}

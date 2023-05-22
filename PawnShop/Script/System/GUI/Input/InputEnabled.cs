using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Manager.GUI;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.GUI.GameElement;
using PawnShop.Script.Model.GUI.View;
using PawnShop.Script.Model.Piece;
using static PawnShop.Script.Model.Board.Position;
using static PawnShop.Script.Model.Piece.BasePiece;

namespace PawnShop.Script.System.GUI.Input
{
    public sealed class InputEnabled : InputState
    {
        private UpgradeView? upgradeView;

        public InputEnabled(InputSystem inputSystem) : base(inputSystem) { }

        public override void ToggleBuyMode() => Player.ToggleBuyMode();

        public override void ToggleUpgradeMode() => Player.ToggleUpgradeMode();

        public override void ToggleUpgradeView()
        {
            if (upgradeView == null)
            {
                upgradeView = new UpgradeView(Player, InputSystem);
                ViewManager.Instance.PlayerView.AddView(upgradeView);
            }
            else
            {
                ViewManager.Instance.PlayerView.RemoveView(upgradeView);
                upgradeView = null;
            }
        }

        public override void TogglePositionSelect(Position position) => position.OnClick();

        public override void ToggleIndicatorHighlight(PositionIndicator indicator, HighlightType type)
            => indicator.ToggleHighlight(type);

        public override void TogglePieceSelect(BasePiece piece) => piece.OnClick();

        public override void SelectUpgradeRole(PieceRole role) => Player.SelectUpgradeRole(role);

        public override void Undo()
        {
            GameManager.Instance.History.Abort();
            GameManager.Instance.CoinManager.Abort();
        }

        public override void Redo()
        {
            GameManager.Instance.CoinManager.Execute();
            GameManager.Instance.History.Execute();
        }
    }
}

using PawnShop.Script.Model.GUI.GameElement;
using PawnShop.Script.Model.Player;
using PawnShop.Script.System.GUI.Input;
using SplashKitSDK;
using static PawnShop.Script.Model.Piece.BasePiece;
using static PawnShop.Script.Model.Piece.BasePiece.PieceRole;

namespace PawnShop.Script.Model.GUI.View
{
    public sealed class UpgradeView : BaseView
    {
        public UpgradeView(BasePlayer player, InputSystem inputController) : base(player, inputController)
        {
            InitOption(Knight);
            InitOption(Bishop);
            InitOption(Rook);
            InitOption(Queen);
        }

        private void InitOption(PieceRole role)
        {
            UpgradeOption optionButton = new UpgradeOption(role);
            optionButton.OnClick += (object? sender, EventArgs e) => Input.SelectUpgradeRole(role);
            optionButton.OnClick += (object? sender, EventArgs e) => Input.ToggleUpgradeView();
            Interactables.Add(optionButton);
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(UpgradeViewFactory.CanvasGraphic, UpgradeViewFactory.CanvasX, UpgradeViewFactory.CanvasY);
            base.Draw();
        }
    }
}

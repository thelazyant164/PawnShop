using PawnShop.Script.Model.GUI.Button.Model;
using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using PawnShop.Script.System.Gameplay.PieceState;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;

namespace PawnShop.Script.Model.GUI.GameElement
{
    public sealed class UpgradeButton : ImageButton
    {
        private readonly static float x = 1000;
        private readonly static float y = 500;
        private readonly static float width = 108;
        private readonly static float height = 113;
        private readonly static PrimitiveRect rect = new PrimitiveRect(x, y, width, height);

        private readonly static string rootDir = "D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Asset\\Misc\\Upgrade";

        private readonly static ImageContent inactive =
            new ImageContent(new Bitmap($"inactive_upgrade", $"{rootDir}\\upgrade_inactive.png"));
        private readonly static ImageContent active =
            new ImageContent(new Bitmap($"active_upgrade", $"{rootDir}\\upgrade_active.png"));
        private readonly static ImageContent selected =
            new ImageContent(new Bitmap($"selected_upgrade", $"{rootDir}\\upgrade_selected.png"));
        private readonly static ImageContent pressed =
            new ImageContent(new Bitmap($"pressed_upgrade", $"{rootDir}\\upgrade_pressed.png"));

        private readonly static ImageContent cancelInactive =
            new ImageContent(new Bitmap($"cancel_inactive_upgrade", $"{rootDir}\\cancel_upgrade_inactive.png"));
        private readonly static ImageContent cancelActive =
            new ImageContent(new Bitmap($"cancel_active_upgrade", $"{rootDir}\\cancel_upgrade_active.png"));
        private readonly static ImageContent cancelSelected =
            new ImageContent(new Bitmap($"cancel_selected_upgrade", $"{rootDir}\\cancel_upgrade_selected.png"));
        private readonly static ImageContent cancelPressed =
            new ImageContent(new Bitmap($"cancel_pressed_upgrade", $"{rootDir}\\cancel_upgrade_pressed.png"));

        private readonly static ImageButtonUIState UIstate = new ImageButtonUIState(
            new ImageButtonUIStateData(active),
            new ImageButtonUIStateData(inactive),
            new ImageButtonUIStateData(pressed),
            new ImageButtonUIStateData(selected));

        private readonly static ImageButtonUIState cancelUIstate = new ImageButtonUIState(
            new ImageButtonUIStateData(cancelActive),
            new ImageButtonUIStateData(cancelInactive),
            new ImageButtonUIStateData(cancelPressed),
            new ImageButtonUIStateData(cancelSelected));

        private bool enabled = false;
        private bool activated = false;

        public override ImageContent Content => activated
            ? cancelUIstate.GetState(state.State).Content
            : UIstate.GetState(state.State).Content;

        public UpgradeButton() : base(rect, UIstate)
        {
            SelectedPiece.OnEnableUpgradeMode += (object? sender, EventArgs e) =>
            {
                enabled = true;
                Activate();
            };
            SelectedPiece.OnDisableUpgradeMode += (object? sender, EventArgs e) => Deactivate();
            UpgradingPiece.OnEnter += (object? sender, EventArgs e) => activated = true;
            UpgradingPiece.OnExit += (object? sender, EventArgs e) => activated = false;
            Deactivate();
        }

        public override void Activate()
        {
            if (!enabled) return;
            base.Activate();
        }

        public override void Deactivate()
        {
            enabled = false;
            base.Deactivate();
        }
    }
}

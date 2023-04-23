using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.GUI.Button.Model;
using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using PawnShop.Script.Model.Player;
using PawnShop.Script.System.Gameplay;
using PawnShop.Script.System.Gameplay.PlayerState;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using static PawnShop.Script.Model.Player.BasePlayer;
using static PawnShop.Script.Model.Player.BasePlayer.PlayerSide;

namespace PawnShop.Script.Model.GUI.GameElement
{
    public sealed class BuyButton : ImageButton
    {
        private readonly static float x = 880;
        private readonly static float y = 500;
        private readonly static float width = 108;
        private readonly static float height = 113;
        private readonly static PrimitiveRect rect = new PrimitiveRect(x, y, width, height);

        private readonly static string rootDir = "D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Asset\\Misc\\Buy";

        private readonly static ImageContent inactive =
            new ImageContent(new Bitmap($"inactive_buy", $"{rootDir}\\buy_inactive.png"));
        private readonly static ImageContent active =
            new ImageContent(new Bitmap($"active_buy", $"{rootDir}\\buy_active.png"));
        private readonly static ImageContent selected =
            new ImageContent(new Bitmap($"selected_buy", $"{rootDir}\\buy_selected.png"));
        private readonly static ImageContent pressed =
            new ImageContent(new Bitmap($"pressed_buy", $"{rootDir}\\buy_pressed.png"));

        private readonly static ImageContent cancelInactive =
            new ImageContent(new Bitmap($"cancel_inactive_buy", $"{rootDir}\\cancel_buy_inactive.png"));
        private readonly static ImageContent cancelActive =
            new ImageContent(new Bitmap($"cancel_active_buy", $"{rootDir}\\cancel_buy_active.png"));
        private readonly static ImageContent cancelSelected =
            new ImageContent(new Bitmap($"cancel_selected_buy", $"{rootDir}\\cancel_buy_selected.png"));
        private readonly static ImageContent cancelPressed =
            new ImageContent(new Bitmap($"cancel_pressed_buy", $"{rootDir}\\cancel_buy_pressed.png"));

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

        public BuyButton() : base(rect, UIstate) 
        {
            PlanningTurn.OnEnableBuyMode += (object? sender, EventArgs e) =>
            {
                enabled = true;
                Activate();
            };
            PlanningTurn.OnDisableBuyMode += (object? sender, EventArgs e) =>
            {
                enabled = false;
                Deactivate();
            };
            BuyMode.OnEnter += (object? sender, EventArgs e) => activated = true;
            BuyMode.OnExit += (object? sender, EventArgs e) => activated = false;
            Deactivate();
        }

        public override void Activate()
        {
            if (!enabled) return;
            base.Activate();
        }
    }
}

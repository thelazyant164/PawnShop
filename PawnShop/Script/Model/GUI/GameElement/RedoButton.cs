﻿using PawnShop.Script.Model.GUI.Button.Model;
using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using PawnShop.Script.Model.Move;
using PawnShop.Script.System.Gameplay.PlayerState;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;

namespace PawnShop.Script.Model.GUI.GameElement
{
    public sealed class RedoButton : ImageButton
    {
        private readonly static float x = 1015;
        private readonly static float y = 100;
        private readonly static float width = 75;
        private readonly static float height = 120;
        private readonly static PrimitiveRect rect = new PrimitiveRect(x, y, width, height);

        private readonly static string rootDir = "D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Asset\\Misc\\Redo";

        private readonly static ImageContent inactive =
            new ImageContent(new Bitmap($"inactive_redo", $"{rootDir}\\redo_inactive.png"));
        private readonly static ImageContent active =
            new ImageContent(new Bitmap($"active_redo", $"{rootDir}\\redo_active.png"));
        private readonly static ImageContent selected =
            new ImageContent(new Bitmap($"selected_redo", $"{rootDir}\\redo_selected.png"));
        private readonly static ImageContent pressed =
            new ImageContent(new Bitmap($"pressed_redo", $"{rootDir}\\redo_pressed.png"));

        private readonly static ImageButtonUIState UIstate = new ImageButtonUIState(
            new ImageButtonUIStateData(active),
            new ImageButtonUIStateData(inactive),
            new ImageButtonUIStateData(pressed),
            new ImageButtonUIStateData(selected));

        private bool enabled = false;

        public RedoButton() : base(rect, UIstate)
        {
            History.OnEnableRedo += (bool enable) =>
            {
                if (enable)
                {
                    enabled = true;
                    Activate();
                }
                else
                {
                    enabled = false;
                    Deactivate();
                }
            };
            Deactivate();
        }

        public override void Activate()
        {
            if (!enabled) return;
            base.Activate();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Manager.GUI;
using static PawnShop.Script.Model.GUI.Interface.IText;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using PawnShop.Script.Model.GUI.Button.State;
using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.Button.Model
{
    public sealed class TextButton
        : BaseButton<TextButtonState, TextButtonUIState, TextButtonUIStateData>,
            IText,
            IVisible
    {
        public TextContent Content
        {
            get => UIState.GetState(state.State).Content;
        }

        public TextButton(PrimitiveRect rect, TextButtonUIState textButtonUI)
            : base(rect, textButtonUI) { }

        public override void Draw()
        {
            if (!Visible)
                return;
            base.Draw();
            SplashKit.DrawText(Content.Text, Content.Color, Content.Font, Content.Size, X, Y);
        }
    }
}

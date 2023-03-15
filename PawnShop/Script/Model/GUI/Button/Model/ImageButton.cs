using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Button.State;
using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using PawnShop.Script.Model.GUI.Interface;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.Button.Model
{
    public sealed class ImageButton
        : BaseButton<ImageButtonState, ImageButtonUIState, ImageButtonUIStateData>,
            IImage
    {
        public ImageContent Content
        {
            get => UIState.GetState(state.State).Content;
        }

        public ImageButton(PrimitiveRect rect, ImageButtonUIState imageButtonUI)
            : base(rect, imageButtonUI) { }

        public override void Draw()
        {
            if (!Visible)
                return;
            base.Draw();
            SplashKit.DrawBitmap(Content.Texture, Rectangle.X, Rectangle.Y);
        }
    }
}

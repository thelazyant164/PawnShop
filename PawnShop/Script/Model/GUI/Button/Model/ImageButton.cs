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
    public class ImageButton
        : BaseButton<ImageButtonUIState, ImageButtonUIStateData>,
            IImage
    {
        public virtual ImageContent Content => UIState!.GetState(state.State).Content;

        public ImageButton(PrimitiveRect rect, ImageButtonUIState imageButtonUI)
            : base(rect, imageButtonUI) { }

        public override void Draw()
        {
            if (!Visible)
                return;
            SplashKit.DrawBitmap(Content.Texture, Rectangle.X, Rectangle.Y);
        }
    }
}

using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using PawnShop.Script.Model.GUI.Interface;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;

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

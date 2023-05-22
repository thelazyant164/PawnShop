using PawnShop.Script.Model.GUI.Interface;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;

namespace PawnShop.Script.Model.GUI.Label
{
    public class ImageLabel : BaseLabel<ImageContent>, IImage
    {
        public ImageLabel(Position position, ImageContent content) : base(position, content) { }

        public override void Draw()
        {
            if (!Visible)
                return;
            SplashKit.DrawBitmap(Content.Texture, X, Y);
        }
    }
}

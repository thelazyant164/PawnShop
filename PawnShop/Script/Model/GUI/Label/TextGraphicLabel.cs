using PawnShop.Script.Model.GUI.Interface;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;
using static PawnShop.Script.Model.GUI.Interface.ITextGraphic;

namespace PawnShop.Script.Model.GUI.Label
{
    public class TextGraphicLabel : BaseLabel<TextGraphicContent>, ITextGraphic
    {
        public TextGraphicLabel(Position position, TextGraphicContent content) : base(position, content) { }

        public override void Draw()
        {
            if (!Visible)
                return;
            SplashKit.DrawBitmap(Content.Texture, X, Y);
        }
    }
}

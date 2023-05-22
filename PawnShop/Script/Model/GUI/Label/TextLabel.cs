using PawnShop.Script.Model.GUI.Interface;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;

namespace PawnShop.Script.Model.GUI.Label
{
    public class TextLabel : BaseLabel<string>, IText
    {
        public TextLabel(Position position, string content) : base(position, content) { }

        public override void Draw()
        {
            if (!Visible)
                return;
            SplashKit.DrawText(Content, Color.Black, X, Y);
        }
    }
}

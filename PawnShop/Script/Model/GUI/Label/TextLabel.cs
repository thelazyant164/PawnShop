using PawnShop.Script.Model.GUI.Interface;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;
using static PawnShop.Script.Model.GUI.Interface.ITextGraphic;

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

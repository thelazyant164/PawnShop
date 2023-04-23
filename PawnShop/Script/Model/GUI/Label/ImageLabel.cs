using PawnShop.Script.Model.GUI.Component;
using PawnShop.Script.Model.GUI.Interface;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;
using static PawnShop.Script.Model.GUI.Interface.IImage;

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

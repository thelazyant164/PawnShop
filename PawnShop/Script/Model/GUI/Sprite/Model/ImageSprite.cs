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
using PawnShop.Script.Model.GUI.Sprite.UIStateData;
using PawnShop.Script.Model.GUI.Sprite.UIState;

namespace PawnShop.Script.Model.GUI.Sprite.Model
{
    public sealed class ImageSprite
        : BaseSprite<ImageSpriteUIState, ImageSpriteUIStateData, IImage>
    {
        public ImageContent Content => GetContent.Content;

        public ImageSprite(PrimitiveRect rect, ImageSpriteUIState imageSpriteUI)
            : base(rect, imageSpriteUI) { }

        public override void Draw()
        {
            if (!Visible)
                return;
            SplashKit.DrawBitmap(Content.Texture, Rectangle.X, Rectangle.Y);
        }
    }
}

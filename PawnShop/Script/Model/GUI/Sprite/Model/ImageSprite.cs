using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Button.State;
using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using PawnShop.Script.Model.GUI.Interface;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using SplashKitSDK;
using PawnShop.Script.Model.GUI.Sprite.UIStateData;
using PawnShop.Script.Model.GUI.Sprite.UIState;

namespace PawnShop.Script.Model.GUI.Sprite.Model
{
    public class ImageSprite
        : BaseSprite<ImageSpriteUIState, ImageSpriteUIStateData, ImageContent>, IImage
    {
        public ImageSprite(Position position, ImageSpriteUIState imageSpriteUI)
            : base(position, imageSpriteUI) { }

        public override void Draw()
        {
            if (!Visible)
                return;
            SplashKit.DrawBitmap(Content.Texture, X, Y);
        }
    }
}

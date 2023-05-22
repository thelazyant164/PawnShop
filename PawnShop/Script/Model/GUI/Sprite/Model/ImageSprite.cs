using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Model.GUI.Sprite.UIState;
using PawnShop.Script.Model.GUI.Sprite.UIStateData;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;

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

using PawnShop.Script.Model.GUI.Sprite.UIStateData;
using static PawnShop.Script.Model.GUI.Interface.IImage;

namespace PawnShop.Script.Model.GUI.Sprite.UIState
{
    public sealed class ImageSpriteUIState : SpriteUIState<ImageSpriteUIStateData, ImageContent>
    {
        public ImageSpriteUIState(ImageSpriteUIStateData UIStateData) : base(UIStateData) { }
    }
}

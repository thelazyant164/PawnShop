using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Sprite.State.SpriteState;
using PawnShop.Script.Model.GUI.Sprite.UIStateData;
using PawnShop.Script.Model.GUI.Interface;

namespace PawnShop.Script.Model.GUI.Sprite.UIState
{
    public sealed class ImageSpriteUIState : SpriteUIState<ImageSpriteUIStateData, IImage>
    {
        public ImageSpriteUIState(ImageSpriteUIStateData activeUI, ImageSpriteUIStateData inactiveUI) : base(activeUI, inactiveUI) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Interface;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IImage;

namespace PawnShop.Script.Model.GUI.Sprite.UIStateData
{
    public sealed class ImageSpriteUIStateData : SpriteUIStateData<IImage>
    {
        public ImageSpriteUIStateData(IImage[] spriteImgs) : base(spriteImgs)
        {
        }
    }
}

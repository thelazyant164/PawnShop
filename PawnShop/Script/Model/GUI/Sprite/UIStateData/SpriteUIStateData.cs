using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Interface;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IImage;

namespace PawnShop.Script.Model.GUI.Sprite.UIStateData
{
    public class SpriteUIStateData<T>
    {
        private readonly List<T> content = new List<T>();
        public int FrameCount => content.Count;
        public IReadOnlyList<T> Content => content;

        public SpriteUIStateData(T[] spriteImgs)
        {
            content.AddRange(spriteImgs);
        }
    }
}

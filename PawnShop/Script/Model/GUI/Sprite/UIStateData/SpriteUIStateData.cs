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
    public abstract class SpriteUIStateData<T>
    {
        private readonly List<T> content = new List<T>();
        public IReadOnlyList<T> Content => content.AsReadOnly();

        public SpriteUIStateData(T[] spriteStages)
        {
            content.AddRange(spriteStages);
        }
    }
}

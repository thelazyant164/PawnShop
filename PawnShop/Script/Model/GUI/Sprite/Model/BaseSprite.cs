using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Interface;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using PawnShop.Script.Model.GUI.Sprite.UIState;
using PawnShop.Script.Model.GUI.Sprite.UIStateData;
using PawnShop.Script.Model.GUI.Component;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;

namespace PawnShop.Script.Model.GUI.Sprite.Model
{
    public abstract class BaseSprite<T, U, V> : VisibleComponent
        where T : SpriteUIState<U, V>
        where U : SpriteUIStateData<V>
    {
        private T UIState { get; }

        public V Content => UIState.Content;

        public BaseSprite(Position position, T UIState) : base(position)
        {
            this.UIState = UIState;
        }
    }
}

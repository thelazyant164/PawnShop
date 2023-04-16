using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Interface;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using PawnShop.Script.Model.GUI.Sprite.State;
using PawnShop.Script.Model.GUI.Sprite.UIState;
using PawnShop.Script.Model.GUI.Sprite.UIStateData;
using PawnShop.Script.Model.GUI.Component;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IImage;

namespace PawnShop.Script.Model.GUI.Sprite.Model
{
    public abstract class BaseSprite<U, V, T> : InteractableComponent
        where U : SpriteUIState<V, T>
        where V : SpriteUIStateData<T>
    {
        public event EventHandler? OnActivate;
        public event EventHandler? OnDeactivate;
        public override event EventHandler? OnSelect;
        public override event EventHandler? OnDeselect;

        protected SpriteState state { get; } = new SpriteState();

        protected U UIState { get; set; }

        public T GetContent => UIState.GetContent(state.State);

        public BaseSprite(PrimitiveRect rect, U UIState) : base(rect)
        {
            this.UIState = UIState;
        }

        public override void Update()
        {
            if (!Active)
            {
                state.Deactivate(() =>
                {
                    Console.WriteLine("Deactivated sprite.");
                    // TODO: VFX...
                });
                return;
            }
            else
            {
                state.Activate(() =>
                {
                    Console.WriteLine("Deactivated sprite.");
                    // TODO: VFX...
                });
                return;
            }
        }
    }
}

using SplashKitSDK;
using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Model.GUI.Component;
using PawnShop.Script.Model.GUI.Button.State;
using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;

namespace PawnShop.Script.Model.GUI.Button.Model
{
    public abstract class BaseButton<U, V> : InteractableComponent, IClickable, IHoverable
        where U : SpriteUIState<V>
        where V : ButtonUIStateData
    {
        public virtual event EventHandler? OnClick;
        public virtual event EventHandler? OnHover;
        public override event EventHandler? OnSelect;
        public override event EventHandler? OnDeselect;

        protected ButtonState state { get; } = new ButtonState();

        protected U? UIState { get; set; }

        public BaseButton(PrimitiveRect rect, U? UIState = null) : base(rect)
        {
            this.UIState = UIState;
        }


        public virtual bool IsMouseDown()
        {
            return SplashKit.MouseDown(MouseButton.LeftButton);
        }

        public override void Update()
        {
            if (!Active)
            {
                state.Deactivate(() =>
                {
                    Console.WriteLine("Deactivated button.");
                });
                return;
            }
            Point2D mousePosition = SplashKit.MousePosition();
            if (IsCursorOver(mousePosition))
            {
                OnHover?.Invoke(this, EventArgs.Empty);
                if (IsMouseDown())
                {
                    state.Click(() => OnClick?.Invoke(
                        this,
                        EventArgs.Empty
                    ));
                }
                else
                {
                    state.Select(
                        () =>
                            OnSelect?.Invoke(
                                this,
                                EventArgs.Empty
                            )
                    );
                }
            }
            else
            {
                state.Deselect(
                    () => OnDeselect?.Invoke(this, EventArgs.Empty)
                );
            }
        }
    }
}

using PawnShop.Script.Model.GUI.Button.State;
using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using PawnShop.Script.Model.GUI.Component;
using PawnShop.Script.Model.GUI.Interface;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;

namespace PawnShop.Script.Model.GUI.Button.Model
{
    public abstract class BaseButton<U, V> : InteractableComponent, IClickable
        where U : ButtonUIState<V>
        where V : ButtonUIStateData
    {
        public virtual event EventHandler? OnClick;
        public override event EventHandler? OnSelect;
        public override event EventHandler? OnDeselect;
        public override event EventHandler? OnActivate;
        public override event EventHandler? OnDeactivate;

        protected ButtonState state { get; } = new ButtonState();

        protected U? UIState { get; set; }

        public BaseButton(PrimitiveRect rect, U? UIState = null) : base(rect)
        {
            this.UIState = UIState;
        }

        public override void Activate()
        {
            base.Activate();
            state.Activate(() =>
            {
                OnActivate?.Invoke(this, EventArgs.Empty);
            });
        }

        public override void Deactivate()
        {
            base.Deactivate();
            state.Deactivate(() =>
            {
                OnDeactivate?.Invoke(this, EventArgs.Empty);
            });
        }

        public virtual bool IsMouseDown() => SplashKit.MouseDown(MouseButton.LeftButton);

        public override void Update()
        {
            if (!Active)
            {
                return;
            }
            Point2D mousePosition = SplashKit.MousePosition();
            if (IsCursorOver(mousePosition))
            {
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

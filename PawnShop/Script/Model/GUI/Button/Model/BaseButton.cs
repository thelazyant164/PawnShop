using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Interface;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using static PawnShop.Script.Model.GUI.Interface.IClickable;
using static PawnShop.Script.Model.GUI.Interface.IHoverable;
using static PawnShop.Script.Model.GUI.Interface.ISelectable;
using PawnShop.Script.Manager.GUI;
using PawnShop.Script.Model.GUI.Button.State;
using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.Button.Model
{
    public abstract class BaseButton<T, U, V> : IClickable, IHoverable, ISelectable
        where T : State.ButtonState, new()
        where U : ButtonUIState<V>
        where V : ButtonUIStateData
    {
        public virtual event EventHandler<OnMouseEventArgs> OnClick;
        public virtual event EventHandler<OnHoverEventArgs> OnHover;
        public virtual event EventHandler<OnSelectEventArgs> OnSelect;
        public virtual event EventHandler<OnDeselectEventArgs> OnDeselect;

        public virtual int X { get; protected set; }

        public virtual int Y { get; protected set; }

        public virtual Point2D Origin => new Point2D { X = X, Y = Y };

        public virtual int Width { get; protected set; }

        public virtual int Height { get; protected set; }

        public virtual Rectangle Rectangle
        {
            get =>
                new Rectangle
                {
                    X = X,
                    Y = Y,
                    Width = Width,
                    Height = Height
                };
        }

        public virtual bool Active { get; protected set; } = true;

        public virtual bool Visible { get; protected set; } = true;

        public virtual bool IsSelected { get; protected set; } = false;

        protected T state { get; } = new T();

        protected U UIState { get; set; }

        public BaseButton(PrimitiveRect rect, U UIState)
        {
            X = rect.Origin.X;
            Y = rect.Origin.Y;
            Width = rect.Dimension.Width;
            Height = rect.Dimension.Height;
            this.UIState = UIState;
        }

        public virtual void Activate()
        {
            Active = true;
        }

        public virtual void Deactivate()
        {
            Active = false;
        }

        public virtual void Show()
        {
            Visible = true;
        }

        public virtual void Hide()
        {
            Visible = false;
        }

        public virtual bool IsCursorOver(Point2D mousePosition)
        {
            bool isOverHorizontally = X <= mousePosition.X && mousePosition.X <= X + Width;
            bool isOverVertically = Y <= mousePosition.Y && mousePosition.Y <= Y + Height;
            return isOverHorizontally && isOverVertically;
        }

        public virtual bool IsMouseDown()
        {
            return SplashKit.MouseDown(MouseButton.LeftButton);
        }

        public virtual void Update()
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
                state.Select(
                    () =>
                        OnSelect?.Invoke(
                            this,
                            new OnSelectEventArgs
                            {
                                Selected = this,
                                MousePosition = mousePosition
                            }
                        )
                );
                OnHover?.Invoke(this, new OnHoverEventArgs { MousePosition = mousePosition });
                if (IsMouseDown())
                {
                    state.Click(
                        () =>
                            OnClick?.Invoke(
                                this,
                                new OnMouseEventArgs
                                {
                                    MousePosition = mousePosition
                                }
                            )
                    );
                }
            }
            else
            {
                state.Deselect(
                    () => OnDeselect?.Invoke(this, new OnDeselectEventArgs { Deselected = this })
                );
            }
        }

        public virtual void Draw()
        {
            if (!Visible)
                return;
            
        }
    }
}

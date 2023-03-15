using PawnShop.Script.Manager.GUI;
using PawnShop.Script.Model.GUI.Button.Model;
using PawnShop.Script.Model.GUI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Interface.IClickable;
using static PawnShop.Script.Model.GUI.Interface.IHoverable;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using PawnShop.Script.Model.GUI.PopUp.Content;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.PopUp.Model
{
    public abstract class BasePopUp<T> : IVisible where T : PopUpContent
    {
        public class OnDismissEventArgs : EventArgs
        {
            public BasePopUp<T> Dismissed;
        }

        public virtual event EventHandler<OnDismissEventArgs> OnDismiss;

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

        protected T content { get; set; }

        public BasePopUp(PrimitiveRect rect, T content)
        {
            X = rect.Origin.X;
            Y = rect.Origin.Y;
            Width = rect.Dimension.Width;
            Height = rect.Dimension.Height;
            this.content = content;
            content.Bind(() =>
            {
                OnDismiss?.Invoke(this, new OnDismissEventArgs { Dismissed = this });
                Hide();
                Deactivate();
            });
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

        public virtual void Update()
        {
            if (!Active)
            {
                return;
            }
            content.Update();
        }

        public virtual void Draw()
        {
            if (!Visible)
                return;
            content.Draw();
        }
    }
}

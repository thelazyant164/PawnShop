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
using PawnShop.Script.Model.GUI.Component;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.PopUp.Model
{
    public abstract class BasePopUp<T> : InteractableComponent where T : PopUpContent
    {
        public class OnDismissEventArgs : EventArgs
        {
            public BasePopUp<T> Dismissed;
        }

        public virtual event EventHandler<OnDismissEventArgs>? OnDismiss;
        public override event EventHandler? OnSelect;
        public override event EventHandler? OnDeselect;

        protected T content { get; set; }

        public BasePopUp(PrimitiveRect rect, T content) : base(rect) 
        {
            this.content = content;
            content.Bind(() =>
            {
                OnDismiss?.Invoke(this, new OnDismissEventArgs { Dismissed = this });
                Hide();
                Deactivate();
            });
        }

        public override void Update()
        {
            if (!Active)
            {
                return;
            }
            content.Update();
        }

        public override void Draw()
        {
            if (!Visible)
                return;
            content.Draw();
        }
    }
}

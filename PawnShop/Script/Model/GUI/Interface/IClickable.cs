using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IClickable : IInteractable, IPrimitiveRect
    {
        public class OnMouseEventArgs : EventArgs
        {
            public Point2D MousePosition;
        }

        public abstract event EventHandler<OnMouseEventArgs> OnClick;

        public abstract bool IsMouseDown();
    }
}

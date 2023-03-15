using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IHoverable : IPrimitiveRect, IInteractable
    {
        public class OnHoverEventArgs : EventArgs
        {
            public Point2D MousePosition;
        }

        public abstract event EventHandler<OnHoverEventArgs> OnHover;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IDraggable : IInteractable
    {
        public class OnMouseDragEventArgs : EventArgs
        {
            public Point2D MousePosition;
        }

        public abstract event EventHandler OnMouseDown;
        public abstract event EventHandler OnMouseDrag;
        public abstract event EventHandler OnMouseRelease;

        public abstract bool IsDragging { get; }
    }
}

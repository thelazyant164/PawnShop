using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface ISelectable : IInteractable
    {
        public class OnSelectEventArgs : EventArgs
        {
            public ISelectable Selected;
            public Point2D MousePosition;
        }

        public class OnDeselectEventArgs : EventArgs
        {
            public ISelectable Deselected;
        }

        public abstract event EventHandler<OnSelectEventArgs> OnSelect;
        public abstract event EventHandler<OnDeselectEventArgs> OnDeselect;

        public abstract bool IsSelected { get; }
    }
}

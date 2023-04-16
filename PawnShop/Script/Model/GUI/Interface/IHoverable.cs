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
        public abstract event EventHandler OnHover;
    }
}

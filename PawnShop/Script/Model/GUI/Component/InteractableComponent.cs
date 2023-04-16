using PawnShop.Script.Model.GUI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;

namespace PawnShop.Script.Model.GUI.Component
{
    public abstract class InteractableComponent : RectangularComponent, IInteractable
    {
        public abstract event EventHandler? OnSelect;
        public abstract event EventHandler? OnDeselect;

        public virtual bool Active { get; protected set; } = true;

        public virtual bool IsSelected { get; protected set; } = false;

        public InteractableComponent(PrimitiveRect rect) : base(rect) { }

        public virtual void Activate()
        {
            Active = true;
        }

        public virtual void Deactivate()
        {
            Active = false;
        }

        public abstract void Update();
    }
}

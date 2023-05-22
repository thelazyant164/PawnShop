using PawnShop.Script.Model.GUI.Interface;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;

namespace PawnShop.Script.Model.GUI.Component
{
    public abstract class InteractableComponent : RectangularComponent, IInteractable
    {
        public virtual event EventHandler? OnSelect;
        public virtual event EventHandler? OnDeselect;
        public virtual event EventHandler? OnActivate;
        public virtual event EventHandler? OnDeactivate;

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

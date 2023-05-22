namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IInteractable : IVisible
    {
        public abstract event EventHandler OnSelect;
        public abstract event EventHandler OnDeselect;
        public abstract event EventHandler OnActivate;
        public abstract event EventHandler OnDeactivate;

        public abstract bool IsSelected { get; }

        public abstract bool Active { get; }

        public abstract void Activate();

        public abstract void Deactivate();

        public abstract void Update();
    }
}

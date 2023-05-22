namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IVisible : IPrimitive
    {
        public abstract bool Visible { get; }

        public abstract void Show();

        public abstract void Hide();

        public abstract void Draw();
    }
}

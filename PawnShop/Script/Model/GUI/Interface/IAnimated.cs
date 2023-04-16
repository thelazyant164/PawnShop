namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IAnimated : IVisible
    {
        public abstract double TimeElapsed { get; }

        public abstract double LifeSpan { get; }
    }
}

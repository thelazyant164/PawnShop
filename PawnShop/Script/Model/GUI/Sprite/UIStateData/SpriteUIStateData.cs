namespace PawnShop.Script.Model.GUI.Sprite.UIStateData
{
    public abstract class SpriteUIStateData<T>
    {
        private readonly List<T> content = new List<T>();
        public IReadOnlyList<T> Content => content.AsReadOnly();

        public SpriteUIStateData(T[] spriteStages)
        {
            content.AddRange(spriteStages);
        }
    }
}

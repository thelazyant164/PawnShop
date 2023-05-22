using PawnShop.Script.Model.GUI.Sprite.UIStateData;

namespace PawnShop.Script.Model.GUI.Sprite.UIState
{
    public abstract class SpriteUIState<T, U> where T : SpriteUIStateData<U>
    {
        private static readonly int animationFramerate = 144;

        private T UIStateData { get; }
        private int counter = 0;
        private int frame => counter / animationFramerate;

        public virtual U Content
        {
            get
            {
                counter++;
                if (frame >= UIStateData.Content.Count) counter = 0;
                return UIStateData.Content[frame];
            }
        }

        public SpriteUIState(T UIStateData)
        {
            this.UIStateData = UIStateData;
        }
    }
}

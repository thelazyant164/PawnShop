using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Sprite.State.SpriteState;
using PawnShop.Script.Model.GUI.Sprite.UIStateData;

namespace PawnShop.Script.Model.GUI.Sprite.UIState
{
    public abstract class SpriteUIState<T, U> where T : SpriteUIStateData<U>
    {
        protected virtual T ActiveState { get; set; }

        protected virtual T InactiveState { get; set; }

        private int currentFrame = 0;

        public SpriteUIState(T activeUI, T inactiveUI)
        {
            ActiveState = activeUI;
            InactiveState = inactiveUI;
        }

        protected virtual T GetState(SelectionState state)
        {
            switch (state)
            {
                case SelectionState.Inactive:
                    return InactiveState;
                case SelectionState.Active:
                    return ActiveState;
                default:
                    throw new Exception("Illegal button selection state");
            }
        }

        public virtual U GetContent(SelectionState state)
        {
            IReadOnlyList<U> content = GetState(state).Content;
            currentFrame++;
            if (currentFrame > content.Count) currentFrame = 0;
            return content[currentFrame];
        }
    }
}

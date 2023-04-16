using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.GUI.Sprite.State
{
    public class SpriteState
    {
        public enum SelectionState
        {
            Inactive,
            Active
        }

        public virtual SelectionState State { get; protected set; } = SelectionState.Active;

        public SpriteState() { }

        public virtual void Activate(Action _activateDelegate)
        {
            switch (State)
            {
                case SelectionState.Active:
                    return;
                default:
                    State = SelectionState.Active;
                    _activateDelegate();
                    break;
            }
        }

        public virtual void Deactivate(Action _deactivateDelegate)
        {
            switch (State)
            {
                case SelectionState.Inactive:
                    return;
                default:
                    State = SelectionState.Inactive;
                    _deactivateDelegate();
                    break;
            }
        }
    }
}

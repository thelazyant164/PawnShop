using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.GUI.Button.State
{
    public class ButtonState
    {
        public enum SelectionState
        {
            Inactive,
            Active,
            Selected,
            Pressed,
        }

        public virtual SelectionState State { get; protected set; } = SelectionState.Active;

        public ButtonState() { }

        public virtual void Click(Action _mouseDownDelegate)
        {
            switch (State)
            {
                case SelectionState.Inactive
                or SelectionState.Pressed:
                    return;
                case SelectionState.Active
                or SelectionState.Selected:
                    State = SelectionState.Pressed;
                    _mouseDownDelegate();
                    break;
            }
        }

        public virtual void Activate(Action _activateDelegate)
        {
            switch (State)
            {
                case SelectionState.Pressed
                or SelectionState.Active
                or SelectionState.Selected:
                    return;
                case SelectionState.Inactive:
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
                case SelectionState.Pressed
                or SelectionState.Active
                or SelectionState.Selected:
                    State = SelectionState.Inactive;
                    _deactivateDelegate();
                    break;
            }
        }

        public virtual void Select(Action _selectDelegate)
        {
            switch (State)
            {
                case SelectionState.Inactive
                or SelectionState.Selected:
                    return;
                case SelectionState.Active 
                or SelectionState.Pressed:
                    State = SelectionState.Selected;
                    _selectDelegate();
                    break;
            }
        }

        public virtual void Deselect(Action _deselectDelegate)
        {
            switch (State)
            {
                case SelectionState.Inactive
                or SelectionState.Active:
                    return;
                case SelectionState.Selected
                or SelectionState.Pressed:
                    State = SelectionState.Active;
                    _deselectDelegate();
                    break;
            }
        }
    }
}

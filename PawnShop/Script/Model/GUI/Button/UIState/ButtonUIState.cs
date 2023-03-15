using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Button.State.ButtonState;
using PawnShop.Script.Model.GUI.Button.UIStateData;

namespace PawnShop.Script.Model.GUI.Button.UIState
{
    public abstract class ButtonUIState<T> where T : ButtonUIStateData
    {
        protected virtual T ActiveState { get; set; }

        protected virtual T InactiveState { get; set; }

        protected virtual T PressedState { get; set; }

        protected virtual T SelectedState { get; set; }

        public ButtonUIState(T activeUI, T inactiveUI, T pressedUI, T selectedState)
        {
            ActiveState = activeUI;
            InactiveState = inactiveUI;
            PressedState = pressedUI;
            SelectedState = selectedState;
        }

        public virtual T GetState(SelectionState state)
        {
            switch (state)
            {
                case SelectionState.Inactive:
                    return InactiveState;
                case SelectionState.Active:
                    return ActiveState;
                case SelectionState.Selected:
                    return PressedState;
                case SelectionState.Pressed:
                    return PressedState;
                default:
                    throw new Exception("Illegal button selection state");
            }
        }
    }
}

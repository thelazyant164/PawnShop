using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Button.UIStateData;

namespace PawnShop.Script.Model.GUI.Button.UIState
{
    public sealed class TextButtonUIState : ButtonUIState<TextButtonUIStateData>
    {
        public TextButtonUIState(
            TextButtonUIStateData activeUI,
            TextButtonUIStateData inactiveUI,
            TextButtonUIStateData pressedUI,
            TextButtonUIStateData selectedUI
        ) : base(activeUI, inactiveUI, pressedUI, selectedUI) { }
    }
}

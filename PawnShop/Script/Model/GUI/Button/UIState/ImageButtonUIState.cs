using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Button.UIStateData;

namespace PawnShop.Script.Model.GUI.Button.UIState
{
    public sealed class ImageButtonUIState : SpriteUIState<ImageButtonUIStateData>
    {
        public ImageButtonUIState(
            ImageButtonUIStateData activeUI,
            ImageButtonUIStateData inactiveUI,
            ImageButtonUIStateData pressedUI,
            ImageButtonUIStateData selectedUI
        ) : base(activeUI, inactiveUI, pressedUI, selectedUI) { }
    }
}

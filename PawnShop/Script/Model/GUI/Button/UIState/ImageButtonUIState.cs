using PawnShop.Script.Model.GUI.Button.UIStateData;

namespace PawnShop.Script.Model.GUI.Button.UIState
{
    public sealed class ImageButtonUIState : ButtonUIState<ImageButtonUIStateData>
    {
        public ImageButtonUIState(
            ImageButtonUIStateData activeUI,
            ImageButtonUIStateData inactiveUI,
            ImageButtonUIStateData pressedUI,
            ImageButtonUIStateData selectedUI
        ) : base(activeUI, inactiveUI, pressedUI, selectedUI) { }
    }
}

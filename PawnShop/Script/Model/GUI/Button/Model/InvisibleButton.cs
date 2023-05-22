using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;

namespace PawnShop.Script.Model.GUI.Button.Model
{
    public sealed class InvisibleButton : BaseButton<ButtonUIState<ButtonUIStateData>, ButtonUIStateData>
    {
        public InvisibleButton(PrimitiveRect rect)
            : base(rect) { }

        public override void Draw() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Button.State;
using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;

namespace PawnShop.Script.Model.GUI.Button.Model
{
    public sealed class InvisibleButton : BaseButton<SpriteUIState<ButtonUIStateData>, ButtonUIStateData>
    {
        public InvisibleButton(PrimitiveRect rect)
            : base(rect) { }

        public override void Draw() { }
    }
}

using PawnShop.Script.Model.GUI.PopUp.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;

namespace PawnShop.Script.Model.GUI.PopUp.Model
{
    public sealed class TextPopUp : BasePopUp<TextPopUpContent>
    {
        public TextPopUp(PrimitiveRect rect, TextPopUpContent content) : base(rect, content) { }
    }
}

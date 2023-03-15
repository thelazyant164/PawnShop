using PawnShop.Script.Model.GUI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Interface.IText;

namespace PawnShop.Script.Model.GUI.PopUp.Content
{
    public sealed class TextPopUpContent : PopUpContent
    {
        private readonly IText title;
        private readonly IText text;

        public TextPopUpContent(IText title, IText text, params IClickable[] buttons)
            : base(buttons)
        {
            this.title = title;
            this.text = text;
        }

        public override void Draw()
        {
            title.Draw();
            text.Draw();
            base.Draw();
        }
    }
}

using PawnShop.Script.Model.GUI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Interface.IClickable;

namespace PawnShop.Script.Model.GUI.PopUp.Content
{
    public abstract class PopUpContent
    {
        private readonly List<IClickable> buttons;
        protected Action? _onClose { get; set; }

        public PopUpContent(params IClickable[] buttons)
        {
            this.buttons = new List<IClickable>();
            this.buttons.AddRange(buttons);
            foreach (IClickable button in this.buttons)
            {
                button.OnClick += Close;
            }
        }

        public virtual void Bind(Action onClose)
        {
            _onClose = onClose;
        }

        public virtual void Update()
        {
            foreach (IClickable button in buttons)
            {
                button.Update();
            }
        }

        public virtual void Draw()
        {
            foreach (IClickable button in buttons)
            {
                button.Draw();
            }
        }

        protected virtual void Close(object? sender, EventArgs eventArgs)
        {
            foreach (IClickable button in buttons)
            {
                button.OnClick -= Close;
            }
            buttons.Clear();
            _onClose!();
        }
    }
}

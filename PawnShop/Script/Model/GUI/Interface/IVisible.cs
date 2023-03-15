using PawnShop.Script.Manager.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IVisible : IPrimitive
    {
        public abstract bool Visible { get; }

        public abstract void Show();

        public abstract void Hide();

        public abstract void Draw();
    }
}

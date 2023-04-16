using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IMovable
    {
        public abstract void OnMove(object? sender, Position position);
    }
}

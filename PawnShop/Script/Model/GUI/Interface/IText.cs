using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IText : IVisible
    {
        public abstract string Content { get; }
    }
}

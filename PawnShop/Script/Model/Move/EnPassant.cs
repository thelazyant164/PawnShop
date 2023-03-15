using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.Move
{
    public class EnPassant : Capture
    {
        public EnPassant() : base()
        {
            Type = MoveType.EnPassant;
        }
    }
}

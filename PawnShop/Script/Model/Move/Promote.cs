using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.Move
{
    public class Promote : BaseMove
    {
        public Promote() : base()
        {
            Type = MoveType.Promote;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.Move
{
    public class Attack : BaseMove
    {
        public Attack() : base()
        {
            Type = MoveType.Attack;
        }
    }
}

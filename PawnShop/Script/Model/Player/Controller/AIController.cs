using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.Model.Player.Controller
{
    public class AIController : PlayerController {
        public AIController(PlayerSide side) : base(side) { }
    }
}

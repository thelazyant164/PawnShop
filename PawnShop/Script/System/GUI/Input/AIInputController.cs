using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Player;

namespace PawnShop.Script.System.GUI.Input
{
    public class AIInputController : BaseInputController
    {
        public AIInputController(BasePlayer.PlayerSide side) : base(side) { }
    }
}

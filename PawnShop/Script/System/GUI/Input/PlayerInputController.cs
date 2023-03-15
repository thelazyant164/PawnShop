using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Player;

namespace PawnShop.Script.System.GUI.Input
{
    public class PlayerInputController : BaseInputController
    {
        public PlayerInputController(BasePlayer.PlayerSide side) : base(side) { }
    }
}

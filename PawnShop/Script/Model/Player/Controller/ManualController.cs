using PawnShop.Script.System.GUI.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.Model.Player.Controller
{
    public class ManualController : PlayerController 
    { 
        public ManualController(BasePlayer player) : base(player) { }
    }
}

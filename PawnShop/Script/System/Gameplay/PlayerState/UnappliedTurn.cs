using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Utility;

namespace PawnShop.Script.System.Gameplay.PlayerState
{
    public class UnappliedTurn : PlayerState
    {
        public UnappliedTurn(PlayerStateSystem playerStateSystem) : base(playerStateSystem) { }

        public override void Progress() { }
    }
}

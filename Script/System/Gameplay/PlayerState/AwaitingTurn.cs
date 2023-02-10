using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessUltimate.Script.Utility;

namespace ChessUltimate.Script.System.Gameplay.GameState
{
    public class AwaitingTurn : PlayerState
    {
        public AwaitingTurn(PlayerStateSystem playerStateSystem) : base(playerStateSystem) { }

        public override void Progress() { }
    }
}

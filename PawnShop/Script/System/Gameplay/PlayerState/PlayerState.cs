using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Utility;

namespace PawnShop.Script.System.Gameplay.PlayerState
{
    public abstract class PlayerState : State
    {
        public PlayerState(PlayerStateSystem playerStateSystem) : base(playerStateSystem) { }

        protected PlayerStateSystem PlayerStateSystem
        {
            get { return (PlayerStateSystem)_stateMachine; }
        }

        public override void Progress() { }
    }
}

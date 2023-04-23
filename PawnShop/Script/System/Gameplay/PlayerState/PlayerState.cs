using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Utility;

namespace PawnShop.Script.System.Gameplay.PlayerState
{
    public abstract class PlayerState : State
    {
        public PlayerState(PlayerStateSystem playerStateSystem) : base(playerStateSystem) 
        {
            
        }

        protected PlayerStateSystem PlayerStateSystem
        {
            get { return (PlayerStateSystem)stateMachine; }
        }

        public override void Start() { }

        public override void Progress() { }

        public override void Terminate() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Utility;

namespace PawnShop.Script.System.Gameplay.PlayerState
{
    public class PlayerStateSystem : StateMachine
    {
        public PlayerState CurrentPlayerState
        {
            get => (PlayerState)CurrentState;
        }

        public void SetPlayerState(PlayerState newPlayerState)
        {
            SetState(newPlayerState);
        }
    }
}

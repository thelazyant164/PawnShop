using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessUltimate.Script.Utility;

namespace ChessUltimate.Script.System.Gameplay.GameState
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

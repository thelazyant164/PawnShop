using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Utility;

namespace PawnShop.Script.System.Gameplay.GameState
{
    public class GameStateSystem : StateMachine
    {
        public GameState CurrentGameState
        {
            get => (GameState)CurrentState;
        }

        public void SetGameState(GameState newGameState)
        {
            SetState(newGameState);
        }
    }
}

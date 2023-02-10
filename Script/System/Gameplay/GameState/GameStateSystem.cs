using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessUltimate.Script.Utility;

namespace ChessUltimate.Script.System.Gameplay.GameState
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessUltimate.Script.Utility;

namespace ChessUltimate.Script.System.Gameplay.GameState
{
    public abstract class GameState : State
    {
        public GameState(GameStateSystem gameStateSystem) : base(gameStateSystem) { }

        protected GameStateSystem GameStateSystem
        {
            get { return (GameStateSystem)_stateMachine; }
        }

        public override void Progress() { }
    }
}

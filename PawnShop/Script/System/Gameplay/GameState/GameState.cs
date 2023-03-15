using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Utility;

namespace PawnShop.Script.System.Gameplay.GameState
{
    public abstract class GameState : State
    {
        public GameState(PieceStateSystem gameStateSystem) : base(gameStateSystem) { }

        protected PieceStateSystem GameStateSystem
        {
            get { return (PieceStateSystem)_stateMachine; }
        }

        public override void Progress() { }
    }
}

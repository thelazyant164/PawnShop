using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessUltimate.Script.System.Gameplay.GameState
{
    public class GameInProgress : GameState
    {
        public GameInProgress(GameStateSystem gameStateSystem) : base(gameStateSystem) { }

        public override void Progress()
        {
            base.Progress();
        }
    }
}

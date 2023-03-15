using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.System.Gameplay.GameState
{
    public class Checkmate : GameState
    {
        public Checkmate(PieceStateSystem gameStateSystem) : base(gameStateSystem) { }

        public override void Progress()
        {
            base.Progress();
        }
    }
}

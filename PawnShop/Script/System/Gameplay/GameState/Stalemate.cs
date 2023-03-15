using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.System.Gameplay.GameState
{
    public class Stalemate : GameState
    {
        public Stalemate(PieceStateSystem gameStateSystem) : base(gameStateSystem) { }

        public override void Progress()
        {
            base.Progress();
        }
    }
}

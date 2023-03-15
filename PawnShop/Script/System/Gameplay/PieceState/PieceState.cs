using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Utility;

namespace PawnShop.Script.System.Gameplay.PieceState
{
    public abstract class PieceState : State
    {
        public PieceState(PieceStateSystem pieceStateSystem) : base(pieceStateSystem) { }

        protected PieceStateSystem PieceStateSystem
        {
            get { return (PieceStateSystem)_stateMachine; }
        }

        public override void Progress() { }
    }
}

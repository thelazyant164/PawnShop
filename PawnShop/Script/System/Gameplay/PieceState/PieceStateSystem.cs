using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Utility;

namespace PawnShop.Script.System.Gameplay.PieceState
{
    public class PieceStateSystem : StateMachine
    {
        public PieceState CurrentPieceState
        {
            get => (PieceState)CurrentState;
        }

        public void SetPieceState(PieceState newPieceState)
        {
            SetState(newPieceState);
        }
    }
}

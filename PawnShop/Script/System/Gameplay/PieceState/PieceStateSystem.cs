using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using static PawnShop.Script.Model.Player.BasePlayer;
using PawnShop.Script.Utility;
using PawnShop.Script.Model.Cache;
using static PawnShop.Script.Model.Piece.BasePiece;
using PawnShop.Script.Model.Piece;

namespace PawnShop.Script.System.Gameplay.PieceState
{
    public class PieceStateSystem : StateMachine
    {
        public TurnSystem TurnSystem { get; private set; }
        public BasePiece Piece { get; private set; }
        public SelectionCache Cache { get; private set; }

        public PieceState CurrentPieceState
        {
            get => (PieceState)CurrentState;
        }

        public PieceStateSystem(BasePiece piece)
        {
            Piece = piece;
            TurnSystem = GameManager.Instance.TurnSystem!;
            Cache = TurnSystem.GetPlayer(Piece.Side).Cache;
            SetPieceState(new InactivePiece(this));
        }

        public void SetPieceState(PieceState newPieceState)
        {
            SetState(newPieceState);
        }
    }
}

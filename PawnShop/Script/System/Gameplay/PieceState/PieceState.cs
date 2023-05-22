using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player.Cache;
using PawnShop.Script.Utility;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.System.Gameplay.PieceState
{
    public abstract class PieceState : State
    {
        protected BasePiece piece => PieceStateSystem.Piece;
        protected PlayerSide currentTurn => PieceStateSystem.PlayerManager.CurrentTurn;
        protected SelectionCache cache => PieceStateSystem.Cache;
        protected virtual BasePiece? selectedPiece => PieceStateSystem.Cache.SelectedPiece;
        protected bool buyMode => PieceStateSystem.Cache.BuyMode;

        public PieceState(PieceStateSystem pieceStateSystem) : base(pieceStateSystem) { }

        protected PieceStateSystem PieceStateSystem
        {
            get { return (PieceStateSystem)stateMachine; }
        }

        public override void Start() { }

        public override void Progress() { }

        public override void Terminate() { }
    }
}

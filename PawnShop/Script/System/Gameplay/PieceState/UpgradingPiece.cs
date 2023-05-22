using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using static PawnShop.Script.Model.Board.Position.HighlightType;

namespace PawnShop.Script.System.Gameplay.PieceState
{
    public sealed class UpgradingPiece : PieceState
    {
        public static event EventHandler? OnEnter;
        public static event EventHandler? OnExit;

        protected override BasePiece selectedPiece => base.selectedPiece!;
        private readonly Position currentPosition;
        private bool upgradeMode => PieceStateSystem.Cache.UpgradeMode;

        public UpgradingPiece(PieceStateSystem pieceStateSystem) : base(pieceStateSystem)
        {
            GameManager.Instance.Board.TryLocate(PieceStateSystem.Piece, out Position? currentPos);
            currentPosition = currentPos!;
        }

        public override void Start()
        {
            currentPosition.InvokeOnHighlight(this, Selected);
            OnEnter?.Invoke(this, EventArgs.Empty);
        }

        public override void Progress()
        {
            if (!PieceStateSystem.Piece.Equals(selectedPiece))
            {
                PieceStateSystem.SetPieceState(new ActivePiece(PieceStateSystem));
            }
            else if (!upgradeMode)
            {
                PieceStateSystem.SetPieceState(new SelectedPiece(PieceStateSystem));
            }
            if (PieceStateSystem.PlayerManager.CurrentTurn != piece.Side)
            {
                PieceStateSystem.SetPieceState(new InactivePiece(PieceStateSystem));
            }
        }

        public override void Terminate()
        {
            currentPosition.InvokeOnHighlight(this, None);
            OnExit?.Invoke(this, EventArgs.Empty);
            cache.ExitUpgradeMode();
        }
    }
}

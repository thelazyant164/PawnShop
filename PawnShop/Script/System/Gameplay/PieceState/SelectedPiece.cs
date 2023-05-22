using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Move;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player;
using static PawnShop.Script.Model.Board.Position.HighlightType;

namespace PawnShop.Script.System.Gameplay.PieceState
{
    public sealed class SelectedPiece : PieceState
    {
        public static event EventHandler? OnEnableUpgradeMode;
        public static event EventHandler? OnDisableUpgradeMode;

        private BasePlayer player => GameManager.Instance.PlayerManager.GetPlayer(piece.Side);
        protected override BasePiece selectedPiece => base.selectedPiece!;
        private readonly Position currentPosition;
        private readonly HashSet<Position>? highlightedPositions;
        private bool upgradeMode => PieceStateSystem.Cache.UpgradeMode;

        public SelectedPiece(PieceStateSystem pieceStateSystem) : base(pieceStateSystem)
        {
            GameManager.Instance.Board.TryLocate(PieceStateSystem.Piece, out Position? currentPos);
            currentPosition = currentPos!;
            highlightedPositions = selectedPiece.GetAllMoves() as HashSet<Position>;
        }

        public override void Start()
        {
            currentPosition.InvokeOnHighlight(this, Selected);
            if (selectedPiece.Upgradeable && player.Currency >= Upgrade.MinCost)
            {
                OnEnableUpgradeMode?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                OnDisableUpgradeMode?.Invoke(this, EventArgs.Empty);
            }
            if (highlightedPositions == null) return;
            foreach (Position position in highlightedPositions)
            {
                position.ToggleResponseToClick(true);
                if (position.IsOccupied)
                {
                    position.InvokeOnHighlight(selectedPiece, Capturable);
                }
                else
                {
                    position.InvokeOnHighlight(selectedPiece, Movable);
                }
            }
        }

        public override void Progress()
        {
            if (!PieceStateSystem.Piece.Equals(selectedPiece))
            {
                PieceStateSystem.SetPieceState(new ActivePiece(PieceStateSystem));
            }
            if (PieceStateSystem.PlayerManager.CurrentTurn != piece.Side)
            {
                PieceStateSystem.SetPieceState(new InactivePiece(PieceStateSystem));
            }
            if (upgradeMode && piece.Upgradeable)
            {
                PieceStateSystem.SetPieceState(new UpgradingPiece(PieceStateSystem));
            }
        }

        public override void Terminate()
        {
            currentPosition.InvokeOnHighlight(this, None);
            if (highlightedPositions == null) return;
            foreach (Position position in highlightedPositions)
            {
                position.ToggleResponseToClick(false);
                position.InvokeOnHighlight(selectedPiece, None);
            }
            if (!upgradeMode)
            {
                OnDisableUpgradeMode?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}

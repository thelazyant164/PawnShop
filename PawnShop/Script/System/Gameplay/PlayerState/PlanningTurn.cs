using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Move;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player;
using static PawnShop.Script.Model.Piece.BasePiece;

namespace PawnShop.Script.System.Gameplay.PlayerState
{
    public sealed class PlanningTurn : PlayerState
    {
        public static event EventHandler? OnEnableBuyMode;
        public static event EventHandler? OnDisableBuyMode;

        private BasePlayer player => GameManager.Instance.PlayerManager
            .GetPlayer(PlayerStateSystem.Side);
        private BasePiece? piece => PlayerStateSystem.Cache.SelectedPiece;
        private Position? position => PlayerStateSystem.Cache.SelectedPosition;
        private bool buyMode => PlayerStateSystem.Cache.BuyMode;
        private bool upgradeMode => PlayerStateSystem.Cache.UpgradeMode;
        private PieceRole? upgradeRole => PlayerStateSystem.Cache.UpgradeRole;

        public PlanningTurn(PlayerStateSystem playerStateSystem) : base(playerStateSystem)
        {
        }

        public override void Start()
        {
            if (player.Currency >= Buy.Cost)
            {
                OnEnableBuyMode?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                OnDisableBuyMode?.Invoke(this, EventArgs.Empty);
            }
        }

        public override void Progress()
        {
            if (piece != null && position != null)
            {
                new Turn(PlayerStateSystem.Side, BaseMove.Plan(piece, position));
                PlayerStateSystem.SetPlayerState(new AwaitingTurn(PlayerStateSystem));
            }
            else if (upgradeMode && upgradeRole != null)
            {
                new Turn(PlayerStateSystem.Side, BaseMove.Plan(piece!, (PieceRole)upgradeRole));
                PlayerStateSystem.SetPlayerState(new AwaitingTurn(PlayerStateSystem));
            }
            else if (buyMode)
            {
                PlayerStateSystem.SetPlayerState(new BuyMode(PlayerStateSystem));
            }
        }

        public override void Terminate()
        {
            PlayerStateSystem.Cache.Clear();
        }

        public override string ToString() => $"{PlayerStateSystem.Side}'s turn";
    }
}

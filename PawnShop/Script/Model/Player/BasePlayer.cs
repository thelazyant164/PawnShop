using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player.Cache;
using PawnShop.Script.Model.Player.Controller;
using PawnShop.Script.System.Gameplay.PlayerState;
using static PawnShop.Script.Model.Piece.BasePiece;

namespace PawnShop.Script.Model.Player
{
    public class BasePlayer
    {
        public enum PlayerType
        {
            AI,
            Manual
        }

        public enum PlayerSide
        {
            White,
            Black
        }

        private readonly PlayerInfo info;
        private readonly PlayerStateSystem state;
        private readonly PlayerController controller;
        private readonly SelectionCache selectionCache;

        public PlayerSide Side => info.Side;

        public PlayerType Type => info.Type;

        public SelectionCache Cache => selectionCache;

        public IReadOnlySet<Position> Reign => info.Reign;

        public BasePiece King { get; private set; }

        public int Currency => info.Currency;

        public event EventHandler<bool>? OnToggleBuyMode;
        public event EventHandler<bool>? OnToggleUpgradeMode;
        public event EventHandler<int>? OnCoinUpdate;
        public event EventHandler<PieceRole>? OnSelectUpgradeRole;

        public BasePlayer(PlayerSide side, PlayerType type)
        {
            info = new PlayerInfo(side, type);
            switch (type)
            {
                case PlayerType.Manual:
                    controller = new ManualController(this);
                    break;
                case PlayerType.AI:
                    controller = new AIController(this);
                    break;
                default:
                    throw new Exception(
                        "Game config error - incorrect player type declaration during initialization."
                    );
            }
            selectionCache = new SelectionCache(controller);
            state = new PlayerStateSystem(Side, selectionCache, controller);
            PieceFactory.OnPieceAdd += Add;
        }

        /// <summary>
        /// Method to invoke coin1 count update programmatically.
        /// </summary>
        /// <remarks>To be called on begin of turn.</remarks>
        public void InvokeOnCoinUpdate() => OnCoinUpdate?.Invoke(this, Currency);

        /// <summary>
        /// Callback delegate to respond to user events.
        /// </summary>
        /// <remarks>Toggle the current state of buy mode.</remarks>
        public void ToggleBuyMode() => OnToggleBuyMode?.Invoke(this, !Cache.BuyMode);

        /// <summary>
        /// Callback delegate to respond to user events.
        /// </summary>
        /// <remarks>Toggle the current state of upgrade mode.</remarks>
        public void ToggleUpgradeMode() => OnToggleUpgradeMode?.Invoke(this, !Cache.UpgradeMode);

        public void SelectUpgradeRole(PieceRole role) => OnSelectUpgradeRole?.Invoke(this, role);

        private void Add(BasePiece newPiece)
        {
            if (newPiece.Side == Side)
            {
                if (newPiece.Role == PieceRole.King)
                {
                    King = newPiece;
                }
                info.Add(newPiece);
                controller.Register(newPiece);
                newPiece.OnCapture += Remove;
            }
        }

        /// <summary>
        /// Callback delegate to respond to a captured piece being restored on the board.
        /// </summary>
        /// <remarks>Register to a captured piece and unregister from restored pieces.</remarks>
        private void Restore(object? sender, BasePiece restoredPiece)
        {
            info.Add(restoredPiece);
            controller.Register(restoredPiece);
            restoredPiece.OnRestore -= Restore;
            restoredPiece.OnCapture += Remove;
        }

        private void Remove(object? sender, BasePiece capturedPiece)
        {
            info.Remove(capturedPiece);
            controller.Unregister(capturedPiece);
            capturedPiece.OnCapture -= Remove;
            capturedPiece.OnRestore += Restore;
        }

        /// <summary>
        /// Method to deduct spendings from player.
        /// </summary>
        /// <remarks>To be called by <c>Buy</c> or <c>Upgrade</c>.</remarks>
        /// <param name="coin">Number of Coins to deduct.</param>
        public void Spend(int coin)
        {
            info.Spend(coin);
            OnCoinUpdate?.Invoke(this, Currency);
        }

        /// <summary>
        /// Method to add Coins to player.
        /// </summary>
        /// <remarks>To be called by <c>Capture</c> or <c>Collect</c>.</remarks>
        /// <param name="coin">Number of Coins to add.</param>
        public void Gain(int coin)
        {
            info.Gain(coin);
            OnCoinUpdate?.Invoke(this, Currency);
        }

        public void Progress()
        {
            state.Update();
            info.Update();
        }

        public void StartTurn()
        {
            state.SetPlayerState(new PlanningTurn(state));
            InvokeOnCoinUpdate();
        }

        public bool IsUnderCheck() => King.IsEndangered();

        public bool HasValidMoves() => info.HasValidMoves;
    }
}

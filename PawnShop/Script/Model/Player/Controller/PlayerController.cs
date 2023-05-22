using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using static PawnShop.Script.Model.Piece.BasePiece;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.Model.Player.Controller
{
    public abstract class PlayerController
    {
        private PlayerSide Side { get; }
        private bool IsPlaying
            => GameManager.Instance.PlayerManager.CurrentTurn == Side;

        public event EventHandler<BasePiece>? OnSelectPiece;
        public event EventHandler<Position>? OnSelectPosition;
        public event EventHandler<bool>? OnToggleBuyMode;
        public event EventHandler<bool>? OnToggleUpgradeMode;
        public event EventHandler<PieceRole>? OnSelectUpgradeRole;

        public PlayerController(BasePlayer player)
        {
            Side = player.Side;
            player.OnToggleBuyMode += ToggleBuyMode;
            player.OnToggleUpgradeMode += ToggleUpgradeMode;
            player.OnSelectUpgradeRole += SelectUpgradeRole;
            foreach (Position position in GameManager.Instance.Board.Positions)
            {
                position.OnSelect += InvokeOnSelectPosition;
            }
        }

        public void Register(BasePiece piece) => piece.OnSelect += InvokeOnSelectPiece;

        public void Unregister(BasePiece piece) => piece.OnSelect -= InvokeOnSelectPiece;

        private void InvokeOnSelectPiece(object? sender, BasePiece piece)
            => OnSelectPiece?.Invoke(sender, piece);

        private void InvokeOnSelectPosition(object? sender, Position position)
        {
            if (IsPlaying) OnSelectPosition?.Invoke(sender, position);
        }

        private void ToggleBuyMode(object? sender, bool enable)
            => OnToggleBuyMode?.Invoke(sender, enable);

        private void ToggleUpgradeMode(object? sender, bool enable)
            => OnToggleUpgradeMode?.Invoke(sender, enable);

        private void SelectUpgradeRole(object? sender, PieceRole role)
            => OnSelectUpgradeRole?.Invoke(sender, role);
    }
}

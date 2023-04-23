using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using static PawnShop.Script.Model.Piece.BasePiece;
using static PawnShop.Script.Model.Piece.BasePiece.PieceRole;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.GUI.Button.Model;
using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using PawnShop.Script.System.Gameplay.PieceState;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using PawnShop.Script.Model.GUI.View;

namespace PawnShop.Script.Model.GUI.GameElement
{
    public sealed class UpgradeOption : ImageButton
    {
        private PieceRole role { get; }
        private int cost => Costs[role];
        private int current => GameManager.Instance.PlayerManager.CurrentPlayer.Currency;

        private bool enabled = false;

        public UpgradeOption(PieceRole role) : base(UpgradeViewFactory.GetRect(role), UpgradeViewFactory.GetUIState(role))
        {
            this.role = role;
            UpgradingPiece.OnEnter += OnEnter;
            UpgradingPiece.OnExit += (sender, e) => Deactivate();
            Deactivate();
        }

        private void OnEnter(object? sender, EventArgs e)
        {
            if (current < cost) return;
            enabled = true;
            Activate();
        }

        public override void Activate()
        {
            if (!enabled) return;
            base.Activate();
        }

        public override void Deactivate() 
        {
            enabled = false;
            base.Deactivate();
        }
    }
}

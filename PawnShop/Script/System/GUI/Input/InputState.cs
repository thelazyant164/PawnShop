using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.GUI.GameElement;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player;
using PawnShop.Script.Utility;
using static PawnShop.Script.Model.Board.Position;
using static PawnShop.Script.Model.Piece.BasePiece;

namespace PawnShop.Script.System.GUI.Input
{
    public abstract class InputState : State
    {
        protected InputSystem InputSystem => (InputSystem)stateMachine;
        protected BasePlayer Player => InputSystem.Player;

        public InputState(InputSystem inputSystem) : base(inputSystem) { }

        public override void Start() { }

        public override void Progress() { }

        public override void Terminate() { }

        public abstract void ToggleBuyMode();

        public abstract void ToggleUpgradeMode();

        public abstract void ToggleUpgradeView();

        public abstract void TogglePositionSelect(Position position);

        public abstract void ToggleIndicatorHighlight(PositionIndicator indicator, HighlightType type);

        public abstract void TogglePieceSelect(BasePiece piece);

        public abstract void SelectUpgradeRole(PieceRole role);

        public abstract void Undo();

        public abstract void Redo();
    }
}

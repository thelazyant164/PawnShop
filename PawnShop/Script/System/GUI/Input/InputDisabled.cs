using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.GUI.GameElement;
using PawnShop.Script.Model.Piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.Board.Position;
using static PawnShop.Script.Model.Piece.BasePiece;

namespace PawnShop.Script.System.GUI.Input
{
    public sealed class InputDisabled : InputState
    {
        public InputDisabled(InputSystem inputSystem) : base(inputSystem) { }

        public override void ToggleBuyMode() { }

        public override void ToggleUpgradeMode() { }

        public override void ToggleUpgradeView() { }

        public override void TogglePositionSelect(Position position) { }

        public override void ToggleIndicatorHighlight(PositionIndicator indicator, HighlightType type) { }

        public override void TogglePieceSelect(BasePiece piece) { }

        public override void SelectUpgradeRole(PieceRole role) { }

        public override void Undo() { }

        public override void Redo() { }
    }
}

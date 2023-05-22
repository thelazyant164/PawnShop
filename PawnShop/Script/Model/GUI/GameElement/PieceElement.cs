using PawnShop.Script.Model.GUI.Button.Model;
using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Model.GUI.View;
using PawnShop.Script.Model.Piece;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;

namespace PawnShop.Script.Model.GUI.GameElement
{
    public sealed class PieceElement : ImageButton
    {
        private bool captured = false;

        public PieceElement(PrimitiveRect rect, ImageButtonUIState imageButtonUI) : base(rect, imageButtonUI) { }

        public void OnCapture(object? sender, BasePiece piece)
        {
            captured = true;
            Hide();
            Deactivate();
        }

        public void OnRestore(object? sender, BasePiece piece)
        {
            captured = false;
            Activate();
            Show();
        }

        public void OnMove(object? sender, Board.Position position)
            => OnMove(sender, BoardViewFactory.GetPosition(position.Coordinate));

        private void OnMove(object? sender, IPrimitive.Position position)
        {
            X = position.X;
            Y = position.Y;
        }

        public override void Show()
        {
            Visible = !captured;
        }
    }
}

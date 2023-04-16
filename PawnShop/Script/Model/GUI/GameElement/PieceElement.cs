using PawnShop.Script.Model.GUI.Button.Model;
using PawnShop.Script.Model.GUI.Component;
using PawnShop.Script.Model.GUI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;
using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.GUI.View;
using PawnShop.Script.Model.Piece;

namespace PawnShop.Script.Model.GUI.GameElement
{
    public sealed class PieceElement : ImageButton, IMovable
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

        public void OnMove(object? sender, IPrimitive.Position position)
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

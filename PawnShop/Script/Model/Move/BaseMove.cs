using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.Piece.BasePiece;

namespace PawnShop.Script.Model.Move
{
    public abstract class BaseMove
    {
        public static BaseMove Plan(BasePiece piece, Position position)
        {
            return position.IsOccupied 
                ? new Capture(piece, position) 
                : new Move(piece, position);
        }

        public static Buy Plan(PieceRole role, Position position) 
            => new Buy(new PieceIdentity(position, role, 
                GameManager.Instance.TurnSystem!.CurrentTurn));

        public abstract void Execute();

        public abstract void Abort();
    }
}

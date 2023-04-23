using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.Piece.BasePiece;
using static PawnShop.Script.Model.Piece.BasePiece.PieceRole;

namespace PawnShop.Script.Model.Move
{
    public abstract class BaseMove
    {
        protected BasePlayer player;

        public BaseMove() 
        {
            player = GameManager.Instance.PlayerManager.CurrentPlayer;
        }

        public static BaseMove Plan(BasePiece piece, Position position)
        {
            return position.IsOccupied 
                ? new Capture(piece, position) 
                : new Move(piece, position);
        }

        public static Buy Plan(Position position) 
            => new Buy(new PieceIdentity(position, Pawn, 
                GameManager.Instance.PlayerManager!.CurrentTurn));

        public static Upgrade Plan(BasePiece piece, PieceRole role) 
            => new Upgrade(piece, role);

        public abstract void Execute();

        public abstract void Abort();
    }
}

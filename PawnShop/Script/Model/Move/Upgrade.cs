using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using static PawnShop.Script.Model.Piece.BasePiece;
using static PawnShop.Script.Model.Piece.BasePiece.PieceRole;

namespace PawnShop.Script.Model.Move
{
    public sealed class Upgrade : BaseMove
    {
        public static readonly int MinCost = Costs[Knight];
        public int Cost => Costs[upgradePiece.Role];
        private BasePiece piece;
        private Position position;
        private BasePiece upgradePiece;

        public Upgrade(BasePiece piece, PieceRole role) 
        {
            this.piece = piece;
            if (!GameManager.Instance.Board.TryLocate(piece, out Position? pos))
            {
                throw new Exception("Piece not located on board");
            }
            position = pos!;
            piece.Capture();
            upgradePiece = PieceFactory.CreatePiece(
                new PieceIdentity(position, role, piece.Side));
            upgradePiece.Capture();
            piece.Restore();
        }

        public override void Execute()
        {
            player.Spend(Costs[upgradePiece.Role]);
            piece.Capture();
            upgradePiece.Restore();
        }

        public override void Abort()
        {
            upgradePiece.Capture();
            piece.Restore();
            player.Gain(Costs[upgradePiece.Role]);
        }
    }
}

using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.Piece
{
    public abstract class PieceMovementSystem
    {
        public Position Position { get; private set; }

        public bool HasMoved { get; private set; }

        public PieceMovementSystem()
        {
            throw new NotImplementedException();
        }

        protected virtual List<Position> AllMovable()
        {
            throw new NotImplementedException();
        }

        protected virtual List<Position> AllGuarded()
        {
            throw new NotImplementedException();
        }

        protected virtual List<Normal> AllNormal()
        {
            throw new NotImplementedException();
        }

        protected virtual List<Attack> AllAttack()
        {
            throw new NotImplementedException();
        }

        public virtual List<BaseMove> AllMoves()
        {
            throw new NotImplementedException();
        }

        public virtual List<Position> Reign
        {
            get => throw new NotImplementedException();
            //get => AllMovable().AddRange(AllGuarded());
        }

        public bool IsChecking(Player.BasePlayer opponent)
        {
            Position? result = Reign.Find(
                position =>
                    position.IsOccupiedByPlayer(opponent)
                    && position.OccupyingPiece?.Role == BasePiece.PieceRole.King
            );
            return result != null;
        }

        public void MoveTo(Position newPosition)
        {
            throw new NotImplementedException();
        }
    }
}

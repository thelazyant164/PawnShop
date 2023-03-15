using PawnShop.Script.Manager.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.Move
{
    public abstract class BaseMove
    {
        public enum MoveType
        {
            Normal,
            Capture,
            Castle,
            Promote,
            Attack,
            EnPassant
        }

        public class OnExecuteEventArgs : EventArgs
        {
            public double SP;
            public MoveType MoveType;
            public BaseMove Move;
        }

        public class OnAbortEventArgs : EventArgs
        {
            public double SP;
            public MoveType MoveType;
            public BaseMove Move;
        }

        private event EventHandler<OnExecuteEventArgs> OnExecute;
        private event EventHandler<OnAbortEventArgs> OnAbort;

        protected MoveType Type { get; set; }

        protected double SP { get; set; }

        protected bool PieceHasMoved { get; set; }

        public BaseMove()
        {
            Type = MoveType.Normal;
            SP = 1;
            OnExecute += GameManager.Instance.Board.Execute;
            OnAbort += GameManager.Instance.Board.Abort;
        }

        public virtual void Execute()
        {
            OnExecute?.Invoke(
                this,
                new OnExecuteEventArgs
                {
                    SP = SP,
                    Move = this,
                    MoveType = Type
                }
            );
        }

        public virtual void Abort()
        {
            OnAbort?.Invoke(
                this,
                new OnAbortEventArgs
                {
                    SP = SP,
                    Move = this,
                    MoveType = Type
                }
            );
        }
    }
}

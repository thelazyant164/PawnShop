using System.Collections;
using System.Collections.Generic;

namespace ChessUltimate.Script.Utility
{
    public abstract class State
    {
        protected readonly StateMachine _stateMachine;

        public State(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public virtual void Progress() { }
    }
}

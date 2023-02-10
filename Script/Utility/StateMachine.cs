using System.Collections;
using System.Collections.Generic;

namespace ChessUltimate.Script.Utility
{
    public abstract class StateMachine
    {
        protected State _currentState;

        protected State CurrentState
        {
            get => _currentState;
        }

        protected void SetState(State newState)
        {
            _currentState = newState;
            // TODO: implement Coroutine
        }

        public virtual void Update()
        {
            _currentState?.Progress();
        }
    }
}

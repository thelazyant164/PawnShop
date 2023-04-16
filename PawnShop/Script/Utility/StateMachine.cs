using System.Collections;
using System.Collections.Generic;

namespace PawnShop.Script.Utility
{
    public abstract class StateMachine
    {
        protected State? currentState;
        protected State CurrentState
        {
            get 
            {
                if (currentState == null) throw new Exception("Invalid state machine: currentState is null");
                return currentState;
            }
        }

        protected void SetState(State newState)
        {
            currentState?.Terminate();
            currentState = newState;
        }

        public virtual void Update()
        {
            currentState?.Progress();
        }
    }
}

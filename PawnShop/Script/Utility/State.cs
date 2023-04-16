using System.Collections;
using System.Collections.Generic;

namespace PawnShop.Script.Utility
{
    public abstract class State
    {
        protected readonly StateMachine stateMachine;

        public State(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public abstract void Progress();

        public abstract void Terminate();
    }
}

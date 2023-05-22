namespace PawnShop.Script.Utility
{
    /// <summary>
    /// An abstract representation of a state within a finite state machine.
    /// </summary>
    public abstract class State
    {
        protected readonly StateMachine stateMachine;

        public State(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        /// <summary>
        /// Called once at the beginning of every <c>State</c>.
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Called every loop of <c>StateMachine</c>'s <c>Update</c>.
        /// </summary>
        public abstract void Progress();

        /// <summary>
        /// Called once at the end of every <c>State</c>.
        /// </summary>
        public abstract void Terminate();
    }
}

namespace PawnShop.Script.Utility
{
    /// <summary>
    /// An abstract representation of a finite state machine.
    /// </summary>
    public abstract class StateMachine
    {
        private State? currentState;
        protected State CurrentState => currentState != null
            ? currentState
            : throw new Exception("Invalid state machine: currentState is null");

        /// <summary>
        /// To be called by an ending <c>State</c> to terminate itself and begin the next state.
        /// </summary>
        /// <remarks>Will call <c>Terminate</c> on the <c>CurrentState</c> before calling <c>Start</c> on the next.</remarks>
        /// <param name="newState">The next <c>State</c> to transition to.</param>
        protected void SetState(State newState)
        {
            currentState?.Terminate();
            currentState = newState;
            currentState.Start();
        }

        /// <summary>
        /// Calls <c>Progress</c> on <c>CurrentState</c> every loop.
        /// </summary>
        public virtual void Update()
        {
            currentState?.Progress();
        }
    }
}

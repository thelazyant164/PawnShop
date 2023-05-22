namespace PawnShop.Script.Model.Coin
{
    /// <summary>
    /// Manager class to record a timeline of all coins spawned during the match.
    /// </summary>
    /// <remarks>When moving forward in time, update this class before <c>History</c>.</remarks>
    public sealed class CoinSpawnHistory
    {
        public IReadOnlyList<CoinSpawnEvent> MatchHistory => history.ToList().AsReadOnly();
        private Stack<CoinSpawnEvent> history = new Stack<CoinSpawnEvent>();
        private Stack<CoinSpawnEvent> aborted = new Stack<CoinSpawnEvent>();
        public event EventHandler<CoinSpawnEvent>? OnExecute;
        public event EventHandler<CoinSpawnEvent>? OnAbort;

        public CoinSpawnHistory()
        {

        }

        /// <summary>
        /// Callback delegate to respond to "redo" user command.
        /// </summary>
        public void Execute()
        {
            CoinSpawnEvent spawnEvent = aborted.Pop();
            OnExecute?.Invoke(this, spawnEvent);
            history.Push(spawnEvent);
        }

        /// <summary>
        /// Callback delegate to respond to "undo" user command.
        /// </summary>
        public void Abort()
        {
            CoinSpawnEvent spawnEvent = history.Pop();
            OnAbort?.Invoke(this, spawnEvent);
            aborted.Push(spawnEvent);
        }

        public void Record(CoinSpawnEvent spawnEvent)
        {
            OnExecute?.Invoke(this, spawnEvent);
            history.Push(spawnEvent);
            aborted.Clear();
        }
    }
}

namespace PawnShop.Script.Utility
{
    /// <summary>
    /// Utility class to dispatch a nullable-sender event.
    /// </summary>
    /// <remarks>To be used as delegates for static events, where a sender object is unnecessary.</remarks>
    /// <typeparam name="T">The generic object to be dispatched with the event.</typeparam>
    public sealed class StaticEvent<T>
    {
        public delegate void Handler(T e);
    }
}

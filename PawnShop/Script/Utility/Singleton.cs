using System;

namespace PawnShop.Script.Utility
{
    /// <summary>
    /// Wrapper class to enforce Singleton behaviour on a class.
    /// </summary>
    /// <typeparam name="T">Class to enforce Singleton behaviour on.</typeparam>
    public abstract class Singleton<T>
    {
        protected static T? _instance;
    }
}

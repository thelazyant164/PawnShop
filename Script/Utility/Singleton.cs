using System;

namespace ChessUltimate.Script.Utility
{
    public class Singleton<T> where T : class, new()
    {
        protected Singleton() { }

        public static T Instance
        {
            get { return _instance.Value; }
        }
        private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());
    }
}

using System;

namespace PawnShop.Script.Utility
{
    public abstract class Singleton<T>
    {
        protected static T? _instance;
    }
}

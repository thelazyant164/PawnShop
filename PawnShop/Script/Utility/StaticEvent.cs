using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Utility
{
    public sealed class StaticEvent<T>
    {
        public delegate void Handler(T e);
    }
}

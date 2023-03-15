using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IPrimitive
    {
        public struct Position
        {
            public int X;
            public int Y;
            public Position(int x, int y)
            { 
                X = x;
                Y = y;
            }
        }

        public abstract int X { get; }

        public abstract int Y { get; }

        public abstract Point2D Origin { get; }
    }
}

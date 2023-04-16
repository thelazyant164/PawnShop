using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IPrimitive
    {
        public struct Position
        {
            public float X;
            public float Y;
            public Position(float x, float y)
            { 
                X = x;
                Y = y;
            }
        }

        public abstract float X { get; }

        public abstract float Y { get; }

        public abstract Point2D Origin { get; }
    }
}

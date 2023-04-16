using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IPrimitiveRect : IPrimitive
    {
        public struct Dimension
        {
            public float Width;
            public float Height;

            public Dimension(float width, float height)
            {
                Width = width;
                Height = height;
            }
        }

        public struct PrimitiveRect
        {
            public Position Origin;
            public Dimension Dimension;

            public PrimitiveRect(Position origin, Dimension dimension)
            {
                Origin = origin;
                Dimension = dimension;
            }

            public PrimitiveRect(float x, float y, float width, float height)
            {
                Origin = new Position(x, y);
                Dimension = new Dimension(width, height);
            }
        }

        public abstract float Width { get; }

        public abstract float Height { get; }

        public abstract Rectangle Rectangle { get; }

        public abstract bool IsCursorOver(Point2D mousePosition);
    }
}

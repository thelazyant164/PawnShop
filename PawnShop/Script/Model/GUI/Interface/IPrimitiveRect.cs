using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IPrimitiveRect : IPrimitive
    {
        public struct Dimension
        {
            public int Width;
            public int Height;

            public Dimension(int width, int height)
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

            public PrimitiveRect(int x, int y, int width, int height)
            {
                Origin = new Position(x, y);
                Dimension = new Dimension(width, height);
            }
        }

        public abstract int Width { get; }

        public abstract int Height { get; }

        public abstract Rectangle Rectangle { get; }

        public abstract bool IsCursorOver(Point2D mousePosition);
    }
}

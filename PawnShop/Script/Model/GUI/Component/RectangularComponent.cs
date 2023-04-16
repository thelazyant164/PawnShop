using PawnShop.Script.Model.GUI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;

namespace PawnShop.Script.Model.GUI.Component
{
    public abstract class RectangularComponent : VisibleComponent, IPrimitiveRect
    {
        public virtual float Width { get; protected set; }

        public virtual float Height { get; protected set; }

        public virtual Rectangle Rectangle
        {
            get =>
                new Rectangle
                {
                    X = X,
                    Y = Y,
                    Width = Width,
                    Height = Height
                };
        }

        public RectangularComponent(PrimitiveRect rect) 
        {
            X = rect.Origin.X;
            Y = rect.Origin.Y;
            Width = rect.Dimension.Width;
            Height = rect.Dimension.Height;
        }

        public virtual bool IsCursorOver(Point2D mousePosition)
        {
            bool isOverHorizontally = X <= mousePosition.X && mousePosition.X <= X + Width;
            bool isOverVertically = Y <= mousePosition.Y && mousePosition.Y <= Y + Height;
            return isOverHorizontally && isOverVertically;
        }
    }
}

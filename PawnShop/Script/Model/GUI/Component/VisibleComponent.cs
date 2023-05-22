using PawnShop.Script.Model.GUI.Interface;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;

namespace PawnShop.Script.Model.GUI.Component
{
    public abstract class VisibleComponent : IVisible
    {
        public virtual float X { get; protected set; }

        public virtual float Y { get; protected set; }

        public virtual Point2D Origin => new Point2D { X = X, Y = Y };

        public virtual bool Visible { get; protected set; } = false;

        public VisibleComponent(Position position)
        {
            X = position.X;
            Y = position.Y;
        }

        public VisibleComponent() : this(Position.Origin) { }

        public virtual void Show()
        {
            Visible = true;
        }

        public virtual void Hide()
        {
            Visible = false;
        }

        public abstract void Draw();
    }
}

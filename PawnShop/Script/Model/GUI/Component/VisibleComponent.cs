using PawnShop.Script.Model.GUI.Interface;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.GUI.Component
{
    public abstract class VisibleComponent : IVisible
    {
        public virtual float X { get; protected set; }

        public virtual float Y { get; protected set; }

        public virtual Point2D Origin => new Point2D { X = X, Y = Y };

        public virtual bool Visible { get; protected set; } = false;

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

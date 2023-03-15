using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Manager.GUI;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.View
{
    public abstract class BaseView : IVisible
    {
        public virtual int X { get; protected set; }

        public virtual int Y { get; protected set; }

        public virtual Point2D Origin => new Point2D { X = X, Y = Y };

        public virtual bool Visible { get; protected set; } = true;

        public virtual void Show()
        {
            Visible = true;
        }

        public virtual void Hide()
        {
            Visible = false;
        }

        public virtual void Draw()
        {
        }
    }
}

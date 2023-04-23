using PawnShop.Script.Model.GUI.Component;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;

namespace PawnShop.Script.Model.GUI.Label
{
    public abstract class BaseLabel<T> : VisibleComponent
    {
        public T Content { get; protected set; }

        public BaseLabel(Position position, T content) : base(position) 
        {
            Content = content;
        }
    }
}

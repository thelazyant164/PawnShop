using PawnShop.Script.Model.GUI.Component;
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

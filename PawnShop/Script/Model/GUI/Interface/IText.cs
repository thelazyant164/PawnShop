using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IText : IVisible
    {
        public struct TextContent
        {
            public string Font;
            public string Text;
            public int Size;
            public Color Color;
        }

        public abstract TextContent Content { get; }
    }
}

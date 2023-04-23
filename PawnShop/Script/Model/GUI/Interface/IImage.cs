using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IImage : IVisible
    {
        public struct ImageContent
        {
            public Bitmap Texture;

            public ImageContent(Bitmap texture)
            {
                Texture = texture;
            }
        }

        public abstract ImageContent Content { get; }
    }
}

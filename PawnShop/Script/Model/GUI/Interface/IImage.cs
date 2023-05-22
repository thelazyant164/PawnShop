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

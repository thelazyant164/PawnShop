using static PawnShop.Script.Model.GUI.Interface.IImage;

namespace PawnShop.Script.Model.GUI.Button.UIStateData
{
    public sealed class ImageButtonUIStateData : ButtonUIStateData
    {
        public ImageButtonUIStateData(ImageContent content)
        {
            Content = content;
        }

        public readonly ImageContent Content;
    }
}

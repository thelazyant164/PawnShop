using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface ITextGraphic : IVisible
    {
        private static readonly string rootDir = "D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Asset\\Text";

        private static readonly Dictionary<int, Bitmap> numbers = new Dictionary<int, Bitmap>()
        {
            { 0, new Bitmap("0", $"{rootDir}\\Number\\0.png") },
            { 1, new Bitmap("1", $"{rootDir}\\Number\\1.png") },
            { 2, new Bitmap("2", $"{rootDir}\\Number\\2.png") },
            { 3, new Bitmap("3", $"{rootDir}\\Number\\3.png") },
            { 4, new Bitmap("4", $"{rootDir}\\Number\\4.png") },
            { 5, new Bitmap("5", $"{rootDir}\\Number\\5.png") },
            { 6, new Bitmap("6", $"{rootDir}\\Number\\6.png") },
            { 7, new Bitmap("7", $"{rootDir}\\Number\\7.png") },
            { 8, new Bitmap("8", $"{rootDir}\\Number\\8.png") },
            { 9, new Bitmap("9", $"{rootDir}\\Number\\9.png") },
            { 10, new Bitmap("10", $"{rootDir}\\Number\\10.png") },
            { 11, new Bitmap("11", $"{rootDir}\\Number\\11.png") },
            { 12, new Bitmap("12", $"{rootDir}\\Number\\12.png") },
            { 13, new Bitmap("13", $"{rootDir}\\Number\\13.png") },
            { 14, new Bitmap("14", $"{rootDir}\\Number\\14.png") },
            { 15, new Bitmap("15", $"{rootDir}\\Number\\15.png") },
            { 16, new Bitmap("16", $"{rootDir}\\Number\\16.png") },
            { 17, new Bitmap("17", $"{rootDir}\\Number\\17.png") },
            { 18, new Bitmap("18", $"{rootDir}\\Number\\18.png") },
            { 19, new Bitmap("19", $"{rootDir}\\Number\\19.png") },
            { 20, new Bitmap("20", $"{rootDir}\\Number\\20.png") }
        };

        private static readonly Dictionary<string, Bitmap> texts = new Dictionary<string, Bitmap>()
        {
        };

        public struct TextGraphicContent
        {
            public Bitmap Texture;

            public TextGraphicContent(string text)
            {
                Texture = texts[text];
            }

            public TextGraphicContent(int text)
            {
                Texture = numbers[text];
            }
        }

        public abstract TextGraphicContent Content { get; }
    }
}

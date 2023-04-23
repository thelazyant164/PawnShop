using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            { 10, new Bitmap("10", $"{rootDir}\\Number\\10.png") }
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

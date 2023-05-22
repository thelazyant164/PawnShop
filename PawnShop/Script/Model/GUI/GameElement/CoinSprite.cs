using PawnShop.Script.Model.GUI.Component;
using PawnShop.Script.Model.GUI.Sprite.Model;
using PawnShop.Script.Model.GUI.Sprite.UIState;
using PawnShop.Script.Model.GUI.Sprite.UIStateData;
using PawnShop.Script.Model.GUI.View;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;

namespace PawnShop.Script.Model.GUI.GameElement
{
    public sealed class CoinSprite : VisibleComponent
    {
        private readonly static string rootDir = "D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Asset\\Coins\\Sprite";

        private static ImageContent[] ReadAnimation(int frameCount)
        {
            ImageContent[] images = new ImageContent[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                images[i] = new ImageContent(new Bitmap($"coin_anim_{i}", $"{rootDir}\\coin_{i + 1}.png"));
            }
            return images;
        }

        private static readonly ImageSpriteUIStateData coinUIStateData
            = new ImageSpriteUIStateData(ReadAnimation(10));
        private static readonly ImageSpriteUIState UIState
            = new ImageSpriteUIState(coinUIStateData);

        private ImageSprite coinSprite;
        private bool collected = false;

        public CoinSprite(Board.Position position) : base(Position.Origin)
        {
            coinSprite = new ImageSprite(BoardViewFactory.GetPosition(position.Coordinate), UIState);
        }

        public override void Draw()
        {
            if (!Visible) return;
            coinSprite.Draw();
        }

        public override void Show()
        {
            if (collected) return;
            base.Show();
            coinSprite.Show();
        }

        public override void Hide()
        {
            base.Hide();
            coinSprite.Hide();
        }

        public void OnCollect(object? sender, Coin.Coin coin) => collected = true;

        public void OnRestore(object? sender, Coin.Coin coin) => collected = false;
    }
}

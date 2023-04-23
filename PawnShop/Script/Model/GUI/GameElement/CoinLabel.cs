﻿using PawnShop.Script.Model.GUI.Button.Model;
using PawnShop.Script.Model.GUI.Component;
using PawnShop.Script.Model.GUI.Label;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;
using static PawnShop.Script.Model.GUI.Interface.ITextGraphic;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using SplashKitSDK;
using PawnShop.Script.Model.Player;

namespace PawnShop.Script.Model.GUI.GameElement
{
    public sealed class CoinLabel : VisibleComponent
    {
        private readonly static float x = 900;
        private readonly static float y = 620;
        private readonly static Position position = new Position(x, y);

        private sealed class CoinImage : ImageLabel
        {
            private readonly static string rootDir = "D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Asset\\Coins\\Gold";

            private readonly static ImageContent content =
                new ImageContent(new Bitmap($"Gold_1", $"{rootDir}\\Gold_1.png"));

            public CoinImage() : base(position, content) { }
        }

        private sealed class CoinCount : TextGraphicLabel
        {
            private readonly static float x = 1000;
            private readonly static float y = 650;
            private readonly static Position position = new Position(x, y);

            public CoinCount() : base(position, new TextGraphicContent(0)) { }

            public void SetValue(object? sender, int coin) => Content = new TextGraphicContent(coin);
        }

        private readonly CoinImage coinImage;
        private readonly CoinCount coinCount;

        public CoinLabel(BasePlayer player) : base(position) 
        {
            coinImage = new CoinImage();
            coinCount = new CoinCount();
            player.OnCoinUpdate += coinCount.SetValue;
        }

        public override void Show()
        {
            coinImage.Show();
            coinCount.Show();
            base.Show();
        }

        public override void Hide()
        {
            coinImage.Hide();
            coinCount.Hide();
            base.Hide();
        }

        public override void Draw()
        {
            if (!Visible) return;
            coinImage.Draw();
            coinCount.Draw();
        }
    }
}
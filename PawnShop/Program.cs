using System;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Manager.GUI;
using static PawnShop.Script.Model.Player.BasePlayer.PlayerType;
using PawnShop.Script.Utility;
using SplashKitSDK;

namespace PawnShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Window window = new Window("PawnShop server", 800, 600);
            GameManager.GameConfig config = new GameManager.GameConfig
            {
                StartDate = DateTime.Now,
                Black = AI,
                White = Manual
            };
            GameManager gameManager = GameManager.Instance;
            gameManager.Init(config);
            ViewManager viewManager = ViewManager.Instance;
            viewManager.Init(config);
            do
            {
                gameManager.Update();
                viewManager.Draw();
                SplashKit.ProcessEvents();
                SplashKit.RefreshScreen();
            }
            while (!window.CloseRequested);
        }
    }
}

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
            //Window window = new Window("PawnShop server", 2294, 940); // maximum size Splashkit window - screen ratio 24:9
            Window window = new Window("PawnShop server", 1280, 720); // maximum size Splashkit window - screen ratio 16:9
            window.moveTo(0, 0);

            GameManager.GameConfig config = new GameManager.GameConfig
            {
                StartDate = DateTime.Now,
                Black = Manual,
                White = Manual
            };
            GameManager gameManager = GameManager.Instance;
            gameManager.Init(config);
            ViewManager viewManager = ViewManager.Instance;
            viewManager.Init(config);
            do
            {
                //Console.WriteLine($"X: {SplashKit.MouseX()}, Y:{SplashKit.MouseY()}");
                SplashKit.ProcessEvents();
                gameManager.Update();
                viewManager.Update();
                viewManager.Draw();
                SplashKit.RefreshScreen();
                SplashKit.ClearScreen();
            }
            while (!window.CloseRequested);
        }
    }
}

using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.GUI.View;
using PawnShop.Script.Model.Player;
using PawnShop.Script.System.GUI.Input;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Manager.GUI
{
    /// <summary>
    /// Manager class to manage all views from a player.
    /// </summary>
    public sealed class PlayerViewManager
    {
        public List<BaseView> Views { get; } = new List<BaseView>();
        public BaseInputController InputController { get; private set; }

        public PlayerViewManager(BasePlayer player) 
        {
            InputController = BaseInputController.Init(player);
            BoardView boardView = new BoardView(player, GameManager.Instance.Board);
            Add(boardView);
            boardView.Show();
        }

        private void Add(BaseView view)
        {
            view.RegisterView(InputController);
            Views.Add(view);
        }

        public void Draw() 
        { 
            foreach (BaseView view in Views) 
            {
                view.Draw();
            }
        }

        public void Update()
        {
            InputController.Update();
        }
    }
}

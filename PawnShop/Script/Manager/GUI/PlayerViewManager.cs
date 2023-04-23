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
        private readonly List<BaseView> views = new List<BaseView>();
        private Action? _viewBuffer;
        public InputSystem InputController { get; private set; }

        public PlayerViewManager(BasePlayer player) 
        {
            InputController = new InputSystem(player);
            BoardView boardView = new BoardView(player, InputController, GameManager.Instance.Board);
            AddView(boardView);
        }

        public void AddView(BaseView view) => _viewBuffer = () => 
        {
            views.Add(view);
            view.Activate();
            view.Show();
        };

        public void RemoveView(BaseView view) => _viewBuffer = () => views.Remove(view);

        public void StartTurn()
        {
            foreach (BaseView view in views)
            { 
                view.Activate(); 
                view.Show();
            }
        }

        public void EndTurn()
        {
            foreach (BaseView view in views)
            {
                view.Deactivate();
                view.Hide();
            }
        }

        public void Draw() 
        { 
            foreach (BaseView view in views)
            {
                view.Draw();
            }
        }

        public void Update()
        {
            _viewBuffer?.Invoke();
            _viewBuffer = null;
            foreach (BaseView view in views)
            {
                view.Update();
            }
        }
    }
}

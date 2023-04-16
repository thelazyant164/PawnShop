using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Utility;
using PawnShop.Script.System.GUI.Input;
using PawnShop.Script.Model.GUI.View;
using static PawnShop.Script.Manager.Gameplay.GameManager;
using static PawnShop.Script.Model.Player.BasePlayer.PlayerType;
using static PawnShop.Script.Model.Player.BasePlayer.PlayerSide;
using PawnShop.Script.System.Gameplay;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Player;

namespace PawnShop.Script.Manager.GUI
{
    /// <summary>
    /// Singleton class ViewManager to manage all views from both players.
    /// </summary>
    /// <remarks>
    /// Init & call after <c>GameManager</c> has been initialized.
    /// </remarks>
    public sealed class ViewManager : Singleton<ViewManager>
    {
        public static ViewManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ViewManager();
                return _instance;
            }
        }

        private ViewManager() { }
        private PlayerViewManager black;
        private PlayerViewManager white;
        private TurnSystem turnSystem;

        /// <summary>
        /// Method to initialize the game.
        /// </summary>
        /// <param name="config">Configurations of the game being started.</param>
        public void Init(GameConfig config)
        {
            turnSystem = GameManager.Instance.TurnSystem;
            BasePlayer blackPlayer = turnSystem.GetPlayer(Black);
            BasePlayer whitePlayer = turnSystem.GetPlayer(White);
            black = new PlayerViewManager(blackPlayer);
            white = new PlayerViewManager(whitePlayer);
        }

        /// <summary>
        /// Method to draw all views pertaining to the active player, to be called every frame.
        /// </summary>
        /// <remarks>
        /// Must be called after <c>ViewManager.Init()</c> has been called.
        /// </remarks>
        public void Draw()
        {
            if (turnSystem == null) throw new Exception("Cannot get turn system");
            if (turnSystem.CurrentTurn == White)
            {
                white.Draw();
            }
            else
            {
                black.Draw();
            }
        }

        /// <summary>
        /// Method to update all views pertaining to the current gamestate, to be called every frame.
        /// </summary>
        /// <remarks>
        /// Must be called after <c>ViewManager.Init()</c> has been called.
        /// </remarks>
        public void Update()
        {
            if (turnSystem == null) throw new Exception("Cannot get turn system");
            white.Update();
            black.Update();
        }
    }
}

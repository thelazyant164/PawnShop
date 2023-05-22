using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Player;
using PawnShop.Script.Utility;
using static PawnShop.Script.Manager.Gameplay.GameManager;
using static PawnShop.Script.Model.Player.BasePlayer.PlayerSide;

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
        public PlayerViewManager PlayerView
            => playerManager.CurrentTurn == Black ? black : white;
        private PlayerManager playerManager;

        /// <summary>
        /// Method to initialize the game.
        /// </summary>
        /// <param name="config">Configurations of the game being started.</param>
        public void Init(GameConfig config)
        {
            playerManager = GameManager.Instance.PlayerManager;
            BasePlayer blackPlayer = playerManager.GetPlayer(Black);
            BasePlayer whitePlayer = playerManager.GetPlayer(White);
            black = new PlayerViewManager(blackPlayer);
            white = new PlayerViewManager(whitePlayer);
            playerManager.OnTurnChange += OnTurnChange;
        }

        private void OnTurnChange(object? sender, BasePlayer player)
        {
            if (player.Side == White)
            {
                black.EndTurn();
                white.StartTurn();
            }
            else
            {
                white.EndTurn();
                black.StartTurn();
            }
        }

        /// <summary>
        /// Method to draw all views pertaining to the active player, to be called every frame.
        /// </summary>
        /// <remarks>
        /// Must be called after <c>ViewManager.Init()</c> has been called.
        /// </remarks>
        public void Draw()
        {
            if (playerManager == null) throw new Exception("Cannot get turn system");
            PlayerView.Draw();
        }

        /// <summary>
        /// Method to update all views pertaining to the current gamestate, to be called every frame.
        /// </summary>
        /// <remarks>
        /// Must be called after <c>ViewManager.Init()</c> has been called.
        /// </remarks>
        public void Update()
        {
            if (playerManager == null) throw new Exception("Cannot get turn system");
            white.Update();
            black.Update();
        }
    }
}

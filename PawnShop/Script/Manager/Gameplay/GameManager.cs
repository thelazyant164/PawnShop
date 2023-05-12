using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Coin;
using PawnShop.Script.Model.Move;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player;
using PawnShop.Script.System.Gameplay.GameState;
using PawnShop.Script.System.GUI.Input;
using PawnShop.Script.Utility;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.Manager.Gameplay
{
    /// <summary>
    /// Singleton class GameManager to manage the core gameplay logic.
    /// </summary>
    public sealed class GameManager : Singleton<GameManager>
    {
        public static GameManager Instance
        {
            get
            {
                if (_instance == null) _instance = new GameManager();
                return _instance;
            }
        }

        private GameManager()
        {
            Board = new Board();
            History = new History();
            History.OnExecute += Board.Execute;
            History.OnAbort += Board.Abort;
            CoinManager.History.OnExecute += Board.Execute;
            CoinManager.History.OnAbort += Board.Abort;
        }

        public struct GameConfig
        {
            public PlayerType White;
            public PlayerType Black;
            public DateTime StartDate;
        }

        private Action? _turnBuffer;
        private readonly GameStateSystem gameStateSystem = new GameStateSystem();
        public PlayerManager PlayerManager { get; private set; }
        public Board Board { get; private set; }
        public History History { get; private set; }
        public CoinManager CoinManager { get; private set; } = new CoinManager();

        /// <summary>
        /// Method to initialize the game.
        /// </summary>
        /// <param name="config">Configurations of the game being started.</param>
        public void Init(GameConfig config)
        {
            CoinSpawner.Init();
            PieceFactory.Path("D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Data\\CSV\\Piece\\", "InitBoard_PawnShop.csv");
            PieceFactory.OnPieceAdd += Board.AddPiece;
            PlayerManager = new PlayerManager(config);
            gameStateSystem.Init(PlayerManager);
            PieceFactory.InitializePieces();
            gameStateSystem.SetGameState(new GameInProgress(gameStateSystem));
            BoardNavigator.Init();
            PlayerManager.Begin();
        }

        /// <summary>
        /// Method to trigger turn change externally from player state system.
        /// To be called by <c>History</c>, on abort/reapply a turn.
        /// </summary>
        /// <remarks>
        /// Set a callback delegate to trigger turn change by the start of next frame.
        /// </remarks>
        public void TriggerTurnChange() => _turnBuffer = () => PlayerManager.NextTurn();

        /// <summary>
        /// Method to update the model, to be called every frame.
        /// </summary>
        /// <remarks>
        /// Must be called after <c>GameManager.Init()</c> has been called.
        /// </remarks>
        public void Update()
        {
            _turnBuffer?.Invoke();
            _turnBuffer = null;
            gameStateSystem.Update();
            PlayerManager!.Update();
            CoinManager.Progress();
            History.Progress();
        }
    }
}

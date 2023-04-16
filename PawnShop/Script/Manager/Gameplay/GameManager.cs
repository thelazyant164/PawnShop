using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player;
using PawnShop.Script.System.Gameplay;
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
        }

        public struct GameConfig
        {
            public PlayerType White;
            public PlayerType Black;
            public DateTime StartDate;
        }

        private readonly GameStateSystem gameStateSystem = new GameStateSystem();
        public TurnSystem TurnSystem { get; private set; }
        public Board Board { get; private set; }
        public History History { get; private set; }

        /// <summary>
        /// Method to initialize the game.
        /// </summary>
        /// <param name="config">Configurations of the game being started.</param>
        public void Init(GameConfig config)
        {
            PieceFactory.Path("D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Data\\CSV\\Piece\\", "InitBoard.csv");
            PieceFactory.OnPieceAdd += Board.AddPiece;
            TurnSystem = new TurnSystem(config);
            PieceFactory.InitializePieces();
            gameStateSystem.SetGameState(new GameInProgress(gameStateSystem));
            BoardNavigator.Init();
            TurnSystem.Begin();
        }

        /// <summary>
        /// Method to update the model, to be called every frame.
        /// </summary>
        /// <remarks>
        /// Must be called after <c>GameManager.Init()</c> has been called.
        /// </remarks>
        public void Update()
        {
            gameStateSystem.Update();
            TurnSystem!.Update();
        }
    }
}

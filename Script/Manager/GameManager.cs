using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessUltimate.Script.Model.Player;
using ChessUltimate.Script.System.Gameplay;
using ChessUltimate.Script.System.Gameplay.GameState;
using ChessUltimate.Script.Utility;

namespace ChessUltimate.Script.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public struct GameConfig
        {
            public Player.PlayerType White;
            public Player.PlayerType Black;
            public DateTime StartDate;
        }

        private readonly GameStateSystem gameStateSystem = new GameStateSystem();
        private TurnSystem turnSystem;
        private readonly Board board;

        public void Init(GameConfig config)
        {
            gameStateSystem.SetGameState(new GameInProgress(gameStateSystem));
            turnSystem = new TurnSystem(config);
            board = new Board(config);
        }

        public void Update()
        {
            gameStateSystem.Update();
            turnSystem.Update();
        }
    }
}

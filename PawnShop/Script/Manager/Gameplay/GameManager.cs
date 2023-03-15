using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Player;
using PawnShop.Script.System.Gameplay;
using PawnShop.Script.System.Gameplay.GameState;
using PawnShop.Script.Utility;

namespace PawnShop.Script.Manager.Gameplay
{
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
        }

        public struct GameConfig
        {
            public BasePlayer.PlayerType White;
            public BasePlayer.PlayerType Black;
            public DateTime StartDate;
        }

        private readonly PieceStateSystem gameStateSystem = new PieceStateSystem();
        public TurnSystem TurnSystem { get; private set; }
        public Board Board { get; private set; }

        public void Init(GameConfig config)
        {
            gameStateSystem.SetGameState(new GameInProgress(gameStateSystem));
            TurnSystem = new TurnSystem(config);
        }

        public void Update()
        {
            gameStateSystem.Update();
            TurnSystem.Update();
        }
    }
}

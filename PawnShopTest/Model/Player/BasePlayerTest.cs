using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.System.Gameplay;
using PawnShop.Script.System.Gameplay.GameState;
using PawnShop.Script.System.Gameplay.PieceState;
using static PawnShop.Script.Manager.Gameplay.GameManager;
using static PawnShop.Script.Model.Board.Board;
using static PawnShop.Script.Model.Piece.BasePiece;
using static PawnShop.Script.Model.Player.BasePlayer;
using static PawnShop.Script.Model.Player.BasePlayer.PlayerType;


namespace PawnShopTest
{
    [TestFixture]
    public class BasePlayerTest
    {
        private Board board;
        private TurnSystem turnSystem;
        private readonly GameStateSystem gameStateSystem = new GameStateSystem();

        [SetUp]
        public void Setup()
        {
            GameConfig config = new GameConfig
            {
                StartDate = DateTime.Now,
                Black = AI,
                White = Manual
            };
            PieceFactory.Path("D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Data\\CSV\\Piece\\", "InitBoard.csv");
            board = new Board();
            PieceFactory.OnPieceAdd += board.AddPiece;
            PieceFactory.InitializePieces();
            gameStateSystem.SetGameState(new GameInProgress(gameStateSystem));
            turnSystem = new TurnSystem(config);
        }

        [TearDown]
        public void Teardown() 
        {
            PieceFactory.UnregisterAll();
        }
    }
}
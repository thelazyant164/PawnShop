using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.System.Gameplay.GameState;
using static PawnShop.Script.Manager.Gameplay.GameManager;
using static PawnShop.Script.Model.Player.BasePlayer.PlayerType;


namespace PawnShopTest
{
    [TestFixture]
    public class BasePlayerTest
    {
        private Board board;
        private PlayerManager turnSystem;
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
            turnSystem = new PlayerManager(config);
        }

        [TearDown]
        public void Teardown()
        {
            PieceFactory.UnregisterAll();
        }
    }
}
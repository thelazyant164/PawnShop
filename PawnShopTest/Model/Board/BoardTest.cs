using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;

namespace PawnShopTest
{
    [TestFixture]
    public class BoardTest
    {
        private Board board;

        [SetUp]
        public void Setup()
        {
            PieceFactory.Path("D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Data\\CSV\\Piece\\", "InitBoard.csv");
            board = new Board();
        }

        [Test]
        public void BoardInitProperly()
        {
            Assert.That(board, Is.Not.Null);
        }

        [Test]
        public void LocatePos()
        {
            Assert.True(board.TryLocate(Board.File.A, Board.Rank.r1, out Position? position));
            Assert.That(position, Is.Not.Null);
            Assert.True(board.TryLocate(Board.File.H, Board.Rank.r8, out position));
            Assert.That(position, Is.Not.Null);
        }
    }
}
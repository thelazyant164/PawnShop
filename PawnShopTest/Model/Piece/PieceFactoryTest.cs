using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;

namespace PawnShopTest
{
    [TestFixture]
    public class PieceFactoryTest
    {
        [SetUp]
        public void Setup()
        {
            PieceFactory.Path("D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Data\\CSV\\Piece\\", "InitBoard.csv");
        }

        [Test]
        public void SetPath()
        {
            Assert.That(PieceFactory.Dir, Is.EqualTo("D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Data\\CSV\\Piece\\"));
            Assert.That(PieceFactory.File, Is.EqualTo("InitBoard.csv"));
        }

        [Test]
        public void ParsePos()
        {
            Assert(PieceFactory.ParsePosition("a", "2"));
        }
    }
}
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;

namespace PawnShopTest
{
    [TestFixture]
    public class PieceFactoryTest
    {
        private Board board;

        [SetUp]
        public void Setup()
        {
            PieceFactory.Path("D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Data\\CSV\\Piece\\", "InitBoard.csv");
            board = new Board();
        }

        [TearDown]
        public void Teardown()
        {
            PieceFactory.UnregisterAll();
        }

        //[Test]
        //public void SetPath()
        //{
        //    Assert.That(PieceFactory.Dir, Is.EqualTo("D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Data\\CSV\\Piece\\"));
        //    Assert.That(PieceFactory.File, Is.EqualTo("InitBoard.csv"));
        //}

        //[Test]
        //public void ParsePos()
        //{
        //    Position? position;
        //    board.TryLocate(Board.File.A, Rank.r1, out position);
        //    Assert.That(PieceFactory.GetRect("a", "1"), Is.EqualTo(position!));
        //    board.TryLocate(Board.File.H, Rank.r8, out position);
        //    Assert.That(PieceFactory.GetRect("h", "8"), Is.EqualTo(position!));
        //    Assert.Throws<Exception>(() => PieceFactory.GetRect("i", "1"), "Invalid data when trying to parse CSV - encountered i; expected a, b, c, d, e, f, g or h.");
        //    Assert.Throws<Exception>(() => PieceFactory.GetRect("a", "9"), "Invalid data when trying to parse CSV - encountered 9; expected 1, 2, 3, 4, 5, 6, 7 or 8.");
        //}

        //[Test]
        //public void ParseRole()
        //{
        //    Assert.That(PieceFactory.ParseRole("King"), Is.EqualTo(PieceRole.King));
        //    Assert.That(PieceFactory.ParseRole("QueenRect"), Is.EqualTo(PieceRole.QueenRect));
        //    Assert.That(PieceFactory.ParseRole("KnightRect"), Is.EqualTo(PieceRole.KnightRect));
        //    Assert.That(PieceFactory.ParseRole("Pawn"), Is.EqualTo(PieceRole.Pawn));
        //    Assert.That(PieceFactory.ParseRole("BishopRect"), Is.EqualTo(PieceRole.BishopRect));
        //    Assert.That(PieceFactory.ParseRole("RookRect"), Is.EqualTo(PieceRole.RookRect));
        //    Assert.Throws<Exception>(() => PieceFactory.ParseRole("Human"), "Invalid data when trying to parse CSV - encountered Human; expected Pawn, RookRect, KnightRect, BishopRect, QueenRect or King.");
        //}

        //[Test]
        //public void ParseSide()
        //{
        //    Assert.That(PieceFactory.ParseSide("Black"), Is.EqualTo(PlayerSide.Black));
        //    Assert.That(PieceFactory.ParseSide("White"), Is.EqualTo(PlayerSide.White));
        //    Assert.Throws<Exception>(() => PieceFactory.ParseSide("Neutral"), "Invalid data when trying to parse CSV - encountered Neutral; expected Black or White.");
        //}

        //[Test]
        //public void ParsePiece()
        //{
        //    Position? position;
        //    board.TryLocate(Board.File.A, Rank.r2, out position);
        //    PieceIdentity pieceId = new PieceIdentity(position!, PieceRole.Pawn, PlayerSide.White);
        //    Assert.That(PieceFactory.PieceParser("White,Pawn,a,2"), Is.EqualTo(pieceId));

        //    board.TryLocate(Board.File.H, Rank.r1, out position);
        //    pieceId = new PieceIdentity(position!, PieceRole.RookRect, PlayerSide.White);
        //    Assert.That(PieceFactory.PieceParser("White,RookRect,h,1"), Is.EqualTo(pieceId));

        //    board.TryLocate(Board.File.H, Rank.r7, out position);
        //    pieceId = new PieceIdentity(position!, PieceRole.Pawn, PlayerSide.Black);
        //    Assert.That(PieceFactory.PieceParser("Black,Pawn,h,7"), Is.EqualTo(pieceId));

        //    board.TryLocate(Board.File.A, Rank.r8, out position);
        //    pieceId = new PieceIdentity(position!, PieceRole.RookRect, PlayerSide.Black);
        //    Assert.That(PieceFactory.PieceParser("Black,RookRect,a,8"), Is.EqualTo(pieceId));
        //}

        //[Test]
        //public void CreatePiece()
        //{
        //    PieceIdentity pieceId = PieceFactory.PieceParser("White,Pawn,a,2");
        //    BasePiece piece = new BasePiece(pieceId);
        //    Assert.That(PieceFactory.CreatePiece(pieceId), Is.EqualTo(piece));

        //    pieceId = PieceFactory.PieceParser("White,RookRect,h,1");
        //    piece = new BasePiece(pieceId);
        //    Assert.That(PieceFactory.CreatePiece(pieceId), Is.EqualTo(piece));

        //    pieceId = PieceFactory.PieceParser("Black,Pawn,h,7");
        //    piece = new BasePiece(pieceId);
        //    Assert.That(PieceFactory.CreatePiece(pieceId), Is.EqualTo(piece));

        //    pieceId = PieceFactory.PieceParser("Black,RookRect,a,8");
        //    piece = new BasePiece(pieceId);
        //    Assert.That(PieceFactory.CreatePiece(pieceId), Is.EqualTo(piece));
        //}

        [Test]
        public void InitPieces()
        {
            List<BasePiece> pieces = PieceFactory.InitializePieces();
            Assert.That(pieces.Count, Is.EqualTo(32));
        }
    }
}
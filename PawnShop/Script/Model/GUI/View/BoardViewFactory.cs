using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.GUI.Button.Model;
using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using PawnShop.Script.Model.GUI.GameElement;
using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Model.Piece;
using SplashKitSDK;
using static PawnShop.Script.Model.Board.Board;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using static PawnShop.Script.Model.Piece.BasePiece;
using static PawnShop.Script.Model.Piece.BasePiece.PieceRole;
using static PawnShop.Script.Model.Player.BasePlayer;
using static PawnShop.Script.Model.Player.BasePlayer.PlayerSide;

namespace PawnShop.Script.Model.GUI.View
{
    /// <summary>
    /// Static utility helper class to generate UI board elements.
    /// </summary>
    public static class BoardViewFactory
    {
        private readonly static string rootDir = "D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Asset\\Basic Chess Asset\\";

        private readonly static string boardDir = $"{rootDir}\\Boards";

        private readonly static string pieceDir = $"{rootDir}\\Pieces";

        private readonly static string positionDir = $"{rootDir}\\Positions";

        //public readonly static Bitmap BoardGraphic = new Bitmap("Board", $"{boardDir}\\Board_940_940.png");
        public readonly static Bitmap BoardGraphic = new Bitmap("Board", $"{boardDir}\\Board_720_720.png"); // for 1368x720 res

        //private readonly static float PositionSize = 117.5f; // for 2294x940 res
        private readonly static float PositionSize = 90; // for 1368x720 res
        private readonly static Dimension PositionDimension = new Dimension(PositionSize, PositionSize);

        private readonly static ImageContent selectedPosition =
            new ImageContent(new Bitmap($"selected_position_indicator", $"{positionDir}\\selected.png"));
        private readonly static ImageContent movablePosition =
            new ImageContent(new Bitmap($"movable_position_indicator", $"{positionDir}\\movable.png"));
        private readonly static ImageContent capturablePosition =
            new ImageContent(new Bitmap($"capturable_position_indicator", $"{positionDir}\\capturable.png"));

        public static IPrimitive.Position GetPosition(Coordinate coordinate)
        {
            float x;
            float y;
            switch (coordinate.File)
            {
                case Board.Board.File.A:
                    x = 0;
                    break;
                case Board.Board.File.B:
                    x = PositionSize;
                    break;
                case Board.Board.File.C:
                    x = PositionSize * 2;
                    break;
                case Board.Board.File.D:
                    x = PositionSize * 3;
                    break;
                case Board.Board.File.E:
                    x = PositionSize * 4;
                    break;
                case Board.Board.File.F:
                    x = PositionSize * 5;
                    break;
                case Board.Board.File.G:
                    x = PositionSize * 6;
                    break;
                case Board.Board.File.H:
                    x = PositionSize * 7;
                    break;
                default:
                    throw new Exception($"Invalid file: encountered {coordinate.File}");
            }
            switch (coordinate.Rank)
            {
                case Rank.r1:
                    y = PositionSize * 7;
                    break;
                case Rank.r2:
                    y = PositionSize * 6;
                    break;
                case Rank.r3:
                    y = PositionSize * 5;
                    break;
                case Rank.r4:
                    y = PositionSize * 4;
                    break;
                case Rank.r5:
                    y = PositionSize * 3;
                    break;
                case Rank.r6:
                    y = PositionSize * 2;
                    break;
                case Rank.r7:
                    y = PositionSize;
                    break;
                case Rank.r8:
                    y = 0;
                    break;
                default:
                    throw new Exception($"Invalid rank: encountered {coordinate.Rank}");
            }
            return new IPrimitive.Position(x, y);
        }

        private static PrimitiveRect GetRect(Coordinate coordinate)
            => new PrimitiveRect(GetPosition(coordinate), PositionDimension);

        public static InvisibleButton InitPositionButton(Position position)
        {
            InvisibleButton clickablePosition = new InvisibleButton
            (
                GetRect(position.Coordinate)
            );
            return clickablePosition;
        }

        public static PositionIndicator InitPositionIndicator(Position position)
        {
            PositionIndicator clickablePosition = new PositionIndicator
            (
                GetRect(position.Coordinate),
                selectedPosition,
                movablePosition,
                capturablePosition
            );
            return clickablePosition;
        }

        public static PieceElement InitPiece(BasePiece piece)
        {
            PieceElement pieceElement = new PieceElement
            (
                GetRect(piece.StartPosition.Coordinate),
                GetPieceImage(piece.Role, piece.Side)
            );
            return pieceElement;
        }

        public static ImageButtonUIState GetPieceImage(PieceRole role, PlayerSide side)
        {
            string sideName;
            string roleName;

            switch (side)
            {
                case Black:
                    sideName = "black";
                    break;
                case White:
                    sideName = "white";
                    break;
                default:
                    throw new Exception($"Invalid side: encountered {side}");
            }

            switch (role)
            {
                case Pawn:
                    roleName = "pawn";
                    break;
                case Rook:
                    roleName = "rook";
                    break;
                case Knight:
                    roleName = "knight";
                    break;
                case Bishop:
                    roleName = "bishop";
                    break;
                case Queen:
                    roleName = "queen";
                    break;
                case King:
                    roleName = "king";
                    break;
                default:
                    throw new Exception($"Invalid role: encountered {role}");
            }

            ImageButtonUIStateData activeUI = new ImageButtonUIStateData(new ImageContent(
                new Bitmap($"{sideName}_{roleName}_active", $"{pieceDir}\\{sideName}_{roleName}_active.png")));
            ImageButtonUIStateData inactiveUI = new ImageButtonUIStateData(new ImageContent(
                new Bitmap($"{sideName}_{roleName}_inactive", $"{pieceDir}\\{sideName}_{roleName}_inactive.png")));
            ImageButtonUIStateData pressedUI = new ImageButtonUIStateData(new ImageContent(
                new Bitmap($"{sideName}_{roleName}_pressed", $"{pieceDir}\\{sideName}_{roleName}_pressed.png")));
            ImageButtonUIStateData selectedUI = new ImageButtonUIStateData(new ImageContent(
                new Bitmap($"{sideName}_{roleName}_selected", $"{pieceDir}\\{sideName}_{roleName}_selected.png")));
            return new ImageButtonUIState(activeUI, inactiveUI, pressedUI, selectedUI);
        }
    }
}

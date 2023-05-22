using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using static PawnShop.Script.Model.Piece.BasePiece;
using static PawnShop.Script.Model.Piece.BasePiece.PieceRole;

namespace PawnShop.Script.Model.GUI.View
{
    /// <summary>
    /// Static utility helper class to generate UI elements for <c>Upgrade</c> mode.
    /// </summary>
    public static class UpgradeViewFactory
    {
        private static readonly string rootDir = "D:\\Coding\\Projects\\Git\\PawnShop\\PawnShop\\Asset";
        private static readonly string upgradeDir = $"{rootDir}\\Misc\\Upgrade";
        private static readonly string canvasDir = $"{rootDir}\\PXUI-Basic\\panel_600_300.png";
        public static readonly Bitmap CanvasGraphic = new Bitmap("popup_canvas", canvasDir);

        public static readonly int CanvasX = 340;
        public static readonly int CanvasY = 285;

        private static readonly int knightX = 415;
        private static readonly int bishopX = 527;
        private static readonly int rookX = 639;
        private static readonly int queenX = 751;

        private static readonly int buttonY = 330;
        private static readonly int buttonSize = 112;

        private static readonly PrimitiveRect KnightRect =
            new PrimitiveRect(knightX, buttonY, buttonSize, buttonSize);
        private static readonly PrimitiveRect BishopRect =
            new PrimitiveRect(bishopX, buttonY, buttonSize, buttonSize);
        private static readonly PrimitiveRect RookRect =
            new PrimitiveRect(rookX, buttonY, buttonSize, buttonSize);
        private static readonly PrimitiveRect QueenRect
            = new PrimitiveRect(queenX, buttonY, buttonSize, buttonSize);

        public static PrimitiveRect GetRect(PieceRole role)
        {
            switch (role)
            {
                case Knight:
                    return KnightRect;
                case Bishop:
                    return BishopRect;
                case Rook:
                    return RookRect;
                case Queen:
                    return QueenRect;
                default:
                    throw new Exception($"Invalid role encountered: {role}");
            }
        }

        public static ImageButtonUIState GetUIState(PieceRole role)
        {
            string piece = role.ToString().ToLower();
            ImageContent inactive =
                new ImageContent(new Bitmap($"inactive_upgrade_{piece}", $"{upgradeDir}\\{piece}_upgrade_inactive.png"));
            ImageContent active =
                new ImageContent(new Bitmap($"active_upgrade_{piece}", $"{upgradeDir}\\{piece}_upgrade_active.png"));
            ImageContent selected =
                new ImageContent(new Bitmap($"selected_upgrade_{piece}", $"{upgradeDir}\\{piece}_upgrade_selected.png"));
            ImageContent pressed =
                new ImageContent(new Bitmap($"pressed_upgrade_{piece}", $"{upgradeDir}\\{piece}_upgrade_pressed.png"));
            return new ImageButtonUIState(
                new ImageButtonUIStateData(active),
                new ImageButtonUIStateData(inactive),
                new ImageButtonUIStateData(pressed),
                new ImageButtonUIStateData(selected));
        }
    }
}

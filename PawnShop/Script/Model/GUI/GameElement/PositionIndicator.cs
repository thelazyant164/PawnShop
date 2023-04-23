using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.GUI.Component;
using PawnShop.Script.Model.GUI.Interface;
using static PawnShop.Script.Model.Board.Position;
using static PawnShop.Script.Model.Board.Position.HighlightType;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.GameElement
{
    public sealed class PositionIndicator : RectangularComponent, IImage
    {
        private readonly ImageContent selectedUI;
        private readonly ImageContent movableUI;
        private readonly ImageContent capturableUI;

        public ImageContent Content { get; private set; }

        public PositionIndicator(PrimitiveRect rect, 
            ImageContent selectedUI, 
            ImageContent movableUI, 
            ImageContent capturableUI) : base(rect) 
        {
            this.selectedUI = selectedUI; 
            this.movableUI = movableUI; 
            this.capturableUI = capturableUI;
        }

        public void ToggleHighlight(HighlightType type)
        {
            Visible = true;
            switch (type) 
            {
                case Selected:
                    Content = selectedUI;
                    break;
                case Movable:
                    Content = movableUI;
                    break;
                case Capturable: 
                    Content = capturableUI;
                    break;
                default:
                    Visible = false;
                    break;
            }
        }

        public override void Show() {} // override show functionality - indicator's shown status changed only by responding to event

        public override void Draw()
        {
            if (!Visible) return;
            SplashKit.DrawBitmap(Content.Texture, Rectangle.X, Rectangle.Y);
        }
    }
}

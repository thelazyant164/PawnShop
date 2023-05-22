using PawnShop.Script.Model.GUI.Button.UIState;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using PawnShop.Script.Model.GUI.Interface;
using SplashKitSDK;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using static PawnShop.Script.Model.GUI.Interface.ITextGraphic;

namespace PawnShop.Script.Model.GUI.Button.Model
{
    public sealed class TextButton
        : BaseButton<TextButtonUIState, TextButtonUIStateData>,
            ITextGraphic
    {
        public TextGraphicContent Content
        {
            get => UIState!.GetState(state.State).Content;
        }

        public TextButton(PrimitiveRect rect, TextButtonUIState textButtonUI)
            : base(rect, textButtonUI) { }

        public override void Draw()
        {
            if (!Visible)
                return;
            SplashKit.DrawBitmap(Content.Texture, X, Y);
        }
    }
}

using PawnShop.Script.Model.GUI.GameElement;
using PawnShop.Script.Model.GUI.Label;
using PawnShop.Script.Model.Move;
using PawnShop.Script.Model.Player;
using PawnShop.Script.System.GUI.Input;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.View
{
    public sealed class GameOverView : BaseView
    {
        public GameOverView(BasePlayer player, InputSystem inputController, MatchStatistic matchStat, TextLabel outcome) : base(player, inputController)
        {
            Visibles.Add(outcome);
            Visibles.Add(new MatchStatisticLabel(matchStat));
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(UpgradeViewFactory.CanvasGraphic, UpgradeViewFactory.CanvasX, UpgradeViewFactory.CanvasY);
            base.Draw();
        }
    }
}

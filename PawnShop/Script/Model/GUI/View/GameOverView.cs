using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.GUI.Button.Model;
using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Model.GUI.GameElement;
using static PawnShop.Script.Model.GUI.Interface.IClickable;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.System.GUI.Input;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player;
using PawnShop.Script.Manager.GUI;
using PawnShop.Script.Model.Coin;
using PawnShop.Script.Model.Move;
using PawnShop.Script.Model.GUI.Label;

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

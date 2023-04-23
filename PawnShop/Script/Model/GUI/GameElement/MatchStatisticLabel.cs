using PawnShop.Script.Model.GUI.Button.Model;
using PawnShop.Script.Model.GUI.Component;
using PawnShop.Script.Model.GUI.Label;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using static PawnShop.Script.Model.GUI.Interface.IPrimitive;
using static PawnShop.Script.Model.GUI.Interface.ITextGraphic;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using SplashKitSDK;
using PawnShop.Script.Model.Player;
using PawnShop.Script.Model.Move;

namespace PawnShop.Script.Model.GUI.GameElement
{
    public sealed class MatchStatisticLabel : VisibleComponent
    {
        private static readonly int x = 450;
        private static readonly int y = 345;
        private static readonly int lineWidth = 10;

        public static readonly Position TitlePosition = new Position(x, y - lineWidth);

        private readonly TextLabel totalTimeElapsed;
        private readonly TextLabel timeElapsed;
        private readonly TextLabel averageTurnDuration;
        private readonly TextLabel turnNo;
        private readonly TextLabel coinCollected;
        private readonly TextLabel coinSpent;
        private readonly TextLabel pieceCaptured;
        private readonly TextLabel piecePawned;
        private readonly TextLabel pieceUpgraded;

        public MatchStatisticLabel(MatchStatistic matchStat) : base(Position.Origin) 
        {
            totalTimeElapsed = new TextLabel(new Position(x, y), $"Match duration: {matchStat.TotalTimeElapsed}");
            timeElapsed = new TextLabel(new Position(x, y + lineWidth), $"Total turn duration: {matchStat.TimeElapsed}");
            averageTurnDuration = new TextLabel(new Position(x, y + lineWidth * 2), $"Average turn duration: {matchStat.AverageTurnDuration}");
            turnNo = new TextLabel(new Position(x, y + lineWidth * 3), $"Turn played: {matchStat.TurnNo}");
            coinCollected = new TextLabel(new Position(x, y + lineWidth * 4), $"Coin collected: {matchStat.CoinCollected}");
            coinSpent = new TextLabel(new Position(x, y + lineWidth * 5), $"Coin spent: {matchStat.CoinSpent}");
            pieceCaptured = new TextLabel(new Position(x, y + lineWidth * 6), $"Piece captured: {matchStat.PieceCaptured}");
            piecePawned = new TextLabel(new Position(x, y + lineWidth * 7), $"Piece pawned: {matchStat.PiecePawned}");
            pieceUpgraded = new TextLabel(new Position(x, y + lineWidth * 8), $"Piece upgraded: {matchStat.PieceUpgraded}");
        }

        public override void Show()
        {
            totalTimeElapsed.Show();
            timeElapsed.Show();
            averageTurnDuration.Show();
            turnNo.Show();
            coinCollected.Show();
            coinSpent.Show();
            pieceCaptured.Show();
            piecePawned.Show();
            pieceUpgraded.Show();
            base.Show();
        }

        public override void Hide()
        {
            totalTimeElapsed.Hide();
            timeElapsed.Hide();
            averageTurnDuration.Hide();
            turnNo.Hide();
            coinCollected.Hide();
            coinSpent.Hide();
            pieceCaptured.Hide();
            piecePawned.Hide();
            pieceUpgraded.Hide();
            base.Hide();
        }

        public override void Draw()
        {
            if (!Visible) return;
            totalTimeElapsed.Draw();
            timeElapsed.Draw();
            averageTurnDuration.Draw();
            turnNo.Draw();
            coinCollected.Draw();
            coinSpent.Draw();
            pieceCaptured.Draw();
            piecePawned.Draw();
            pieceUpgraded.Draw();
        }
    }
}

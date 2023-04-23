using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Manager.GUI;
using PawnShop.Script.Model.GUI.View;
using PawnShop.Script.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Move;
using PawnShop.Script.Model.GUI.Label;

namespace PawnShop.Script.System.Gameplay.GameState
{
    public abstract class GameOver : GameState
    {
        protected readonly BasePlayer player = GameManager.Instance.PlayerManager.CurrentPlayer;
        private readonly PlayerViewManager playerView = ViewManager.Instance.PlayerView;
        protected abstract TextLabel matchOutcome { get; }
        private GameOverView? gameOverView;

        public GameOver(GameStateSystem gameStateSystem) : base(gameStateSystem) { }

        public override void Start()
        {
            gameOverView = new GameOverView(player, playerView.InputController, 
                new MatchStatistic(player), matchOutcome);
            playerView.AddView(gameOverView);
        }

        public override void Terminate() => playerView.RemoveView(gameOverView!);
    }
}

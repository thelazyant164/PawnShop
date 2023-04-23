using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.System.Gameplay.GameState
{
    public class GameInProgress : GameState
    {
        private readonly BasePlayer? player;
        public static event EventHandler? OnRefresh;

        public GameInProgress(GameStateSystem gameStateSystem) : base(gameStateSystem) 
        {
            PlayerManager playerManager = GameManager.Instance.PlayerManager;
            player = playerManager.CurrentPlayer;
        }

        public override void Start()
        {
            OnRefresh?.Invoke(this, EventArgs.Empty);
            if (player != null && !player.HasValidMoves())
            {
                if (player.IsUnderCheck())
                {
                    GameStateSystem.SetGameState(new Checkmate(GameStateSystem));
                }
                else
                {
                    GameStateSystem.SetGameState(new Stalemate(GameStateSystem));
                }
            }
        }
    }
}

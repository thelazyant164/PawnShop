using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Move;
using PawnShop.Script.Model.Player;

namespace PawnShop.Script.System.Gameplay.GameState
{
    public class GameInProgress : GameState
    {
        private readonly History history;
        private readonly BasePlayer? player;
        public static event EventHandler? OnNewTurn;
        public static event EventHandler? OnRefresh;

        public GameInProgress(GameStateSystem gameStateSystem) : base(gameStateSystem)
        {
            PlayerManager playerManager = GameManager.Instance.PlayerManager;
            history = GameManager.Instance.History;
            player = playerManager.CurrentPlayer;
        }

        public override void Start()
        {
            if (history.IsNewTurn) OnNewTurn?.Invoke(this, EventArgs.Empty);
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

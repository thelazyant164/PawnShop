using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.Manager.Gameplay
{
    /// <summary>
    /// Manager class to keep track of the current turn.
    /// </summary>
    public sealed class PlayerManager
    {
        public event EventHandler<BasePlayer>? OnTurnChange;

        /// <summary>
        /// Get the current <c>PlayerSide</c>.
        /// </summary>
        public PlayerSide CurrentTurn { get; private set; }

        /// <summary>
        /// Get the current <c>PlayerType</c>.
        /// </summary>
        public PlayerType CurrentType { get; private set; }

        /// <summary>
        /// Get the current <c>BasePlayer</c>.
        /// </summary>
        public BasePlayer CurrentPlayer { get; private set; }

        /// <summary>
        /// Get the opponent <c>BasePlayer</c>.
        /// </summary>
        public BasePlayer Opponent { get; private set; }

        private readonly List<BasePlayer> activePlayers;

        public PlayerManager(GameManager.GameConfig config)
        {
            activePlayers = new List<BasePlayer>
            {
                new BasePlayer(PlayerSide.White, config.White),
                new BasePlayer(PlayerSide.Black, config.Black)
            };
            OnTurnChange += (sender, currentPlayer) =>
            {
                CurrentPlayer = currentPlayer;
                CurrentTurn = currentPlayer.Side;
                CurrentType = currentPlayer.Type;
                Opponent = activePlayers.Find(player => player.Side != CurrentTurn)!;
            };
        }

        public void Update()
        {
            foreach (BasePlayer player in activePlayers)
            {
                player.Progress();
            }
        }

        /// <summary>
        /// Get a player by their <c>PlayerSide</c>.
        /// </summary>
        /// <param name="side">The <c>PlayerSide</c> of the player to get.</param>
        /// <returns>The <paramref name="side"/> (<value>Black</value> or <value>White</value>) player.</returns>
        public BasePlayer GetPlayer(PlayerSide side) => activePlayers.Find(player => player.Side == side)!;

        /// <summary>
        /// Starts the game.
        /// </summary>
        /// <remarks>To be called at the start of the game, after all pieces have been initialized.</remarks>
        /// <param name="whiteStarts">Specifies the starting player. By default, <c>White</c> starts first.</param>
        public void Begin(bool whiteStarts = true)
        {
            OnTurnChange?.Invoke(this, whiteStarts ? activePlayers[0] : activePlayers[1]);
            CurrentPlayer.StartTurn();
        }

        /// <summary>
        /// Moves onto the next turn.
        /// </summary>
        /// <remarks>To be called before terminating the old player's turn.</remarks>
        public void NextTurn()
        {
            OnTurnChange?.Invoke(this, Opponent);
            CurrentPlayer.StartTurn();
        }
    }
}

using PawnShop.Script.Model.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Utility;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.System.Gameplay;
using static PawnShop.Script.Model.Player.BasePlayer.PlayerSide;

namespace PawnShop.Script.Model.Coin
{
    /// <summary>
    /// Static utility class to spawn <c>Coin</c>s.
    /// </summary>
    public static class CoinSpawner
    {
        public static event StaticEvent<Coin>.Handler? OnSpawn;

        private static Board.Board board;

        /// <summary>
        /// Static method to setup the coin1 spawner.
        /// </summary>
        /// <remarks>Call this before calling <c>GetSpawnPosition</c>.</remarks>
        public static void Init()
        {
            board = GameManager.Instance.Board;
        }

        /// <summary>
        /// Static method to spawn a <c>Coin</c> at an empty <c>Position</c>.
        /// </summary>
        /// <param name="position">The <c>Position</c> to spawn the new <c>Coin</c>.</param>
        /// <returns>The <c>Coin</c> spawned.</returns>
        /// <exception cref="Exception"/>
        public static Coin Spawn(Position position)
        {
            if (position.Coin != null) 
                throw new Exception("The supplied position already has a coin1.");
            Coin newCoin = new Coin(position);
            OnSpawn?.Invoke(newCoin);
            return newCoin;
        }

        /// <summary>
        /// Static method to get a valid <c>Position</c> for <c>Coin</c> spawn.
        /// </summary>
        /// <remarks>Will randomly select a position on the board, then check if the position is empty.</remarks>
        /// <returns>An empty <c>Position</c>, if one is randomly selected. <value>Null</value> otherwise.</returns>
        public static Position? GetSpawnPosition()
        {
            board.TryLocateRandomEmpty(out Position? position);
            return position;
        }
    }
}

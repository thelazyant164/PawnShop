using PawnShop.Script.Model.Coin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Board;
using PawnShop.Script.System.Gameplay.GameState;
using PawnShop.Script.Model.Player;
using static PawnShop.Script.Model.Player.BasePlayer.PlayerSide;
using System.Collections;
using System.ComponentModel;

namespace PawnShop.Script.Manager.Gameplay
{
    public sealed class CoinManager
    {
        private static readonly Random random = new Random();
        private const int MAX_SPAWN_CAPACITY = 10;
        private const int MAX_SPAWN_RATE = 2;
        private int spawnRate = 0;
        private int spawned = 0;
        private List<Coin> coins { get; } = new List<Coin>();

        public CoinManager(PlayerManager playerManager) 
        {
            CoinSpawner.OnSpawn += OnSpawn;
            GameInProgress.OnRefresh += OnRefresh;
        }

        private void OnRefresh(object? sender, EventArgs e)
        {
            int chance = coins.Any() ? 0 : random.Next(100); // will not spawn new coin if existing coins on board
            switch (chance)
            {
                case >= 70: // 30% chance to spawn coin
                    spawnRate = chance >= 90 ? MAX_SPAWN_RATE : MAX_SPAWN_RATE - 1; // 10% chance to spawn 2 coins, 20% to spawn 1
                    break;
                default:
                    spawnRate = 0;
                    break;
            }
        }

        private void OnSpawn(Coin coin) 
        {
            coins.Add(coin);
            coin.OnCollect += OnCollect;
        }

        private void OnCollect(object? sender, Coin coin)
        {
            coin.OnCollect -= OnCollect;
            coin.OnRestore += OnRestore;
            coins.Remove(coin);
        }

        private void OnRestore(object? sender, Coin coin)
        {
            coin.OnRestore -= OnRestore;
            coin.OnCollect += OnCollect;
            coins.Add(coin);
        }

        public void Update()
        {
            while (coins.Count < spawnRate)
            {
                Position? position = CoinSpawner.GetSpawnPosition();
                if (position == null) break;
                CoinSpawner.Spawn(position);
                spawned++;
                if (spawned == MAX_SPAWN_CAPACITY)
                {
                    GameInProgress.OnRefresh -= OnRefresh;
                    spawnRate = 0;
                }
            }
        }
    }
}

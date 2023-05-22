using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Coin;
using PawnShop.Script.System.Gameplay.GameState;

namespace PawnShop.Script.Manager.Gameplay
{
    /// <summary>
    /// Manager class to manage randomness of coin spawn during a match.
    /// </summary>
    public sealed class CoinManager
    {
        private const int MAX_SPAWN_CAPACITY = 20;
        private const int MAX_SPAWN_RATE = 2;
        private int spawnRate = 0;
        private int spawned = 0;
        private List<Action?> coinBuffer = new();
        private readonly CoinSpawnHistory history = new CoinSpawnHistory();
        public CoinSpawnHistory History => history;
        private List<Coin> coins { get; } = new();
        private List<Coin> activeCoins { get; } = new();

        public CoinManager()
        {
            CoinSpawner.OnSpawn += OnSpawn;
            PlayerManager.OnStartGame += (object? sender, EventArgs e) => GameInProgress.OnNewTurn += OnNewTurn;
        }

        private void OnNewTurn(object? sender, EventArgs e)
        {
            Age();
            RefreshSpawnRate(); // only refresh spawn rate on new turn, not on re-enactment
            SpawnToCapacity();
        }

        private void RefreshSpawnRate()
        {
            int chance = activeCoins.Any() ? 0 : new Random().Next(100); // will not spawn new coin if existing coins on board
            switch (chance)
            {
                case >= 70: // 30% chance to spawn coin1
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
            coin.OnCollect += (object? sender, Coin coin) => coinBuffer.Add(() => activeCoins.Remove(coin));
            coin.OnRestore += (object? sender, Coin coin) => coinBuffer.Add(() =>
            {
                activeCoins.Add(coin);
                if (coin.Expired) spawned++;
            });
            coin.OnExpire += (object? sender, Coin coin) => coinBuffer.Add(() =>
            {
                activeCoins.Remove(coin);
                spawned--;
            });
        }

        private void SpawnToCapacity()
        {
            List<Coin> spawnedCoins = new();
            while (spawnedCoins.Count < spawnRate && spawned < MAX_SPAWN_CAPACITY)
            {
                Position? position = CoinSpawner.GetSpawnPosition();
                if (position == null) continue;
                spawnedCoins.Add(CoinSpawner.Spawn(position));
                spawned++;
            }
            history.Record(new CoinSpawnEvent(spawnedCoins));
        }

        private void Age() => coins.ForEach(coin => coin.Age());
        private void Deage() => coins.ForEach(coin => coin.Deage());

        public void Execute()
        {
            Age();
            history.Execute();
        }

        public void Abort()
        {
            Deage();
            history.Abort();
        }

        public void Progress()
        {
            foreach (Action? action in coinBuffer)
            {
                action?.Invoke();
            }
            coinBuffer.Clear();
        }
    }
}

namespace PawnShop.Script.Model.Coin
{
    public sealed class CoinSpawnEvent
    {
        private readonly List<Coin> spawned;

        public CoinSpawnEvent(List<Coin> spawned)
        {
            this.spawned = spawned;
        }

        public void Execute()
        {
            foreach (Coin coin in spawned)
            {
                coin.Restore();
            }
        }

        public void Abort()
        {
            foreach (Coin coin in spawned)
            {
                coin.Collect();
            }
        }
    }
}

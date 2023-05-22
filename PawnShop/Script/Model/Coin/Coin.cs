using PawnShop.Script.Model.Board;

namespace PawnShop.Script.Model.Coin
{
    public class Coin
    {
        private const int MIN_LIFESPAN = 8;
        private const int MAX_LIFESPAN = 16;

        private static int hashCount = 0;
        private readonly int hashCode;
        private int lifespan = new Random().Next(MIN_LIFESPAN, MAX_LIFESPAN + 1);

        public Position SpawnPosition { get; private set; }
        public bool Expired { get; private set; } = false;

        public int Value => 1;

        public event EventHandler<Coin>? OnCollect;
        public event EventHandler<Coin>? OnRestore;
        public event EventHandler<Coin>? OnExpire;

        public Coin(Position position)
        {
            hashCode = hashCount;
            hashCount++;
            SpawnPosition = position;
            OnRestore += SpawnPosition.AddCoin;
        }

        public void Age()
        {
            lifespan--;
            if (lifespan == 0)
            {
                Expire();
            }
        }

        public void Deage()
        {
            if (lifespan == 0)
            {
                Restore();
            }
            lifespan++;
        }

        public void Collect()
        {
            OnCollect?.Invoke(this, this);
            OnCollect -= SpawnPosition.RemoveCoin;
            OnExpire -= SpawnPosition.RemoveCoin;
            OnRestore += SpawnPosition.AddCoin;
        }

        public void Restore()
        {
            OnRestore?.Invoke(this, this); // TODO: make this more elegant. Right now, this must come before Expired = false, so that CoinManager knows to increment spawned count again
            Expired = false;
            OnRestore -= SpawnPosition.AddCoin;
            OnCollect += SpawnPosition.RemoveCoin;
            OnExpire += SpawnPosition.RemoveCoin;
        }

        private void Expire()
        {
            OnExpire?.Invoke(this, this);
            Expired = true;
            OnExpire -= SpawnPosition.RemoveCoin;
            OnCollect -= SpawnPosition.RemoveCoin;
            OnRestore += SpawnPosition.AddCoin;
        }

        public override int GetHashCode() => hashCode;

        public override string ToString() => $"Coin $1 @ {SpawnPosition}";
    }
}

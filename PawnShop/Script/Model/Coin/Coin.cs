using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Board;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.Model.Coin
{
    public class Coin
    {
        private static int hashCount = 0;
        private readonly int hashCode;

        public Position SpawnPosition { get; private set; }

        public int Value => 1;

        public event EventHandler<Coin>? OnCollect;
        public event EventHandler<Coin>? OnRestore;

        public Coin(Position position)
        {
            hashCode = hashCount;
            hashCount++;
            SpawnPosition = position;
            OnCollect += position.OnCollectCoin;
            OnRestore += position.OnAddCoin;
            OnRestore?.Invoke(this, this);
        }

        public void InvokeOnCollect(object? sender, EventArgs e) => OnCollect?.Invoke(sender, this);

        public void InvokeOnRestore(object? sender, EventArgs e) => OnRestore?.Invoke(sender, this);

        public override int GetHashCode() => hashCode;

        public override string ToString() => $"Coin $1 @ {SpawnPosition}";
    }
}

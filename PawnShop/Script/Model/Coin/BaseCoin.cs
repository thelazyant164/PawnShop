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
    public class BaseCoin
    {
        public struct CoinIdentity
        {
            public readonly Position SpawnPosition;
            public readonly int Value;

            public CoinIdentity(
                Position spawnPosition,
                int value
            )
            {
                SpawnPosition = spawnPosition;
                Value = value;
            }

            public override bool Equals(object? obj)
            {
                if (obj is not CoinIdentity) return false;
                return SpawnPosition.Equals(((CoinIdentity)obj)!.SpawnPosition);
            }

            public override string ToString()
            {
                return $"Coin ${Value} @ {SpawnPosition}";
            }
        }

        private readonly CoinIdentity identity;

        public BaseCoin(CoinIdentity identity)
        {
            this.identity = identity;
        }

        public Position SpawnPosition
        {
            get => identity.SpawnPosition;
        }

        public int Value
        {
            get => identity.Value;
        }


        public void OnSelect(object? sender, EventArgs e) => Console.WriteLine($"Selected {this}");

        public void OnClick(object? sender, EventArgs e) => Console.WriteLine($"Clicked on {this}");

        public override bool Equals(object? obj)
        {
            if (obj is not BaseCoin) return false;
            return identity.Equals((obj as BaseCoin)!.identity);
        }

        public override string ToString()
        {
            return identity.ToString();
        }
    }
}

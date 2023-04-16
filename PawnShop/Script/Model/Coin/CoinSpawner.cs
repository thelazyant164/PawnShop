using PawnShop.Script.Model.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.Coin
{
    public sealed class CoinSpawner
    {
        public event EventHandler<Position> OnCoinSpawn;
    }
}

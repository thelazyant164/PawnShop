using PawnShop.Script.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Utility;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.Model.Move
{
    public sealed class Turn
    {
        public static event StaticEvent<Turn>.Handler? OnPlay;

        public readonly PlayerSide Side;
        public readonly BaseMove Move;
        public readonly DateTime date;

        public Turn(PlayerSide side, BaseMove move) 
        {
            Side = side;
            Move = move;
            date = DateTime.Now;
            Console.WriteLine($"{side} played {move} at {date}");
            OnPlay?.Invoke(this);
        }
    }
}

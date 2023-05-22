using PawnShop.Script.Utility;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.Model.Move
{
    public sealed class Turn
    {
        public static event StaticEvent<Turn>.Handler? OnPlay;

        public readonly PlayerSide Side;
        public readonly BaseMove Move;
        public readonly DateTime Date;

        public Turn(PlayerSide side, BaseMove move)
        {
            Side = side;
            Move = move;
            Date = DateTime.Now;
            //Console.WriteLine($"{side} played {move} at {Date}");
            OnPlay?.Invoke(this);
        }
    }
}

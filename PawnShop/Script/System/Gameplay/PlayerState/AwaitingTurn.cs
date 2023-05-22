using PawnShop.Script.Manager.Gameplay;

namespace PawnShop.Script.System.Gameplay.PlayerState
{
    public class AwaitingTurn : PlayerState
    {
        public AwaitingTurn(PlayerStateSystem playerStateSystem) : base(playerStateSystem)
        {
        }

        public override void Start()
        {
            GameManager.Instance.PlayerManager?.NextTurn();
        }

        public override string ToString() => $"{PlayerStateSystem.Side} is awaiting turn";
    }
}

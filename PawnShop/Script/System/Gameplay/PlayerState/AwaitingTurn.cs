using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Manager.GUI;
using PawnShop.Script.Utility;

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

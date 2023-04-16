using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Cache;
using PawnShop.Script.Model.Player;
using PawnShop.Script.Model.Player.Controller;
using PawnShop.Script.System.GUI.Input;
using PawnShop.Script.Utility;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.System.Gameplay.PlayerState
{
    public class PlayerStateSystem : StateMachine
    {
        public SelectionCache Cache { get; private set; }

        public PlayerController Controller { get; private set; }

        public PlayerSide Side { get; private set; }

        public PlayerStateSystem(PlayerSide side, SelectionCache cache, PlayerController controller) : base()
        {
            Side = side;
            Cache = cache;
            Controller = controller;
            SetPlayerState(new AwaitingTurn(this));
        }

        public PlayerState CurrentPlayerState
        {
            get => (PlayerState)CurrentState;
        }

        public void SetPlayerState(PlayerState newPlayerState)
        {
            SetState(newPlayerState);
        }
    }
}

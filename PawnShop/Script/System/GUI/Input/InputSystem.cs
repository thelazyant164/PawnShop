using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Model.Player;
using PawnShop.Script.System.Gameplay.PieceState;
using PawnShop.Script.Utility;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.System.GUI.Input
{
    public sealed class InputSystem : StateMachine
    {
        public BasePlayer Player { get; }
        public InputState CurrentInputState => (InputState)CurrentState;

        public InputSystem(BasePlayer player)
        {
            Player = player;
            PlayerManager playerManager = GameManager.Instance.PlayerManager;
            playerManager.OnTurnChange += OnTurnChange;

            SetState(playerManager.CurrentTurn == Player.Side 
                ? new InputEnabled(this) 
                : new InputDisabled(this));
        }

        private void OnTurnChange(object? sender, BasePlayer player)
        {
            if (Player.Side == player.Side)
            {
                SetState(new InputEnabled(this));
            }
            else
            {
                SetState(new InputDisabled(this));
            }
        }
    }
}

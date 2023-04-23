using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Player;
using PawnShop.Script.Utility;

namespace PawnShop.Script.System.Gameplay.GameState
{
    public sealed class GameStateSystem : StateMachine
    {
        public void Init(PlayerManager playerManager)
        {
            playerManager.OnTurnChange += OnTurnChange;
        }

        private void OnTurnChange(object? sender, BasePlayer player) 
            => SetGameState(new GameInProgress(this));

        public GameState CurrentGameState
        {
            get => (GameState)CurrentState;
        }

        public void SetGameState(GameState newGameState)
        {
            SetState(newGameState);
        }
    }
}

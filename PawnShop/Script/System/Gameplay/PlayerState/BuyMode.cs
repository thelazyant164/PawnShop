using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Move;
using PawnShop.Script.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.Board.Position.HighlightType;

namespace PawnShop.Script.System.Gameplay.PlayerState
{
    public sealed class BuyMode : PlayerState
    {
        public static event EventHandler? OnEnter;
        public static event EventHandler? OnExit;

        private BasePlayer player => GameManager.Instance.PlayerManager
            .GetPlayer(PlayerStateSystem.Side);
        private Position? position => PlayerStateSystem.Cache.SelectedPosition;
        private bool buyMode => PlayerStateSystem.Cache.BuyMode;

        private IReadOnlySet<Position> buyPositions;

        public BuyMode(PlayerStateSystem playerStateSystem) : base(playerStateSystem)
        {
            buyPositions = !player.IsUnderCheck() ? player.King.GetAllMoves() : new HashSet<Position>();
        }

        public override void Start()
        {
            OnEnter?.Invoke(this, EventArgs.Empty);
            foreach (Position position in buyPositions)
            {
                position.ToggleResponseToClick(true);
                position.InvokeOnHighlight(this, Selected);
            }
        }

        public override void Progress()
        {
            if (!buyMode)
            {
                PlayerStateSystem.SetPlayerState(new PlanningTurn(PlayerStateSystem));
            }
            else if (position != null)
            {
                new Turn(PlayerStateSystem.Side, BaseMove.Plan(position));
                PlayerStateSystem.SetPlayerState(new AwaitingTurn(PlayerStateSystem));
            }
        }

        public override void Terminate()
        {
            foreach (Position position in buyPositions)
            {
                position.ToggleResponseToClick(false);
                position.InvokeOnHighlight(this, None);
            }
            PlayerStateSystem.Cache.ExitBuyMode();
            PlayerStateSystem.Cache.Clear();
            OnExit?.Invoke(this, EventArgs.Empty);
        }

        public override string ToString() => $"entered {PlayerStateSystem.Side}'s buy mode";
    }
}

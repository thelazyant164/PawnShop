using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Manager.GUI;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Move;
using PawnShop.Script.Model.Piece;

namespace PawnShop.Script.System.Gameplay.PlayerState
{
    public class PlanningTurn : PlayerState
    {
        private BasePiece? piece => PlayerStateSystem.Cache.SelectedPiece;
        private Position? position => PlayerStateSystem.Cache.SelectedPosition;

        public PlanningTurn(PlayerStateSystem playerStateSystem) : base(playerStateSystem) 
        {
            Console.WriteLine($"moved onto {this}");
        }

        public override void Progress() 
        {
            if (piece != null && position != null) 
            {
                new Turn(PlayerStateSystem.Side, BaseMove.Plan(piece, position));
                PlayerStateSystem.SetPlayerState(new AwaitingTurn(PlayerStateSystem));
            }
        }

        public override void Terminate()
        {
            PlayerStateSystem.Cache.Clear();
            GameManager.Instance.TurnSystem!.NextTurn();
        }

        public override string ToString() => $"{PlayerStateSystem.Side}'s turn";
    }
}

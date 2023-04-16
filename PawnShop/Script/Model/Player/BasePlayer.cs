using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Cache;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player.Controller;
using PawnShop.Script.System.Gameplay.PlayerState;
using static PawnShop.Script.Model.Piece.BasePiece;

namespace PawnShop.Script.Model.Player
{
    public class BasePlayer
    {
        public enum PlayerType
        {
            AI,
            Manual
        }

        public enum PlayerSide
        {
            White,
            Black
        }

        private readonly PlayerInfo info;
        private readonly PlayerStateSystem state;
        private readonly PlayerController controller;
        private readonly SelectionCache selectionCache;

        public PlayerSide Side => info.Side;

        public PlayerType Type => info.Type;

        public SelectionCache Cache => selectionCache;

        public IReadOnlySet<Position> Reign => info.Reign;

        public BasePiece King;

        public BasePiece? SelectedPiece => selectionCache.SelectedPiece;

        public Position? SelectedPosition => selectionCache.SelectedPosition;

        public BasePlayer(PlayerSide side, PlayerType type)
        {
            info = new PlayerInfo(side, type);
            switch (type)
            {
                case PlayerType.Manual:
                    controller = new ManualController(side);
                    break;
                case PlayerType.AI:
                    controller = new AIController(side);
                    break;
                default:
                    throw new Exception(
                        "Game config error - incorrect player type declaration during initialization."
                    );
            }
            selectionCache = new SelectionCache(controller);
            state = new PlayerStateSystem(Side, selectionCache, controller);
            PieceFactory.OnPieceAdd += Add;
        }

        private void Add(BasePiece newPiece)
        {
            if (newPiece.Side == Side)
            {
                if (newPiece.Role == PieceRole.King)
                {
                    King = newPiece;
                }
                info.Add(newPiece);
                controller.Register(newPiece);
                newPiece.OnCapture += Remove;
            }
        }

        public void Restore(object? sender, BasePiece restoredPiece) 
        {
            info.Add(restoredPiece);
            controller.Register(restoredPiece);
            restoredPiece.OnRestore -= Restore;
            restoredPiece.OnCapture += Remove;
        }

        private void Remove(object? sender, BasePiece capturedPiece) 
        {
            info.Remove(capturedPiece);
            controller.Unregister(capturedPiece);
            capturedPiece.OnCapture -= Remove;
            capturedPiece.OnRestore += Restore;
        }

        public void Progress()
        {
            state.Update();
            info.Update();
        }

        public void StartTurn()
        {
            if (state.CurrentPlayerState is not AwaitingTurn) throw new Exception("Attempted to start new game during match.");
            state.SetPlayerState(new PlanningTurn(state));
        }

        public bool IsUnderCheck() => King.IsEndangered();
    }
}

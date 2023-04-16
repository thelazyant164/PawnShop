using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.System.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.Model.Player.Controller
{
    public abstract class PlayerController
    {
        public event EventHandler<BasePiece>? OnSelectPiece;
        public event EventHandler<Position>? OnSelectPosition;

        private PlayerSide side;

        public PlayerController(PlayerSide side)
        {
            this.side = side;
            Board.Board board = GameManager.Instance.Board;
            foreach (Position position in board.Positions)
            {
                position.OnSelect += Position_OnSelectPosition;
            }
        }

        public void Register(BasePiece piece)
        {
            piece.OnSelect += BasePiece_OnSelectPiece;
        }

        public void Unregister(BasePiece piece)
        {
            piece.OnSelect -= BasePiece_OnSelectPiece;
        }

        private void BasePiece_OnSelectPiece(object? sender, BasePiece piece) 
        { 
            if (GameManager.Instance.TurnSystem.CurrentTurn == side) 
            {
                OnSelectPiece?.Invoke(sender, piece); 
            }
        }

        private void Position_OnSelectPosition(object? sender, Position position)
        { 
            if (GameManager.Instance.TurnSystem.CurrentTurn == side)
            {
                OnSelectPosition?.Invoke(sender, position);
            }
        }
    }
}

using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Move;
using PawnShop.Script.Model.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.Piece.BasePiece;
using static PawnShop.Script.Model.Piece.BasePiece.PieceRole;
using static PawnShop.Script.Model.Player.BasePlayer.PlayerSide;

namespace PawnShop.Script.Model.Piece.Movement
{
    public sealed class PieceMovementSystem
    {
        public Position Position { get; private set; }

        private PieceMovementController movement;
        private BasePiece piece;
        private BasePlayer opponent;

        public bool Upgradeable => movement.IsUpgradeable(piece, Position);

        public PieceMovementSystem(BasePiece piece)
        {
            piece.OnCapture += OnCapture;
            this.piece = piece;
            opponent = GameManager.Instance.PlayerManager!.GetPlayer(piece.Side == White ? Black : White);
            Position = piece.StartPosition;
            switch (piece.Role)
            {
                case Pawn:
                    movement = new PawnMovement();
                    break;
                case Rook:
                    movement = new RookMovement();
                    break;
                case Knight:
                    movement = new KnightMovement();
                    break;
                case Bishop:
                    movement = new BishopMovement();
                    break;
                case Queen:
                    movement = new QueenMovement();
                    break;
                case King:
                    movement = new KingMovement();
                    break;
                default:
                    throw new Exception($"Invalid piece role: encountered {piece.Role}");
            }
        }

        private void OnCapture(object? sender, BasePiece capturedPiece)
        {
            Position.OccupyingPiece = null;
            piece.OnCapture -= OnCapture;
            piece.OnRestore += OnRestore;
        }

        private void OnRestore(object? sender, BasePiece restoredPiece)
        {
            MoveTo(Position);
            piece.OnRestore -= OnRestore;
            piece.OnCapture += OnCapture;
        }

        public void MoveTo(Position newPosition)
        {
            if (GameManager.Instance.Board.TryLocate(piece, out Position? current))
            {
                current!.OccupyingPiece = null;
            }
            newPosition.OccupyingPiece = piece;
            Position = newPosition;
        }

        public IReadOnlySet<Position> GetAllMoves() => movement.GetAllMoves(piece, Position, opponent);

        public IReadOnlySet<Position> GetReign() => new HashSet<Position>(movement.GetReign(piece, Position));

        public bool IsEndangered() => opponent.Reign.Contains(Position);
    }
}

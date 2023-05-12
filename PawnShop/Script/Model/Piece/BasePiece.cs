using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece.Movement;
using PawnShop.Script.System.Gameplay.GameState;
using PawnShop.Script.System.Gameplay.PieceState;
using static PawnShop.Script.Model.Player.BasePlayer;
using static PawnShop.Script.Model.Piece.BasePiece.PieceRole;

namespace PawnShop.Script.Model.Piece
{
    /// <summary>
    /// Represent individual pieces on the chessboard.
    /// </summary>
    public sealed class BasePiece
    {
        public static readonly IReadOnlyDictionary<PieceRole, int> Costs = new Dictionary<PieceRole, int>()
        {
            { Pawn, 1 },
            { Knight, 2 },
            { Bishop, 2 },
            { Rook, 4 },
            { Queen, 9 }
        };

        private static int hashCount = 0;
        private readonly int hashCode;

        public struct PieceIdentity
        {
            public readonly Position StartPosition;
            public PieceRole Role;
            public PlayerSide Side;

            public PieceIdentity(
                Position startPosition,
                PieceRole role,
                PlayerSide side
            )
            {
                StartPosition = startPosition;
                Role = role;
                Side = side;
            }

            public override string ToString() => $"{Side} {Role} @ {StartPosition}";
        }

        public enum PieceRole
        {
            Pawn,
            Rook,
            Knight,
            Bishop,
            Queen,
            King
        }

        private readonly PieceIdentity identity;
        private readonly PieceStateSystem state;
        private readonly PieceMovementSystem movement;

        public BasePiece(PieceIdentity identity)
        {
            hashCode = hashCount;
            hashCount++;
            this.identity = identity;
            state = new PieceStateSystem(this);
            movement = new PieceMovementSystem(this);
        }

        public PlayerSide Side => identity.Side;

        public PieceRole Role => identity.Role;

        public IReadOnlySet<Position> Reign => movement.GetReign();

        public Position StartPosition => identity.StartPosition;

        public bool Upgradeable => movement.Upgradeable;

        private bool responsive = false;

        public event EventHandler<Position>? OnMove;
        public event EventHandler<BasePiece>? OnSelect;
        public event EventHandler<BasePiece>? OnCapture;
        public event EventHandler<BasePiece>? OnRestore;

        /// <summary>
        /// Method to invoke piece selection programmatically, to be used by AI controllers.
        /// </summary>
        public void InvokeOnSelect(object? sender, EventArgs e) => OnSelect?.Invoke(sender, this);

        /// <summary>
        /// Method to toggle the selectability of a piece.
        /// </summary>
        /// <remarks>When a piece is captured, call this with <paramref name="responsive"></paramref> = <c>false</c> to disable selecting it.</remarks>
        /// <param name="responsive">Whether or not the <c>Piece</c> responses to user events.</param>
        public void ToggleResponseToClick(bool responsive)
        {
            this.responsive = responsive;
        }

        /// <summary>
        /// Callback delegate to respond to user events.
        /// </summary>
        /// <remarks>Will only delegate the task to <c>InvokeOnSelect</c> if the piece is <c>responsive</c>.</remarks>
        public void OnClick()
        {
            if (responsive)
            {
                InvokeOnSelect(this, EventArgs.Empty);
            }
        }

        public override string ToString() => identity.ToString();

        public void Progress() => state.Update();

        public IReadOnlySet<Position> GetAllMoves() => movement.GetAllMoves();

        public void MoveTo(Position position)
        {
            OnMove?.Invoke(this, position);
            movement.MoveTo(position);
        }

        public void Capture()
        {
            OnCapture?.Invoke(this, this);
            state.SetPieceState(new CapturedPiece(state));
        }

        public void Restore()
        {
            OnRestore?.Invoke(this, this);
            state.SetPieceState(new InactivePiece(state));
        }

        public bool IsEndangered() => movement.IsEndangered();

        public IReadOnlySet<Position> GetReign() => movement.GetReign();

        public override int GetHashCode() => hashCode;
    }
}

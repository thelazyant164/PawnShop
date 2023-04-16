using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece.Movement;
using PawnShop.Script.System.Gameplay.GameState;
using PawnShop.Script.System.Gameplay.PieceState;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.Model.Piece
{
    /// <summary>
    /// Represent individual pieces on the chessboard.
    /// </summary>
    public sealed class BasePiece
    {
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

            public override bool Equals(object? obj)
            {
                if (obj is not PieceIdentity) return false;
                return StartPosition.Equals(((PieceIdentity)obj)!.StartPosition)
                    && Role == ((PieceIdentity)obj)!.Role
                    && Side == ((PieceIdentity)obj)!.Side;
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
            this.identity = identity;
            state = new PieceStateSystem(this);
            movement = new PieceMovementSystem(this);
        }

        public PlayerSide Side => identity.Side;

        public PieceRole Role => identity.Role;

        public IReadOnlySet<Position> Reign => movement.GetReign();

        public Position StartPosition => identity.StartPosition;

        private bool responsive = false;

        public event EventHandler<Position> OnMove;
        public event EventHandler<BasePiece> OnSelect;
        public event EventHandler<BasePiece> OnCapture;
        public event EventHandler<BasePiece> OnRestore;

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
        public void OnClick(object? sender, EventArgs e)
        {
            if (responsive)
            {
                InvokeOnSelect(sender, e);
            }
            else
            {
                //Console.WriteLine($"Clicked on {this}, which is inactive");
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is not BasePiece) return false;
            return identity.Equals((obj as BasePiece)!.identity);
        }

        public override string ToString() => Name;

        public string Name => identity.Role != PieceRole.Pawn
            ? $"{identity.Side} {identity.Role}"
            : $"{identity.StartPosition} {identity.Side} {identity.Role}";

        public void Progress()
        {
            state.Update();
        }

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
    }
}

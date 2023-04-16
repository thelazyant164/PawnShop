using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Coin;
using PawnShop.Script.Utility;

namespace PawnShop.Script.Model.Board
{
    /// <summary>
    /// Represent individual positions on the chessboard.
    /// </summary>
    public sealed class Position
    {
        private static int hashCount = 0;
        private readonly int hashCode;

        public enum HighlightType
        {
            None,
            Selected,
            Movable,
            Capturable,
        }

        private bool responsive = false;

        public Coordinate Coordinate { get; private set; }

        public Board.File File => Coordinate.File;

        public Board.Rank Rank => Coordinate.Rank;

        public bool IsOccupied => OccupyingPiece != null;

        public Piece.BasePiece? OccupyingPiece { get; set; } = null;

        public BaseCoin? Coin { get; set; } = null;

        public event EventHandler<Position>? OnSelect;
        public event EventHandler<HighlightType>? OnHighlight;

        public Position(Board.File file, Board.Rank rank)
        {
            hashCode = hashCount;
            hashCount++;
            Coordinate = new Coordinate(file, rank);
        }

        /// <summary>
        /// Method to invoke position selection programmatically, to be used by AI controllers.
        /// </summary>
        public void InvokeOnSelect(object? sender, EventArgs e) => OnSelect?.Invoke(sender, this);

        /// <summary>
        /// Method to toggle the highlighted status of a position.
        /// Used to indicate movable or capturable positions.
        /// </summary>
        /// <param name="type">The type of highlight to set <c>Position</c> to.</param>
        public void InvokeOnHighlight(object? sender, HighlightType type) => OnHighlight?.Invoke(sender, type);

        /// <summary>
        /// Method to toggle the selectability of a position.
        /// </summary>
        /// <remarks>When a piece is selected, call this with <paramref name="responsive"></paramref> = <c>true</c> to make all legal positions interactable.</remarks>
        /// <param name="responsive">Whether or not the <c>Position</c> responses to user events.</param>
        public void ToggleResponseToClick(bool responsive)
        {
            this.responsive = responsive;
        }

        /// <summary>
        /// Callback delegate to respond to user events.
        /// </summary>
        /// <remarks>Will only delegate the task to <c>InvokeOnSelect</c> if the position is <c>responsive</c>.</remarks>
        public void OnClick(object? sender, EventArgs e)
        {
            if (responsive)
            {
                InvokeOnSelect(sender, e);
            }
        }

        public bool IsOccupiedByPlayer(Player.BasePlayer player)
        {
            return IsOccupied && OccupyingPiece?.Side == player.Side;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Position) return false;
            return File == (obj as Position)!.File && Rank == (obj as Position)!.Rank;
        }

        public override int GetHashCode() => hashCode;

        public override string ToString() => $"Position {File}{Rank}";
    }
}

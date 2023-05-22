using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player;

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

        /// <summary>
        /// Returns <value>true</value> if position is currently occupied by a <c>BasePiece</c>.
        /// </summary>
        public bool IsOccupied => OccupyingPiece != null;

        /// <summary>
        /// Returns <value>true</value> if the <c>Position</c> is not occupied by any <c>Coin</c> or <c>BasePiece</c>, <value>false</value> otherwise.
        /// </summary>
        public bool IsEmpty => !IsOccupied && Coin == null;

        /// <summary>
        /// Returns the occupying <c>BasePiece</c>, <value>null</value> if none.
        /// </summary>
        public BasePiece? OccupyingPiece { get; set; } = null;

        /// <summary>
        /// Returns the occupying <c>Coin</c>, <value>null</value> if none.
        /// </summary>
        public Coin.Coin? Coin { get; private set; } = null;

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
        public void OnClick()
        {
            if (responsive)
            {
                InvokeOnSelect(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Method to determine if a <c>Position</c> is occupied by a <c>BasePlayer</c>.
        /// </summary>
        /// <remarks>Returns <value>true</value> if the <c>Position</c> 
        /// is occupied by a specified <c>BasePlayer</c>'s <c>BasePiece</c>.</remarks>
        /// <param name="player">The <c>BasePlayer</c> to verify.</param>
        public bool IsOccupiedByPlayer(BasePlayer player)
        {
            return IsOccupied && OccupyingPiece?.Side == player.Side;
        }

        /// <summary>
        /// Callback delegate to remove a <c>Coin</c> from a <c>Position</c>.
        /// </summary>
        /// <param name="coin">The <c>Coin</c> to remove.</param>
        /// <exception cref="Exception">Will throw an exception if tried to remove non-existent <c>Coin</c> at <c>Position</c>.</exception>
        public void RemoveCoin(object? sender, Coin.Coin coin)
        {
            if (Coin != coin) throw new Exception($"Tried to collect {coin} from {this}, which doesn't have any coin.");
            Coin = null;
        }

        /// <summary>
        /// Callback delegate to add a <c>Coin</c> to a <c>Position</c>.
        /// </summary>
        /// <param name="coin">The <c>Coin</c> to add.</param>
        /// <exception cref="Exception">Will throw an exception if tried to add a <c>Coin</c> to a <c>Position</c> already occupied by another <c>Coin</c>.</exception>
        public void AddCoin(object? sender, Coin.Coin coin)
        {
            if (this != coin.SpawnPosition) throw new Exception($"Tried to add {coin} to {this}, which already has a coin.");
            Coin = coin;
        }

        public override int GetHashCode() => hashCode;

        public override string ToString() => $"Position {File}{Rank}";
    }
}

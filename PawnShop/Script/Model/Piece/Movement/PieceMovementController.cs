using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Player;

namespace PawnShop.Script.Model.Piece.Movement
{
    public abstract class PieceMovementController
    {
        public PieceMovementController() { }

        /// <summary>
        /// Method to get all movable positions for a piece.
        /// </summary>
        /// <remarks>Includes only empty positions and capturable positions. Accounts for King safety.</remarks>
        /// <param name="piece">The piece being examined.</param>
        /// <param name="currentPos">The piece's current position.</param>
        /// <param name="opponent">The opponent player.</param>
        /// <returns>A collection of all movable positions.</returns>
        public virtual IReadOnlySet<Position> GetAllMoves(BasePiece piece, Position currentPos, BasePlayer opponent)
            => GetReign(piece, currentPos)
            .Where(pos => !pos.IsOccupied || pos.IsOccupiedByPlayer(opponent))
            .Where(pos => BoardNavigator.IsMoveValid(piece, pos))
            .ToHashSet();

        /// <summary>
        /// Method to get all positions guarded by a piece.
        /// </summary>
        /// <remarks>Includes positions occupied by friendly units under a piece's protection, empty positions and capturable positions. Does not account for King safety.</remarks>
        /// <param name="piece">The piece being examined.</param>
        /// <param name="currentPos">The current position of the piece.</param>
        /// <returns>A collection of all guarded positions.</returns>
        public abstract List<Position> GetReign(BasePiece piece, Position currentPos);

        /// <summary>
        /// Method to identify if a piece is upgradeable.
        /// </summary>
        /// <remarks>Includes positions occupied by friendly units under a piece's protection, empty positions and capturable positions. Does not account for King safety.</remarks>
        /// <param name="piece">The piece being examined.</param>
        /// <param name="currentPos">The current position of the piece.</param>
        /// <returns>True if the piece is a Pawn and is adjacent to the King, false otherwise.</returns>
        public virtual bool IsUpgradeable(BasePiece piece, Position currentPos) => false;
    }
}

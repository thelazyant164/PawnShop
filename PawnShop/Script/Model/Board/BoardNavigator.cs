using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using static PawnShop.Script.Model.Board.Board;
using static PawnShop.Script.Model.Board.Position;
using static PawnShop.Script.Model.Player.BasePlayer;
using static PawnShop.Script.Model.Board.Coordinate;
using PawnShop.Script.System.Gameplay;
using PawnShop.Script.Model.Piece;

namespace PawnShop.Script.Model.Board
{
    /// <summary>
    /// Static utility class to validate a gamestate.
    /// </summary>
    public static class BoardNavigator
    {
        /// <summary>
        /// Static method to setup reference to <c>Board</c>.
        /// </summary>
        /// <remarks>
        /// Always call this before using any of this class' method.
        /// </remarks>
        public static void Init()
        {
            board = GameManager.Instance.Board;
            turnSystem = GameManager.Instance.TurnSystem!;
        }
        private static Board board;
        private static TurnSystem turnSystem;

        private static IReadOnlyList<(int, int)> knightmoves = new List<(int, int)>
        {
            (1, 2),
            (1, -2),
            (-1, 2),
            (-1, -2),
            (2, 1),
            (-2, 1),
            (2, -1),
            (-2, -1),
        };

        private delegate bool Direction<T, U>(T position, out U coordinate, int step);
        private static List<Position> TryNavigateFrom(Position position, Direction<Coordinate, Coordinate?> direction, int moveLimit)
        {
            List<Position> potentialmoves = new List<Position>();
            for (int move = 1; move <= moveLimit; move++)
            {
                if (!direction(position.Coordinate, out Coordinate? target, move))
                {
                    break;
                }
                if (!board.TryLocate((Coordinate)target!, out Position? potentialmove))
                {
                    break;
                }
                if (potentialmove!.IsOccupied)
                {
                    potentialmoves.Add(potentialmove); // Potential Capture
                    break;
                }
                potentialmoves.Add(potentialmove); // Move Capture
            }
            return potentialmoves;
        }

        public static List<Position> NavigateNorth(Position position, int moveLimit) => TryNavigateFrom(position, TryNorth, moveLimit);
        public static List<Position> NavigateNorthEast(Position position, int moveLimit) => TryNavigateFrom(position, TryNorthEast, moveLimit);
        public static List<Position> NavigateEast(Position position, int moveLimit) => TryNavigateFrom(position, TryEast, moveLimit);
        public static List<Position> NavigateSouthEast(Position position, int moveLimit) => TryNavigateFrom(position, TrySouthEast, moveLimit);
        public static List<Position> NavigateSouth(Position position, int moveLimit) => TryNavigateFrom(position, TrySouth, moveLimit);
        public static List<Position> NavigateSouthWest(Position position, int moveLimit) => TryNavigateFrom(position, TrySouthWest, moveLimit);
        public static List<Position> NavigateWest(Position position, int moveLimit) => TryNavigateFrom(position, TryWest, moveLimit);
        public static List<Position> NavigateNorthWest(Position position, int moveLimit) => TryNavigateFrom(position, TryNorthWest, moveLimit);

        /// <summary>
        /// Static method to generate all possible moves for a <c>Bishop</c>.
        /// </summary>
        /// <returns>A collection of all possible <c>Position</c>s the <c>Bishop</c> can Capture to.</returns>
        /// <param name="position">Current position of the <c>Bishop</c>.</param>
        /// <param name="moveLimit">The maximum Capture limit of the piece.</param>
        public static List<Position> BishopNavigate(Position position, int moveLimit)
        {
            List<Position> potentialmoves = new List<Position>();

            potentialmoves.AddRange(NavigateNorthEast(position, moveLimit));
            potentialmoves.AddRange(NavigateSouthEast(position, moveLimit));
            potentialmoves.AddRange(NavigateSouthWest(position, moveLimit));
            potentialmoves.AddRange(NavigateNorthWest(position, moveLimit));

            return potentialmoves;
        }

        /// <summary>
        /// Static method to generate all possible moves for a Rook.
        /// </summary>
        /// <returns>A collection of all possible <c>Position</c>s the <c>Rook</c> can Capture to.</returns>
        /// <param name="position">Current position of the <c>Rook</c>.</param>
        /// <param name="moveLimit">The maximum Capture limit of the piece.</param>
        public static List<Position> RookNavigate(Position position, int moveLimit)
        {
            List<Position> potentialmoves = new List<Position>();

            potentialmoves.AddRange(NavigateNorth(position, moveLimit));
            potentialmoves.AddRange(NavigateEast(position, moveLimit));
            potentialmoves.AddRange(NavigateSouth(position, moveLimit));
            potentialmoves.AddRange(NavigateWest(position, moveLimit));

            return potentialmoves;
        }

        /// <summary>
        /// Static method to generate all possible moves for a <c>Knight</c>.
        /// </summary>
        /// <returns>A collection of all possible <c>Position</c>s the <c>Knight</c> can Capture to.</returns>
        /// <param name="position">Current position of the <c>Knight</c>.</param>
        public static List<Position> KnightNavigate(Position position)
        {
            List<Position> potentialmoves = new List<Position>();
            foreach ((int, int) offset in knightmoves)
            {
                if (TryNavigateFrom(position, offset, out Position? target))
                {
                    potentialmoves.Add(target!);
                }
            }
            return potentialmoves;
        }

        private static bool TryNavigateFrom(Position root, (int, int) offset, out Position? potentialmove)
        {
            potentialmove = null;
            if (TryCustomDirection(root.Coordinate, out Coordinate? target, offset))
            {
                if (board.TryLocate((Coordinate)target!, out potentialmove))
                {
                    if (!potentialmove!.IsOccupied || potentialmove!.IsOccupiedByPlayer(turnSystem.Opponent))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Static method to validate an unplanned move.
        /// </summary>
        /// <remarks>
        /// Will check if move put King in a check.
        /// </remarks>
        /// <returns>Returns true if move ends up with the King in check, false otherwise.</returns>
        /// <param name="piece">The piece whose move is being validated.</param>
        /// <param name="target">The destination position.</param>
        public static bool IsMoveValid(BasePiece piece, Position target)
        {
            BasePiece? occupyingPiece = target.OccupyingPiece;
            if (board.TryLocate(piece, out Position? currentPosition))
            {
                occupyingPiece?.Capture();
                piece.MoveTo(target);
                if (!turnSystem.GetPlayer(piece.Side).IsUnderCheck())
                {
                    piece.MoveTo(currentPosition!);
                    occupyingPiece?.Restore();
                    return true;
                }
            }
            piece.MoveTo(currentPosition!);
            occupyingPiece?.Restore();
            return false;
        }
    }
}

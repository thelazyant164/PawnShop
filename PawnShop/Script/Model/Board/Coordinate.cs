namespace PawnShop.Script.Model.Board
{
    /// <summary>
    /// Represent a set of coordinates on the chessboard.
    /// </summary>
    public readonly struct Coordinate
    {
        public readonly Board.File File;
        public readonly Board.Rank Rank;

        private static readonly (int, int) North = (0, 1);
        private static readonly (int, int) South = (0, -1);
        private static readonly (int, int) East = (1, 0);
        private static readonly (int, int) West = (-1, 0);
        private static readonly (int, int) NorthEast = (1, 1);
        private static readonly (int, int) SouthEast = (1, -1);
        private static readonly (int, int) NorthWest = (-1, 1);
        private static readonly (int, int) SouthWest = (-1, -1);

        public Coordinate(Board.File file, Board.Rank rank)
        {
            File = file;
            Rank = rank;
        }

        public static Coordinate? operator +(Coordinate root, (int, int) offset)
        {
            int newFile = (int)root.File + offset.Item1;
            int newRank = (int)root.Rank + offset.Item2;

            if (Enum.IsDefined(typeof(Board.File), newFile) && Enum.IsDefined(typeof(Board.Rank), newRank))
            {
                return new Coordinate((Board.File)newFile, (Board.Rank)newRank);
            }
            return null;
        }

        private static bool TryNavigate(Coordinate root, (int, int) direction, out Coordinate? target, int step)
        {
            target = root;
            while (step != 0)
            {
                step--;
                if (target == null) break;
                target = (Coordinate)target! + direction;
            }
            return target != null;
        }

        public static bool TryNorth(Coordinate root, out Coordinate? target, int step = 1)
        {
            return TryNavigate(root, North, out target, step);
        }

        public static bool TrySouth(Coordinate root, out Coordinate? target, int step = 1)
        {
            return TryNavigate(root, South, out target, step);
        }

        public static bool TryEast(Coordinate root, out Coordinate? target, int step = 1)
        {
            return TryNavigate(root, East, out target, step);
        }

        public static bool TryWest(Coordinate root, out Coordinate? target, int step = 1)
        {
            return TryNavigate(root, West, out target, step);
        }

        public static bool TryNorthEast(Coordinate root, out Coordinate? target, int step = 1)
        {
            return TryNavigate(root, NorthEast, out target, step);
        }

        public static bool TrySouthEast(Coordinate root, out Coordinate? target, int step = 1)
        {
            return TryNavigate(root, SouthEast, out target, step);
        }

        public static bool TryNorthWest(Coordinate root, out Coordinate? target, int step = 1)
        {
            return TryNavigate(root, NorthWest, out target, step);
        }

        public static bool TryCustomDirection(Coordinate root, out Coordinate? target, (int, int) direction)
        {
            return TryNavigate(root, direction, out target, 1);
        }

        public static bool TrySouthWest(Coordinate root, out Coordinate? target, int step = 1)
        {
            return TryNavigate(root, SouthWest, out target, step);
        }

        public static int GetDistance(Position root, Position offset)
        {
            int fileOffset = Math.Abs((int)offset.File - (int)root.File);
            int rankOffset = Math.Abs((int)root.Rank - (int)offset.Rank);
            return Math.Max(fileOffset, rankOffset);
        }
    }
}

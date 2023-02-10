using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessUltimate.Script.Model.Board
{
    public class Board
    {
        public enum File
        {
            f1,
            f2,
            f3,
            f4,
            f5,
            f6,
            f7,
            f8
        }

        public enum Rank
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H
        }

        private readonly List<Position> positions;

        public Board() { }
    }
}

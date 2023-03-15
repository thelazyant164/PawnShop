using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.Board
{
    public class Position
    {
        public class OnPositionInitEventArgs : EventArgs
        {
            public Position Position;
        }

        public static event EventHandler<OnPositionInitEventArgs> OnPositionInit;

        public Board.File File { get; private set; }

        public Board.Rank Rank { get; private set; }

        public Piece.BasePiece? OccupyingPiece { get; set; } = null;

        public Position(Board.File file, Board.Rank rank)
        {
            File = file;
            Rank = rank;
            OnPositionInit?.Invoke(this, new OnPositionInitEventArgs { Position = this });
        }

        public bool IsOccupied
        {
            get => OccupyingPiece != null;
        }

        public bool IsOccupiedByPlayer(Player.BasePlayer player)
        {
            return (!IsOccupied) && OccupyingPiece?.Side == player.Side;
        }
    }
}

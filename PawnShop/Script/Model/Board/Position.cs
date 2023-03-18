using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Utility;

namespace PawnShop.Script.Model.Board
{
    public class Position
    {
        public static event StaticEvent<Position>.Handler? OnPositionInit;

        public Board.File File { get; private set; }

        public Board.Rank Rank { get; private set; }

        public Piece.BasePiece? OccupyingPiece { get; set; } = null;

        public Position(Board.File file, Board.Rank rank)
        {
            File = file;
            Rank = rank;
            OnPositionInit?.Invoke(this);
        }

        public bool IsOccupied
        {
            get => OccupyingPiece != null;
        }

        public bool IsOccupiedByPlayer(Player.BasePlayer player)
        {
            return (!IsOccupied) && OccupyingPiece?.Side == player.Side;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Position) return false;
            return File == (obj as Position)!.File && Rank == (obj as Position)!.Rank;
        }

        public override string ToString()
        {
            return $"Position {File}{Rank}";
        }
    }
}

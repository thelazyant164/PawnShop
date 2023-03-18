﻿using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Move;
using PawnShop.Script.Model.Piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawnShop.Script.Model.Move.BaseMove;

namespace PawnShop.Script.Model.Board
{
    public class Board
    {
        public enum File
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

        public enum Rank
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

        private readonly List<Position> positions = new List<Position>();

        public Board()
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                foreach (File file in Enum.GetValues(typeof(File))) 
                {
                    positions.Add(new Position(file, rank));
                }
            }
        }

        public bool TryLocate(File file, Rank rank, out Position? position)
        {
            position = positions.Find(pos => pos.File == file && pos.Rank == rank);
            return position != null;
        }

        public void AddPiece(BasePiece newPiece)
        {
            File file = newPiece.StartPosition.File;
            Rank rank = newPiece.StartPosition.Rank;
            if (TryLocate(file, rank, out Position? position))
            {
                if (position!.IsOccupied)
                {
                    throw new Exception("Error: trying to add piece to occupied position.");
                }
                position.OccupyingPiece = newPiece;
            }
            else
            {
                throw new Exception("Error: trying to add piece to invalid position.");
            }
        }

        public void RemovePiece(BasePiece removedPiece)
        {
            File file = removedPiece.StartPosition.File;
            Rank rank = removedPiece.StartPosition.Rank;
            if (TryLocate(file, rank, out Position? position))
            {
                if (position!.OccupyingPiece != removedPiece)
                {
                    throw new Exception(
                        "Error: trying to remove piece from somewhere piece is not."
                    );
                }
                position.OccupyingPiece = null;
            }
            else
            {
                throw new Exception("Error: trying to remove piece from invalid position.");
            }
        }

        public void Execute(object sender, OnExecuteEventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

        public void Abort(object sender, OnAbortEventArgs eventArgs)
        {
            throw new NotImplementedException();
        }
    }
}

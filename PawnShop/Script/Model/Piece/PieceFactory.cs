using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.Piece
{
    public static class PieceFactory
    {
        public static void Path(string dir, string fileName)
        {
            Dir = dir;
            File = fileName;
        }

        public static string Dir;
        public static string File;

        public static event EventHandler<BasePiece.OnAddPieceEventArgs> OnPieceAdd;

        public static BasePiece.PieceIdentity PieceParser(string data)
        {
            string[] fields = data.Split(",");
            return new BasePiece.PieceIdentity(
                ParsePosition(fields[2], fields[3]),
                ParseRole(fields[1]),
                ParseSide(fields[0])
            );
        }

        public static BasePiece CreatePiece(BasePiece.PieceIdentity pieceID)
        {
            BasePiece newPiece = new BasePiece(pieceID);
            OnPieceAdd?.Invoke(
                GameManager.Instance.Board,
                new BasePiece.OnAddPieceEventArgs { Piece = newPiece }
            );
            return newPiece;
        }

        public static void InitializePieces()
        {
            foreach (
                BasePiece.PieceIdentity pieceID in DataParser<BasePiece.PieceIdentity>.Parse(
                    Dir,
                    File,
                    PieceParser
                )
            )
            {
                CreatePiece(pieceID);
            }
        }

        public static Player.BasePlayer.PlayerSide ParseSide(string side)
        {
            switch (side)
            {
                case "White":
                    return Player.BasePlayer.PlayerSide.White;
                case "Black":
                    return Player.BasePlayer.PlayerSide.Black;
                default:
                    throw new Exception(
                        $"Invalid data when trying to parse CSV - encountered {side}; expected Black or White."
                    );
            }
        }

        public static BasePiece.PieceRole ParseRole(string role)
        {
            switch (role)
            {
                case "Pawn":
                    return BasePiece.PieceRole.Pawn;
                case "Rook":
                    return BasePiece.PieceRole.Rook;
                case "Knight":
                    return BasePiece.PieceRole.Knight;
                case "Bishop":
                    return BasePiece.PieceRole.Bishop;
                case "Queen":
                    return BasePiece.PieceRole.Queen;
                case "King":
                    return BasePiece.PieceRole.King;
                default:
                    throw new Exception(
                        $"Invalid data when trying to parse CSV - encountered {role}; expected Pawn, Rook, Knight, Bishop, Queen or King."
                    );
            }
        }

        public static Position ParsePosition(string file, string rank)
        {
            Board.Board.File _file;
            Board.Board.Rank _rank;

            switch (file)
            {
                case "a":
                    _file = Board.Board.File.A;
                    break;
                case "b":
                    _file = Board.Board.File.B;
                    break;
                case "c":
                    _file = Board.Board.File.C;
                    break;
                case "d":
                    _file = Board.Board.File.D;
                    break;
                case "e":
                    _file = Board.Board.File.E;
                    break;
                case "f":
                    _file = Board.Board.File.F;
                    break;
                case "g":
                    _file = Board.Board.File.G;
                    break;
                case "h":
                    _file = Board.Board.File.H;
                    break;
                default:
                    throw new Exception(
                        $"Invalid data when trying to parse CSV - encountered {file}; expected a, b, c, d, e, f, g or h."
                    );
            }

            switch (rank)
            {
                case "1":
                    _rank = Board.Board.Rank.f1;
                    break;
                case "2":
                    _rank = Board.Board.Rank.f2;
                    break;
                case "3":
                    _rank = Board.Board.Rank.f3;
                    break;
                case "4":
                    _rank = Board.Board.Rank.f4;
                    break;
                case "5":
                    _rank = Board.Board.Rank.f5;
                    break;
                case "6":
                    _rank = Board.Board.Rank.f6;
                    break;
                case "7":
                    _rank = Board.Board.Rank.f7;
                    break;
                case "8":
                    _rank = Board.Board.Rank.f8;
                    break;
                default:
                    throw new Exception(
                        $"Invalid data when trying to parse CSV - encountered {rank}; expected 1, 2, 3, 4, 5, 6, 7 or 8."
                    );
            }

            if (GameManager.Instance.Board.TryLocate(_file, _rank, out Position position))
            {
                return position;
            }
            else
            {
                throw new Exception(
                    $"Invalid data when trying to parse CSV - trying to locate position {_file}:{_rank}"
                );
            }
        }
    }
}

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
using static PawnShop.Script.Model.Player.BasePlayer;
using static PawnShop.Script.Model.Piece.BasePiece;
using static PawnShop.Script.Model.Board.Board;

namespace PawnShop.Script.Model.Piece
{
    /// <summary>
    /// Static factory class to generate all <c>BasePiece</c> from CSV data.
    /// </summary>
    public static class PieceFactory
    {
        /// <summary>
        /// Static method to setup path to local CSV data file.
        /// </summary>
        /// <remarks>
        /// Always call this before calling <c>PieceFactory.InitializePieces()</c>.
        /// </remarks>
        /// <param name="dir">String: directory path to where file is stored.</param>
        /// <param name="fileName">String: filename.</param>
        public static void Path(string dir, string fileName)
        {
            PieceFactory.dir = dir;
            file = fileName;
        }

        private static string? dir;
        private static string? file;

        /// <summary>
        /// Static event fired off everytime a new <c>BasePiece</c> is parsed from a CSV record.
        /// </summary>
        /// <remarks>
        /// Have the <c>Board</c> and all <c>Players</c> subscribe to this before calling <c>PieceFactory.InitializePieces()</c>.
        /// </remarks>
        public static event StaticEvent<BasePiece>.Handler? OnPieceAdd;

        public static void UnregisterAll()
        {
            foreach (Delegate d in OnPieceAdd!.GetInvocationList())
            {
                OnPieceAdd -= (StaticEvent<BasePiece>.Handler)d;
            }
        }

        private static PieceIdentity PieceParser(string data)
        {
            string[] fields = data.Split(",");
            return new PieceIdentity(
                ParsePosition(fields[2], fields[3]),
                ParseRole(fields[1]),
                ParseSide(fields[0])
            );
        }

        /// <summary>
        /// Static method to create a new <c>BasePiece</c> from a <c>PieceIdentity</c>.
        /// </summary>
        /// <remarks>
        /// Fires off the <c>PieceFactory.OnPieceAdd</c> static event.
        /// </remarks>
        /// <returns>
        /// The <c>BasePiece</c> created.
        /// </returns>
        public static BasePiece CreatePiece(PieceIdentity pieceID)
        {
            BasePiece newPiece = new BasePiece(pieceID);
            OnPieceAdd?.Invoke(newPiece);
            return newPiece;
        }

        /// <summary>
        /// Static method to initialize all pieces on the board.
        /// </summary>
        /// <remarks>
        /// Only call this after <c>PieceFactory.Path(dir, filename)</c> has been called, <c>PlayerManager</c> has been initialized, and <c>PieceFactory.OnPieceAdd</c> has been subscribed to by <c>Board</c>.
        /// </remarks>
        /// <returns>
        /// A <c>List</c> of <c>BasePiece</c> created.
        /// </returns>
        public static List<BasePiece> InitializePieces()
        {
            if (dir == null || file == null) 
                throw new Exception("File path to pieces CSV data not set.");
            List<BasePiece> pieces = new List<BasePiece>();
            foreach (
                PieceIdentity pieceID in DataParser<PieceIdentity>.Parse(
                    dir,
                    file,
                    PieceParser
                )
            )
            {
                pieces.Add(CreatePiece(pieceID));
            }
            return pieces;
        }

        private static PlayerSide ParseSide(string side)
        {
            switch (side)
            {
                case "White":
                    return PlayerSide.White;
                case "Black":
                    return PlayerSide.Black;
                default:
                    throw new Exception(
                        $"Invalid data when trying to parse CSV - encountered {side}; expected Black or White."
                    );
            }
        }

        private static PieceRole ParseRole(string role)
        {
            switch (role)
            {
                case "Pawn":
                    return PieceRole.Pawn;
                case "Rook":
                    return PieceRole.Rook;
                case "Knight":
                    return PieceRole.Knight;
                case "Bishop":
                    return PieceRole.Bishop;
                case "Queen":
                    return PieceRole.Queen;
                case "King":
                    return PieceRole.King;
                default:
                    throw new Exception(
                        $"Invalid data when trying to parse CSV - encountered {role}; expected Pawn, Rook, Knight, Bishop, Queen or King."
                    );
            }
        }

        private static Position ParsePosition(string file, string rank)
        {
            Board.Board.File _file;
            Rank _rank;

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
                    _rank = Rank.r1;
                    break;
                case "2":
                    _rank = Rank.r2;
                    break;
                case "3":
                    _rank = Rank.r3;
                    break;
                case "4":
                    _rank = Rank.r4;
                    break;
                case "5":
                    _rank = Rank.r5;
                    break;
                case "6":
                    _rank = Rank.r6;
                    break;
                case "7":
                    _rank = Rank.r7;
                    break;
                case "8":
                    _rank = Rank.r8;
                    break;
                default:
                    throw new Exception(
                        $"Invalid data when trying to parse CSV - encountered {rank}; expected 1, 2, 3, 4, 5, 6, 7 or 8."
                    );
            }

            if (GameManager.Instance.Board.TryLocate(_file, _rank, out Position? position))
            {
                return position!;
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

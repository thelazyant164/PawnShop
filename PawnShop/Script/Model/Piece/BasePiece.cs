using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Board;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.Model.Piece
{
    public class BasePiece
    {
        public struct PieceIdentity
        {
            public readonly Position StartPosition;
            public PieceRole Role;
            public PlayerSide Side;

            public PieceIdentity(
                Position startPosition,
                PieceRole role,
                PlayerSide side
            )
            {
                StartPosition = startPosition;
                Role = role;
                Side = side;
            }

            public override bool Equals(object? obj)
            {
                if (obj is not PieceIdentity) return false;
                return StartPosition.Equals(((PieceIdentity)obj)!.StartPosition)
                    && Role == ((PieceIdentity)obj)!.Role
                    && Side == ((PieceIdentity)obj)!.Side;
            }

            public override string ToString()
            {
                return $"{Side} {Role} @ {StartPosition}";
            }
        }

        public enum PieceRole
        {
            Pawn,
            Rook,
            Knight,
            Bishop,
            Queen,
            King
        }

        private readonly PieceIdentity identity;

        public BasePiece(PieceIdentity identity)
        {
            this.identity = identity;
        }

        public PlayerSide Side
        {
            get => identity.Side;
        }

        public PieceRole Role
        {
            get => identity.Role;
        }

        public Position StartPosition
        {
            get => identity.StartPosition;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not BasePiece) return false;
            return identity.Equals((obj as BasePiece)!.identity);
        }

        public override string ToString()
        {
            return Name;
        }

        public string Name
        {
            get =>
                identity.Role != PieceRole.Pawn
                    ? $"{identity.Side} {identity.Role}"
                    : $"{identity.StartPosition} {identity.Side} {identity.Role}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Board;

namespace PawnShop.Script.Model.Piece
{
    public class BasePiece
    {
        public class OnAddPieceEventArgs : EventArgs
        {
            public BasePiece Piece;
        }

        public class OnRemovePieceEventArgs : EventArgs
        {
            public BasePiece Piece;
        }

        public struct PieceIdentity
        {
            public readonly Position StartPosition;
            public PieceRole Role;
            public Player.BasePlayer.PlayerSide Side;

            public PieceIdentity(
                Position startPosition,
                PieceRole role,
                Player.BasePlayer.PlayerSide side
            )
            {
                StartPosition = startPosition;
                Role = role;
                Side = side;
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

        public Player.BasePlayer.PlayerSide Side
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

        public string Name
        {
            get =>
                identity.Role != PieceRole.Pawn
                    ? $"{identity.Side} {identity.Role}"
                    : $"{identity.StartPosition} {identity.Side} {identity.Role}";
        }
    }
}

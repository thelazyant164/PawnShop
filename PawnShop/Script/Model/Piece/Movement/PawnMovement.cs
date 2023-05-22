using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Player;
using static PawnShop.Script.Model.Player.BasePlayer.PlayerSide;

namespace PawnShop.Script.Model.Piece.Movement
{
    public class PawnMovement : PieceMovementController
    {
        public PawnMovement() { }

        public override IReadOnlySet<Position> GetAllMoves(BasePiece piece, Position currentPos, BasePlayer opponent)
        {
            List<Position> result = GetReign(piece, currentPos);
            result = result.Where(pos => pos.IsOccupiedByPlayer(opponent)).ToList();
            Position? movable = piece.Side == White
                ? BoardNavigator.NavigateNorth(currentPos, 1).FirstOrDefault()
                : BoardNavigator.NavigateSouth(currentPos, 1).FirstOrDefault();
            if (!movable?.IsOccupied ?? false)
            {
                result.Add(movable!);
            }
            return result.Where(pos => BoardNavigator.IsMoveValid(piece, pos)).ToHashSet();
        }

        public override List<Position> GetReign(BasePiece piece, Position currentPos)
        {
            List<Position> result = new List<Position>();
            switch (piece.Side)
            {
                case Black:
                    result.AddRange(BoardNavigator.NavigateSouthWest(currentPos, 1));
                    result.AddRange(BoardNavigator.NavigateSouthEast(currentPos, 1));
                    break;
                case White:
                    result.AddRange(BoardNavigator.NavigateNorthWest(currentPos, 1));
                    result.AddRange(BoardNavigator.NavigateNorthEast(currentPos, 1));
                    break;
            }
            return result;
        }

        public override bool IsUpgradeable(BasePiece piece, Position currentPos)
        {
            BasePiece king = GameManager.Instance.PlayerManager.GetPlayer(piece.Side).King;
            return king.GetReign().Contains(currentPos) && !king.IsEndangered();
        }
    }
}

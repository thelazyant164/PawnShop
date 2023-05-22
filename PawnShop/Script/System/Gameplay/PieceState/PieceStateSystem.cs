using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player.Cache;
using PawnShop.Script.Utility;

namespace PawnShop.Script.System.Gameplay.PieceState
{
    public class PieceStateSystem : StateMachine
    {
        public PlayerManager PlayerManager { get; private set; }
        public BasePiece Piece { get; private set; }
        public SelectionCache Cache { get; private set; }

        public PieceState CurrentPieceState
        {
            get => (PieceState)CurrentState;
        }

        public PieceStateSystem(BasePiece piece)
        {
            Piece = piece;
            PlayerManager = GameManager.Instance.PlayerManager!;
            Cache = PlayerManager.GetPlayer(Piece.Side).Cache;
            SetPieceState(new InactivePiece(this));
        }

        public void SetPieceState(PieceState newPieceState)
        {
            SetState(newPieceState);
        }
    }
}

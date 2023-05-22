namespace PawnShop.Script.System.Gameplay.PieceState
{
    public sealed class InactivePiece : PieceState
    {
        public InactivePiece(PieceStateSystem pieceStateSystem) : base(pieceStateSystem)
        {
        }

        public override void Start()
        {
            piece.ToggleResponseToClick(false);
        }

        public override void Progress()
        {
            if (PieceStateSystem.PlayerManager.CurrentTurn == PieceStateSystem.Piece.Side)
            {
                PieceStateSystem.SetPieceState(new ActivePiece(PieceStateSystem));
            }
        }

        public override void Terminate()
        {
            piece.ToggleResponseToClick(true);
        }
    }
}

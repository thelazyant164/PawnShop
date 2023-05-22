namespace PawnShop.Script.System.Gameplay.PieceState
{
    public sealed class ActivePiece : PieceState
    {
        public ActivePiece(PieceStateSystem pieceStateSystem) : base(pieceStateSystem)
        {
        }

        public override void Progress()
        {
            if (currentTurn != piece.Side)
            {
                PieceStateSystem.SetPieceState(new InactivePiece(PieceStateSystem));
            }
            if (!buyMode && piece.Equals(selectedPiece))
            {
                PieceStateSystem.SetPieceState(new SelectedPiece(PieceStateSystem));
            }
        }
    }
}

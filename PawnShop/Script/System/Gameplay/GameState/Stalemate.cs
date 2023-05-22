using PawnShop.Script.Model.GUI.GameElement;
using PawnShop.Script.Model.GUI.Label;

namespace PawnShop.Script.System.Gameplay.GameState
{
    public sealed class Stalemate : GameOver
    {
        protected override TextLabel matchOutcome =>
            new TextLabel(MatchStatisticLabel.TitlePosition,
                $"{player.Side} {player.Type} stalemate by out of move!");

        public Stalemate(GameStateSystem gameStateSystem) : base(gameStateSystem) { }
    }
}

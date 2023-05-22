using PawnShop.Script.Model.GUI.GameElement;
using PawnShop.Script.Model.GUI.Label;

namespace PawnShop.Script.System.Gameplay.GameState
{
    public sealed class Checkmate : GameOver
    {
        protected override TextLabel matchOutcome =>
            new TextLabel(MatchStatisticLabel.TitlePosition,
                $"{player.Side} {player.Type} lost by checkmate!");

        public Checkmate(GameStateSystem gameStateSystem) : base(gameStateSystem) { }
    }
}

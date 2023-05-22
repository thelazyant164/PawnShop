using PawnShop.Script.Utility;

namespace PawnShop.Script.System.Gameplay.GameState
{
    public abstract class GameState : State
    {
        public GameState(GameStateSystem gameStateSystem) : base(gameStateSystem) { }

        protected GameStateSystem GameStateSystem
        {
            get { return (GameStateSystem)stateMachine; }
        }

        public override void Start() { }

        public override void Progress() { }

        public override void Terminate() { }
    }
}

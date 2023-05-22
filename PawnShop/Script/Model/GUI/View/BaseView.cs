using PawnShop.Script.Model.GUI.Component;
using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Model.Player;
using PawnShop.Script.System.GUI.Input;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;

namespace PawnShop.Script.Model.GUI.View
{
    public abstract class BaseView : InteractableComponent
    {
        protected virtual List<IInteractable> Interactables { get; } = new List<IInteractable>();

        protected virtual List<IVisible> Visibles { get; } = new List<IVisible>();

        private readonly InputSystem input;
        protected BasePlayer player { get; }
        protected InputState Input => input.CurrentInputState;

        public BaseView(BasePlayer player, InputSystem inputController) : base(PrimitiveRect.FullScreen)
        {
            this.player = player;
            input = inputController;
        }

        public override void Show()
        {
            foreach (IInteractable interactable in Interactables)
            {
                interactable.Show();
            }
            foreach (IVisible visible in Visibles)
            {
                visible.Show();
            }
        }

        public override void Hide()
        {
            foreach (IInteractable interactable in Interactables)
            {
                interactable.Hide();
            }
            foreach (IVisible visible in Visibles)
            {
                visible.Hide();
            }
        }

        public override void Draw()
        {
            foreach (IInteractable interactable in Interactables)
            {
                interactable.Draw();
            }
            foreach (IVisible visible in Visibles)
            {
                visible.Draw();
            }
        }

        public override void Activate()
        {
            foreach (IInteractable interactable in Interactables)
            {
                interactable.Activate();
            }
        }

        public override void Deactivate()
        {
            foreach (IInteractable interactable in Interactables)
            {
                interactable.Deactivate();
            }
        }

        public override void Update()
        {
            foreach (IInteractable interactable in Interactables)
            {
                interactable.Update();
            }
        }
    }
}

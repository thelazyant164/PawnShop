using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Model.Player;

namespace PawnShop.Script.System.GUI.Input
{
    public abstract class BaseInputController
    {
        public BasePlayer.PlayerSide Side { get; protected set; }

        protected List<IInteractable> interactables = new List<IInteractable>();

        public BaseInputController(BasePlayer.PlayerSide side)
        {
            Side = side;
        }

        public virtual void Register(IInteractable interactable)
        {
            interactables.Add(interactable);
        }

        public virtual void Unregister(IInteractable interactable)
        {
            interactables.Remove(interactable);
        }

        public virtual void Update()
        {
            foreach (IInteractable interactable in interactables)
            {
                interactable.Update();
            }
        }
    }
}

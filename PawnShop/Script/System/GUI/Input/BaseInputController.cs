using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Model.Player;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.System.GUI.Input
{
    public abstract class BaseInputController
    {
        public BasePlayer.PlayerSide Side { get; protected set; }

        protected List<IInteractable> interactables = new List<IInteractable>();

        public BaseInputController(PlayerSide side)
        {
            Side = side;
        }

        public static BaseInputController Init(BasePlayer player)
        {
            if (player.Type == PlayerType.Manual) 
            {
                return new AIInputController(player.Side);
            }
            else
            {
                return new PlayerInputController(player.Side);
            }
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

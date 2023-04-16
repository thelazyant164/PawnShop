using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Manager.GUI;
using SplashKitSDK;
using PawnShop.Script.System.GUI.Input;
using PawnShop.Script.Model.Player;
using PawnShop.Script.Model.GUI.Component;

namespace PawnShop.Script.Model.GUI.View
{
    public abstract class BaseView : VisibleComponent
    {
        protected virtual List<IInteractable> Interactables { get; } = new List<IInteractable>();

        protected virtual List<IVisible> Visibles { get; } = new List<IVisible>();

        protected BasePlayer Player { get; }

        public BaseView(BasePlayer player) 
        {
            Player = player;
        }

        public virtual void RegisterView(BaseInputController playerInputController) 
        {
            foreach (IInteractable interactable in Interactables) 
            {
                playerInputController.Register(interactable);
            }
        }
    }
}

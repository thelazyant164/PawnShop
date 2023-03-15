using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Model.Player;
using PawnShop.Script.System.Gameplay;

namespace PawnShop.Script.System.GUI.Input
{
    public class InputSystem
    {
        public readonly List<BaseInputController> PlayerInputControllers;

        private readonly TurnSystem turnSystem;

        public InputSystem(GameManager.GameConfig config)
        {
            PlayerInputControllers = new List<BaseInputController>()
            {
                config.Black == BasePlayer.PlayerType.AI
                    ? new AIInputController(BasePlayer.PlayerSide.Black)
                    : new PlayerInputController(BasePlayer.PlayerSide.Black),
                config.White == BasePlayer.PlayerType.AI
                    ? new AIInputController(BasePlayer.PlayerSide.White)
                    : new PlayerInputController(BasePlayer.PlayerSide.White)
            };

            turnSystem = GameManager.Instance.TurnSystem;
        }

        private BaseInputController GetActiveInputController()
        {
            BaseInputController? activeController = PlayerInputControllers.Find(
                inputController => inputController.Side == turnSystem.CurrentTurn
            );
            if (activeController == null) 
            { 
                throw new Exception("Retrieved null in place of active controller"); 
            } 
            else 
            { 
                return activeController;
            }
        }

        public void Update()
        {
            GetActiveInputController().Update();
        }
    }
}

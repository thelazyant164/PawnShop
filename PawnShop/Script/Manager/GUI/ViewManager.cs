using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Utility;
using PawnShop.Script.System.GUI.Input;
using PawnShop.Script.Model.GUI.View;
using static PawnShop.Script.Manager.Gameplay.GameManager;
using static PawnShop.Script.Model.Player.BasePlayer.PlayerType;

namespace PawnShop.Script.Manager.GUI
{
    public sealed class ViewManager : Singleton<ViewManager>
    {
        public static ViewManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ViewManager();
                return _instance;
            }
        }

        private ViewManager() { }

        public InputSystem InputSystem { get; private set; }

        public List<BaseView> ActiveViews { get; private set; } = new List<BaseView>();

        public void Init(GameConfig config)
        {
            InputSystem = new InputSystem(config);
            ActiveViews = new List<BaseView>();
            if (config.Black == Manual)
            {
                ActiveViews.Add(new BoardView());
            }
            if (config.White == Manual)
            {
                ActiveViews.Add(new BoardView());
            }
        }

        public void Update()
        {
            InputSystem.Update();
        }

        public void Draw()
        {
            foreach (BaseView view in ActiveViews)
            {
                view.Draw();
            }
        }
    }
}

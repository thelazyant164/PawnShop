using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Model.GUI.PopUp.Model;
using PawnShop.Script.Model.GUI.PopUp.Content;
using PawnShop.Script.Utility;

namespace PawnShop.Script.Manager.GUI
{
    public sealed class PopUpManager : Singleton<PopUpManager>
    {
        public static PopUpManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PopUpManager();
                return _instance;
            }
        }
        private PopUpManager() { }

        private List<BasePopUp<PopUpContent>> popUps = new List<BasePopUp<PopUpContent>>();

        private void AddPopUp(BasePopUp<PopUpContent> popUp)
        {
            popUps.Add(popUp);
        }

        public void Update()
        {
            foreach (BasePopUp<PopUpContent> popUp in popUps)
            {
                popUp.Update();
            }
        }

        public void Draw()
        {
            foreach (BasePopUp<PopUpContent> popUp in popUps)
            {
                popUp.Draw();
            }
        }
    }
}

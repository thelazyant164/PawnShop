using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.GUI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.GUI.View
{
    public class BoardView : BaseView 
    { 
        List<IVisible> Positions = new List<IVisible>();

        public BoardView() 
        {
            Position.OnPositionInit += OnPositionInit;
        }

        public override void Draw()
        {
            foreach (IInteractable position in Positions) 
            {
                position.Draw();
            }
        }

        private void OnPositionInit(object sender, Position.OnPositionInitEventArgs eventArgs) 
        {
            Positions.Add(BoardViewFactory.InitPosition(eventArgs.Position));
        }
    }
}

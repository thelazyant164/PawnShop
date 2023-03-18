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
        private List<IVisible> positions = new List<IVisible>();

        public BoardView() 
        {
            Position.OnPositionInit += OnPositionInit;
        }

        public override void Draw()
        {
            foreach (IInteractable position in positions) 
            {
                position.Draw();
            }
        }

        private void OnPositionInit(Position newPosition) 
        {
            positions.Add(BoardViewFactory.InitPosition(newPosition));
        }
    }
}

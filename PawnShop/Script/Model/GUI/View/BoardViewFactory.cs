using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.GUI.Button.Model;
using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Model.GUI.Button.UIState;
using static PawnShop.Script.Model.GUI.Interface.IPrimitiveRect;
using PawnShop.Data.View.Board.Position;

namespace PawnShop.Script.Model.GUI.View
{
    public static class BoardViewFactory
    {
        private readonly static int PositionDimension = 120;

        public static IVisible InitPosition(Position position) 
        {
            int x;
            int y;
            switch (position.File)
            {
                case Board.Board.File.A:
                    x = 0;
                    break;
                case Board.Board.File.B:
                    x = PositionDimension;
                    break;
                case Board.Board.File.C:
                    x = PositionDimension * 2;
                    break;
                case Board.Board.File.D:
                    x = PositionDimension * 3;
                    break;
                case Board.Board.File.E:
                    x = PositionDimension * 4;
                    break;
                case Board.Board.File.F:
                    x = PositionDimension * 5;
                    break;
                case Board.Board.File.G:
                    x = PositionDimension * 6;
                    break;
                case Board.Board.File.H:
                    x = PositionDimension * 7;
                    break;
                default:
                    throw new Exception($"Invalid File when initializing position's view on board: encountered {position.File}");
            }
            switch (position.Rank)
            {
                case Board.Board.Rank.f1:
                    y = PositionDimension * 7;
                    break;
                case Board.Board.Rank.f2:
                    y = PositionDimension * 6;
                    break;
                case Board.Board.Rank.f3:
                    y = PositionDimension * 5;
                    break;
                case Board.Board.Rank.f4:
                    y = PositionDimension * 4;
                    break;
                case Board.Board.Rank.f5:
                    y = PositionDimension * 3;
                    break;
                case Board.Board.Rank.f6:
                    y = PositionDimension * 2;
                    break;
                case Board.Board.Rank.f7:
                    y = PositionDimension;
                    break;
                case Board.Board.Rank.f8:
                    y = 0;
                    break;
                default:
                    throw new Exception($"Invalid rank when initializing position's view on board: encountered {position.Rank}");
            }
            return new ImageButton
            (
                new PrimitiveRect(x, y, PositionDimension, PositionDimension),
                PositionUIStatePresets.PositionUIState
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.GUI.Button.UIStateData;
using static PawnShop.Script.Model.GUI.Interface.IImage;
using SplashKitSDK;
using PawnShop.Script.Model.GUI.Button.UIState;

namespace PawnShop.Data.View.Board.Position
{
    public static class PositionUIStatePresets
    {
        private static Color PositionLightColor = Color.White;
        private static Color PositionDarkColor = Color.Black;

        private static ImageButtonUIStateData ActiveUI { get; } = new ImageButtonUIStateData() 
        { 
            Content = new ImageContent(),
        };

        private static ImageButtonUIStateData InactiveUI { get; } = new ImageButtonUIStateData()
        {
            Content = new ImageContent(),
        };

        private static ImageButtonUIStateData PressedUI { get; } = new ImageButtonUIStateData()
        {
            Content = new ImageContent(),
        };

        private static ImageButtonUIStateData SelectedUI { get; } = new ImageButtonUIStateData()
        {
            Content = new ImageContent(),
        };

        public static ImageButtonUIState PositionUIState { get; } = new ImageButtonUIState(
            InactiveUI,
            ActiveUI,
            PressedUI,
            SelectedUI);
    }
}

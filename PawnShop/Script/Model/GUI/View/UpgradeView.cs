using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.GUI.Button.Model;
using PawnShop.Script.Model.GUI.Interface;
using PawnShop.Script.Model.GUI.GameElement;
using static PawnShop.Script.Model.GUI.Interface.IClickable;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.System.GUI.Input;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player;
using static PawnShop.Script.Model.Piece.BasePiece;
using static PawnShop.Script.Model.Piece.BasePiece.PieceRole;

namespace PawnShop.Script.Model.GUI.View
{
    public sealed class UpgradeView : BaseView 
    {
        public UpgradeView(BasePlayer player, InputSystem inputController) : base(player, inputController)
        {
            InitOption(Knight);
            InitOption(Bishop);
            InitOption(Rook);
            InitOption(Queen);
        }

        private void InitOption(PieceRole role)
        {
            UpgradeOption optionButton = new UpgradeOption(role);
            optionButton.OnClick += (object? sender, EventArgs e) => Input.SelectUpgradeRole(role);
            optionButton.OnClick += (object? sender, EventArgs e) => Input.ToggleUpgradeView();
            Interactables.Add(optionButton);
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(UpgradeViewFactory.CanvasGraphic, UpgradeViewFactory.CanvasX, UpgradeViewFactory.CanvasY);
            base.Draw();
        }
    }
}

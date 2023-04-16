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

namespace PawnShop.Script.Model.GUI.View
{
    public class BoardView : BaseView 
    {
        public BoardView(BasePlayer player, Board.Board board) : base(player)
        {
            foreach (Position position in board.Positions) 
            {
                InitInteractablePosition(position);
            }
        }

        private void InitInteractablePosition(Position positionModel)
        {
            InvisibleButton positionButton = BoardViewFactory.InitPositionButton(positionModel);
            positionButton.OnClick += positionModel.OnClick;
            Interactables.Add(positionButton);

            PositionIndicator positionIndicator = BoardViewFactory.InitPositionIndicator(positionModel);
            positionModel.OnHighlight += positionIndicator.OnHighlight;
            Visibles.Add(positionIndicator);

            if (positionModel.IsOccupied)
            {
                if (positionModel.IsOccupiedByPlayer(Player))
                {
                    InitInteractablePiece(positionModel.OccupyingPiece!);
                }
                else
                {
                    InitVisiblePiece(positionModel.OccupyingPiece!);
                }
            }
        }

        private void InitInteractablePiece(BasePiece pieceModel)
        {
            PieceElement pieceButton = BoardViewFactory.InitPiece(pieceModel);
            pieceButton.OnClick += pieceModel.InvokeOnSelect;
            pieceModel.OnMove += pieceButton.OnMove;
            pieceModel.OnCapture += pieceButton.OnCapture;
            pieceModel.OnRestore += pieceButton.OnRestore;
            Interactables.Add(pieceButton);
        }

        private void InitVisiblePiece(BasePiece pieceModel)
        {
            PieceElement pieceButton = BoardViewFactory.InitPiece(pieceModel);
            pieceModel.OnMove += pieceButton.OnMove;
            pieceModel.OnCapture += pieceButton.OnCapture;
            pieceModel.OnRestore += pieceButton.OnRestore;
            Visibles.Add(pieceButton);
        }

        public override void Show()
        {
            base.Show();
            foreach (IInteractable interactable in Interactables) 
            {
                interactable.Show();
            }
            foreach (IVisible visible in Visibles)
            {
                visible.Show();
            }
        }

        public override void Hide()
        {
            base.Hide();
            foreach (IInteractable interactable in Interactables)
            {
                interactable.Hide();
            }
            foreach (IVisible visible in Visibles)
            {
                visible.Hide();
            }
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(BoardViewFactory.BoardGraphic, X, Y);
            foreach (IInteractable interactable in Interactables)
            {
                interactable.Draw();
            }
            foreach (IVisible visible in Visibles) 
            { 
                visible.Draw();
            }
        }
    }
}

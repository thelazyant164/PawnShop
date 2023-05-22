using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Coin;
using PawnShop.Script.Model.GUI.Button.Model;
using PawnShop.Script.Model.GUI.GameElement;
using PawnShop.Script.Model.Piece;
using PawnShop.Script.Model.Player;
using PawnShop.Script.System.GUI.Input;
using SplashKitSDK;

namespace PawnShop.Script.Model.GUI.View
{
    public sealed class BoardView : BaseView
    {
        public BoardView(BasePlayer player, InputSystem inputController, Board.Board board) : base(player, inputController)
        {
            PieceFactory.OnPieceAdd += OnPieceAdd;
            CoinSpawner.OnSpawn += OnSpawnCoin;
            foreach (Position position in board.Positions)
            {
                InitPosition(position);
            }

            BuyButton buyButton = new BuyButton();
            buyButton.OnClick += (object? sender, EventArgs e) => Input.ToggleBuyMode();
            Interactables.Add(buyButton);

            UpgradeButton upgradeButton = new UpgradeButton();
            upgradeButton.OnClick += (object? sender, EventArgs e) => Input.ToggleUpgradeMode();
            upgradeButton.OnClick += (object? sender, EventArgs e) => Input.ToggleUpgradeView();
            Interactables.Add(upgradeButton);

            UndoButton undoButton = new UndoButton();
            undoButton.OnClick += (object? sender, EventArgs e) => Input.Undo();
            Interactables.Add(undoButton);

            RedoButton redoButton = new RedoButton();
            redoButton.OnClick += (object? sender, EventArgs e) => Input.Redo();
            Interactables.Add(redoButton);

            Visibles.Add(new CoinLabel(player));
        }

        private void OnSpawnCoin(Coin.Coin coin)
        {
            CoinSprite coinSprite = new CoinSprite(coin.SpawnPosition);
            coin.OnCollect += coinSprite.OnCollect;
            coin.OnRestore += coinSprite.OnRestore;
            coin.OnExpire += coinSprite.OnCollect;
            coinSprite.Show();
            Visibles.Add(coinSprite);
        }

        private void OnPieceAdd(BasePiece newPiece)
        {
            PieceElement pieceButton = InitPieceElement(newPiece);
            if (newPiece.Side == player.Side)
            {
                pieceButton.OnClick += (object? sender, EventArgs e) => Input.TogglePieceSelect(newPiece);
                Interactables.Add(pieceButton);
            }
            else
            {
                Visibles.Add(pieceButton);
            }
        }

        private void InitPosition(Position positionModel)
        {
            OnPositionAdd(positionModel);
            if (positionModel.IsOccupied)
            {
                OnPieceAdd(positionModel.OccupyingPiece!);
            }
        }

        private void OnPositionAdd(Position newPosition)
        {
            InvisibleButton positionButton = BoardViewFactory.InitPositionButton(newPosition);
            positionButton.OnClick += (object? sender, EventArgs e)
                => Input.TogglePositionSelect(newPosition);
            Interactables.Add(positionButton);

            PositionIndicator positionIndicator = BoardViewFactory.InitPositionIndicator(newPosition);
            newPosition.OnHighlight += (object? sender, Position.HighlightType type)
                => Input.ToggleIndicatorHighlight(positionIndicator, type);
            Visibles.Add(positionIndicator);
        }

        private PieceElement InitPieceElement(BasePiece pieceModel)
        {
            PieceElement pieceButton = BoardViewFactory.InitPiece(pieceModel);
            pieceModel.OnMove += pieceButton.OnMove;
            pieceModel.OnCapture += pieceButton.OnCapture;
            pieceModel.OnRestore += pieceButton.OnRestore;
            return pieceButton;
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(BoardViewFactory.BoardGraphic, X, Y);
            base.Draw();
        }
    }
}

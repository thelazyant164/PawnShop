using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ChessUltimate.Script.Manager;

namespace ChessUltimate
{
    public class GameInstance : Game
    {
        //private GraphicsDeviceManager _graphics;
        //private SpriteBatch _spriteBatch;

        //private Texture2D _whiteKnight;
        //private Vector2 _whiteKnightPos;
        //private float _whiteKnightSpeed;

        private readonly GameManager gameManager = GameManager.Instance;

        public GameInstance()
        {
            //_graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";
            //IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //_whiteKnightPos = new Vector2(
            //    _graphics.PreferredBackBufferWidth / 2,
            //    _graphics.PreferredBackBufferHeight / 2
            //);
            //_whiteKnightSpeed = 100f;
            //base.Initialize();
            gameManager.Init();
        }

        protected override void LoadContent()
        {
            //_spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //_whiteKnight = Content.Load<Texture2D>("white knight");
        }

        protected override void Update(GameTime gameTime)
        {
            gameManager.Update();

            //KeyboardState kstate = Keyboard.GetState();
            //if (
            //    GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            //    || kstate.IsKeyDown(Keys.Escape)
            //)
            //    Exit();

            //// TODO: Add your update logic here
            //if (kstate.IsKeyDown(Keys.Up))
            //{
            //    _whiteKnightPos.Y -=
            //        _whiteKnightSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //}

            //if (kstate.IsKeyDown(Keys.Down))
            //{
            //    _whiteKnightPos.Y +=
            //        _whiteKnightSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //}

            //if (kstate.IsKeyDown(Keys.Left))
            //{
            //    _whiteKnightPos.X -=
            //        _whiteKnightSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //}

            //if (kstate.IsKeyDown(Keys.Right))
            //{
            //    _whiteKnightPos.X +=
            //        _whiteKnightSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //}

            //if (_whiteKnightPos.X > _graphics.PreferredBackBufferWidth - _whiteKnight.Width / 2)
            //{
            //    _whiteKnightPos.X = _graphics.PreferredBackBufferWidth - _whiteKnight.Width / 2;
            //}
            //else if (_whiteKnightPos.X < _whiteKnight.Width / 2)
            //{
            //    _whiteKnightPos.X = _whiteKnight.Width / 2;
            //}

            //if (_whiteKnightPos.Y > _graphics.PreferredBackBufferHeight - _whiteKnight.Height / 2)
            //{
            //    _whiteKnightPos.Y = _graphics.PreferredBackBufferHeight - _whiteKnight.Height / 2;
            //}
            //else if (_whiteKnightPos.Y < _whiteKnight.Height / 2)
            //{
            //    _whiteKnightPos.Y = _whiteKnight.Height / 2;
            //}

            //base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            //// TODO: Add your drawing code here
            //_spriteBatch.Begin();
            //_spriteBatch.Draw(
            //    _whiteKnight,
            //    _whiteKnightPos,
            //    null,
            //    Color.White,
            //    0f,
            //    new Vector2(_whiteKnight.Width / 2, _whiteKnight.Height / 2),
            //    Vector2.One,
            //    SpriteEffects.None,
            //    0f
            //);
            //_spriteBatch.End();

            //base.Draw(gameTime);
        }
    }
}

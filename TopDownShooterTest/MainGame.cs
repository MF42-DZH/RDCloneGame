using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopDownShooterTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        PlayerShip CurrentShip;
        bool ShipInitialised = false;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 480;
            graphics.PreferredBackBufferHeight = 640;
            graphics.ApplyChanges();

            base.IsMouseVisible = true;
            base.Initialize();
        }

        Texture2D PlayerShipTexture;

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            PlayerShipTexture = Content.Load<Texture2D>("Ship");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        Keys UpKey = Keys.Up;
        Keys DownKey = Keys.Down;
        Keys LeftKey = Keys.Left;
        Keys RightKey = Keys.Right;
        Keys ShootKey = Keys.Space;
        Keys FocusKey = Keys.LeftShift;

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState CurrentKB = Keyboard.GetState();

            if (!ShipInitialised)
            {
                CurrentShip = new PlayerShip(PlayerShipTexture, 100, 100, 10, 6, null);
                CurrentShip.ShipCoords = new Vector2(240, 540);
                ShipInitialised = true;
            }

            if (CurrentKB.IsKeyDown(LeftKey) && CurrentKB.IsKeyDown(UpKey) && CurrentKB.IsKeyUp(DownKey) && CurrentKB.IsKeyUp(RightKey))  // UL
            {
                CurrentShip.ModifyShipPosition(0, -(CurrentShip.GiveDiagonalSpeed() / (CurrentKB.IsKeyDown(FocusKey) ? 2 : 1)));
                CurrentShip.ModifyShipPosition(1, -(CurrentShip.GiveDiagonalSpeed() / (CurrentKB.IsKeyDown(FocusKey) ? 2 : 1)));
            }
            else if (CurrentKB.IsKeyUp(LeftKey) && CurrentKB.IsKeyDown(UpKey) && CurrentKB.IsKeyUp(DownKey) && CurrentKB.IsKeyDown(RightKey))  // UR
            {
                CurrentShip.ModifyShipPosition(0, (CurrentShip.GiveDiagonalSpeed() / (CurrentKB.IsKeyDown(FocusKey) ? 2 : 1)));
                CurrentShip.ModifyShipPosition(1, -(CurrentShip.GiveDiagonalSpeed() / (CurrentKB.IsKeyDown(FocusKey) ? 2 : 1)));
            }
            else if (CurrentKB.IsKeyDown(LeftKey) && CurrentKB.IsKeyUp(UpKey) && CurrentKB.IsKeyDown(DownKey) && CurrentKB.IsKeyUp(RightKey))  // DL
            {
                CurrentShip.ModifyShipPosition(0, -(CurrentShip.GiveDiagonalSpeed() / (CurrentKB.IsKeyDown(FocusKey) ? 2 : 1)));
                CurrentShip.ModifyShipPosition(1, (CurrentShip.GiveDiagonalSpeed() / (CurrentKB.IsKeyDown(FocusKey) ? 2 : 1)));
            }
            else if (CurrentKB.IsKeyUp(LeftKey) && CurrentKB.IsKeyUp(UpKey) && CurrentKB.IsKeyDown(DownKey) && CurrentKB.IsKeyDown(RightKey))  // DR
            {
                CurrentShip.ModifyShipPosition(0, (CurrentShip.GiveDiagonalSpeed() / (CurrentKB.IsKeyDown(FocusKey) ? 2 : 1)));
                CurrentShip.ModifyShipPosition(1, (CurrentShip.GiveDiagonalSpeed() / (CurrentKB.IsKeyDown(FocusKey) ? 2 : 1)));
            }
            else if (CurrentKB.IsKeyDown(LeftKey) && CurrentKB.IsKeyUp(RightKey))  // L
            {
                CurrentShip.ModifyShipPosition(0, -(CurrentShip.ShipSpeed / (CurrentKB.IsKeyDown(FocusKey) ? 2 : 1)));
            }
            else if (CurrentKB.IsKeyUp(LeftKey) && CurrentKB.IsKeyDown(RightKey))  // R
            {
                CurrentShip.ModifyShipPosition(0, (CurrentShip.ShipSpeed / (CurrentKB.IsKeyDown(FocusKey) ? 2 : 1)));
            }
            else if (CurrentKB.IsKeyDown(UpKey) && CurrentKB.IsKeyUp(DownKey))  // U
            {
                CurrentShip.ModifyShipPosition(1, -(CurrentShip.ShipSpeed / (CurrentKB.IsKeyDown(FocusKey) ? 2 : 1)));
            }
            else if (CurrentKB.IsKeyUp(UpKey) && CurrentKB.IsKeyDown(DownKey))  // D
            {
                CurrentShip.ModifyShipPosition(1, (CurrentShip.ShipSpeed / (CurrentKB.IsKeyDown(FocusKey) ? 2 : 1)));
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            CurrentShip.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}

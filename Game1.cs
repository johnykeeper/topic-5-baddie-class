using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace topic_5_baddie_class
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Screen screen;
        Rectangle window;

        List<Texture2D> ghostTextures;
        Texture2D backgroundTexture;
        Texture2D titleTexture;
        Texture2D endTexture;
        Texture2D marioTexture;
        List<Ghost> ghosts;

        MouseState mouseState;

        KeyboardState keyboardState;

        Random random;




        enum Screen
        {
            Title,
            House,
            End
        }
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);
            random = new Random();
            ghostTextures = new List<Texture2D>();
            ghosts = new List<Ghost>();
            for(int i = 0; i < 20; i++)
            {
                ghosts.Add(new Ghost(ghostTextures, new Rectangle(random.Next(0, 760), random.Next(0, 560), 40, 40)));
            }
            screen = Screen.Title;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            backgroundTexture = Content.Load<Texture2D>("haunted-background");
            titleTexture = Content.Load<Texture2D>("haunted-title");
            endTexture = Content.Load<Texture2D>("haunted-end-screen");
            marioTexture = Content.Load <Texture2D>("mario");

            ghostTextures.Add(Content.Load<Texture2D>("boo-stopped"));
            for(int i = 1; i <= 8; i++)
            {
                ghostTextures.Add((Content.Load<Texture2D>($"boo-move-{i}")));
            }


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();
            if(screen == Screen.Title)
            {
                if (keyboardState.IsKeyDown(Keys.Enter))
                    screen = Screen.House;
            }
            else if(screen == Screen.House)
            {
                foreach(Ghost g in ghosts)
                {
                    g.Update(gameTime, mouseState);
                    if (g.Intersects(new Rectangle(mouseState.X, mouseState.Y, 40, 40)))
                       screen = Screen.End;
                }
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            if (screen == Screen.Title)
                _spriteBatch.Draw(titleTexture, window, Color.White);
            else if(screen == Screen.House)
            {
                _spriteBatch.Draw(backgroundTexture, window, Color.White);
                foreach (Ghost g in ghosts)
                    g.Draw(_spriteBatch);
                _spriteBatch.Draw(marioTexture, new Rectangle(mouseState.X, mouseState.Y, 40, 40), Color.White);
            }
            else
                _spriteBatch.Draw(endTexture, window, Color.White);

                _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

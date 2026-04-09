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

        MouseState mouseState;

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
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);
            random = new Random();
            ghostTextures = new List<Texture2D>();



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



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here


            _spriteBatch.Draw(backgroundTexture, window, Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

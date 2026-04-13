using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topic_5_baddie_class
{
    public class Ghost
    {
        private List<Texture2D> _textures;
        private Vector2 _speed;
        private Rectangle _location;
        private int _textureindex;
        private SpriteEffects _direction;
        private float _animatedSpeed;
        private float _seconds;

        public Rectangle Rect
        {
            get { return _location; }
        }
        public Ghost(List <Texture2D> textures, Rectangle location)
        {
            _textures = textures;
            _textureindex = 0;
            _speed = Vector2.Zero;
            _location = location;
            _direction = SpriteEffects.None;
            _animatedSpeed = 0.2f;
            _seconds = 0;

        }

        public void Update(GameTime gameTime, MouseState mouseState)
        {
            _speed = Vector2.Zero;

            if(mouseState.X < _location.X)
            {
                _direction = SpriteEffects.FlipHorizontally;
                _speed.X = -1;
            }
            else if (mouseState.X > _location.X)
            {
                _direction = SpriteEffects.None;
                _speed.X = 1;
            }
            if(mouseState.Y < _location.Y)
            {
                _speed.Y = -1;
            }
            if(mouseState.Y > _location.Y)
            {
                _speed.Y = 1;
            }
            if (mouseState.LeftButton == ButtonState.Released)
            {
                _speed = Vector2.Zero;
                _textureindex = 0;
                _seconds = 0f;
            }
            else if(_speed != Vector2.Zero)
            {
                _seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if(_seconds > _animatedSpeed)
                {
                    _seconds = 0;
                    _textureindex++;
                    if(_textureindex >= _textures.Count)
                        _textureindex = 1;
                }
            }
                _location.Offset(_speed);


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textures[_textureindex], _location, null, Color.White, 0f, Vector2.Zero, _direction, 1);

        }
        public bool Contains(Point player)
        {
            return _location.Contains(player);
        }
        public bool Intersects(Rectangle player)
        {
            return _location.Intersects(player);
        }
    }
}

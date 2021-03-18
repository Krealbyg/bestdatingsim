using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using GameMechanics;

namespace AVRGame.NetStandardLibrary
{
    public class Button : DrawableGameComponent
    {
        FieryTale fieryTale;

        //Fields
        private MouseState _currentMouse;
        private SpriteFont _font;
        private bool _isHovering;
        private MouseState _previousMouse;
        private Texture2D _texture;

        //Properties
        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Color PenColour { get; set; }
        public Vector2 ButtonPosition { get; set; }
        public Rectangle ButtonRectangle
        {
            get
            {
                return new Rectangle((int)ButtonPosition.X, (int)ButtonPosition.Y, 1280, 72);
            }
        }
        public string ButtonText { get; set; }

        //Methods
        public Button(Texture2D texture, SpriteFont font, FieryTale fieryTale) : base(fieryTale)
        {
            _texture = texture;
            _font = font;
            PenColour = Color.White;
            this.fieryTale = fieryTale;
        }

        public override void Draw(GameTime gameTime)
        {
            var colour = new Color(0, 0, 0, 100);

            if(_isHovering)
            {
                colour = Color.Black;
            }

            fieryTale.spriteBatch.Draw(_texture, ButtonRectangle, colour);

            if (!string.IsNullOrEmpty(ButtonText))
            {
                var x = (ButtonRectangle.X + (ButtonRectangle.Width / 2)) - (_font.MeasureString(ButtonText).X / 2);
                var y = (ButtonRectangle.Y + (ButtonRectangle.Height / 2)) - (_font.MeasureString(ButtonText).Y / 2);

                fieryTale.spriteBatch.DrawString(_font, ButtonText, new Vector2(x, y), PenColour);
            }
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;

            if (mouseRectangle.Intersects(ButtonRectangle))
            {
                _isHovering = true;

                if(_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}

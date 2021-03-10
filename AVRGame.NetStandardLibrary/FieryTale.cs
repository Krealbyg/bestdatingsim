using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using GameMechanics;
using System;

namespace AVRGame.NetStandardLibrary
{
    //To add: 
    //Levelmanager and levels
    //Buttons
    //Choices
    //Voice over?
    //Anime Waifus (most important)
    
    public class FieryTale : GameMechanics.AVRGame
    {
        Random random = new Random();
        RasterizerState rasterizerState = new RasterizerState() { MultiSampleAntiAlias = true };
        public int windowWidth = 1280, windowHeight = 720;
        
        MouseState oldState;

        //Fonts
        SpriteFont Names;
        SpriteFont Talking;

        //Textures
        Texture2D ren;
        Texture2D goku;
        Texture2D background;
        Texture2D textbox;

        //Sounds
        SoundEffect drip;

        //Variables
        int gameMoment;
        int soundMoment;
     
        public FieryTale() : base()
        {

        }

        /// <summary>
        /// Initilizes the game.
        /// Create all your non-graphic content here
        /// </summary>
        protected override void __Initialize()
        {
            //window size
            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Here you can load all the content you need.
        /// Example: Load textures, sounds or texture effects
        /// </summary>
        protected override void __LoadContent()
        {
            //textures, sounds and fonts
            ren = Content.Load<Texture2D>("Ren");
            goku = Content.Load<Texture2D>("Drip_Goku");
            background = Content.Load<Texture2D>("Hell");
            textbox = Content.Load<Texture2D>("BlackRectangle");
            drip = Content.Load<SoundEffect>("DripSound");
            Names = Content.Load<SpriteFont>("Names");
            Talking = Content.Load<SpriteFont>("Talking");
        }

        /// <summary>
        /// Sometimes you need to unload content.
        /// This is called once if you exit the game
        /// </summary>
        protected override void __UnloadContent()
        {

        }

        /// <summary>
        /// Here you place your update logic.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void __Update(GameTime gameTime)
        {
            //mouse input
            MouseState newState = Mouse.GetState();
            
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                gameMoment = gameMoment + 1;
            }

            oldState = newState;
            
            if (gameMoment == 6 && soundMoment == 0)
            {
                drip.Play(volume: 0.2f, 0.0f, 0.0f);
                soundMoment = soundMoment + 1;
            }

            objectManager.Update(gameTime);
        }

        /// <summary>
        /// Here you place your draw logic.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        protected override void __DrawGame(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //Clears the screen and draws the background color
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(rasterizerState: this.rasterizerState, transformMatrix: Camera.TransformMatrix);
            
            //Draw the objects
            objectManager.Draw(spriteBatch, gameTime);

            spriteBatch.Draw(background, new Rectangle(-400,-300,1280,720) , Color.White);
            spriteBatch.Draw(textbox, new Rectangle(-400, 220, 1280, 200), Color.Black * 0.6f);
            if (gameMoment == 0)
            {
                spriteBatch.DrawString(Names, "You are Ren Amamiya, leader of the Phantom Thieves.", new Vector2(-380, 280), Color.White);
            }
            if (gameMoment == 1)
            {
                spriteBatch.DrawString(Names, "While crossing the streets of Shibuya, you were unceremoniously hit by a truck and died.", new Vector2(-380, 280), Color.White);
            }
            if (gameMoment == 2)
            {
                spriteBatch.Draw(ren, new Rectangle(620, 0, 256, 404), Color.White);
                spriteBatch.DrawString(Names, "Ren:", new Vector2(-380, 240), Color.White);
                spriteBatch.DrawString(Talking, "Where the fuck am I?", new Vector2(-380, 280), Color.White);
            }
            if (gameMoment == 3)
            {
                spriteBatch.Draw(goku, new Rectangle(620, 0, 256, 404), Color.Black);
                spriteBatch.DrawString(Names, "Mysterious voice:", new Vector2(-380, 240), Color.White);
                spriteBatch.DrawString(Talking, "You have died. Welcome to Hell.", new Vector2(-380, 280), Color.White);
            }
            if (gameMoment == 4)
            {
                spriteBatch.Draw(ren, new Rectangle(620, 0, 256, 404), Color.White);
                spriteBatch.DrawString(Names, "Ren:", new Vector2(-380, 240), Color.White);
                spriteBatch.DrawString(Talking, "Who are you? I will reveal your true form!", new Vector2(-380, 280), Color.White);
            }
            if (gameMoment == 5)
            {
                spriteBatch.Draw(goku, new Rectangle(620, 0, 256, 404), Color.Black);
                spriteBatch.DrawString(Names, "Mysterious voice:", new Vector2(-380, 240), Color.White);
                spriteBatch.DrawString(Talking, "There is no need, for I am...", new Vector2(-380, 280), Color.White);
            }
            if (gameMoment == 6)
            {
                spriteBatch.Draw(goku, new Vector2(600, 0), Color.White);
                spriteBatch.DrawString(Names, "Goku:", new Vector2(-380, 240), Color.White);
                spriteBatch.DrawString(Talking, "Goku", new Vector2(-380, 280), Color.White);
            }

            
            spriteBatch.End();
        }

        /// <summary>
        /// This function is for drawing on the UI elements
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        protected override void __DrawUI(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin(rasterizerState: this.rasterizerState);



            spriteBatch.End();
        }
    }
}

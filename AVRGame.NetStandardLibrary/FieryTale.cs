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
    //Levelmanager and levels DONE!!!!!
    //Buttons DONE!!!!!
    //Choices
    //Voice over?
    //Anime Waifus (most important)
    //Actual Story (pretty important)
    
    //Cheeky circumvention of the protection level on SpriteBatch
    public class BetterSpriteBatch : SpriteBatch
    {
        public BetterSpriteBatch(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {

        }
    }

    public class FieryTale : GameMechanics.AVRGame
    {
        Random random = new Random();
        RasterizerState rasterizerState = new RasterizerState() { MultiSampleAntiAlias = true };
        public int windowWidth = 1280, windowHeight = 720;

        public new BetterSpriteBatch spriteBatch;
        
        MouseState oldState;

        //Universal variables
        public int gameMoment;
        public int soundMoment;
        public int choiceMoment;
     
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

            //loading the levels
            Level1 level1 = new Level1(this);
            Components.Add(level1);
        }

        /// <summary>
        /// Here you can load all the content you need.
        /// Example: Load textures, sounds or texture effects
        /// </summary>
        protected override void __LoadContent()
        {
            spriteBatch = new BetterSpriteBatch(GraphicsDevice);
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
            
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released && choiceMoment == 0)
            {
                gameMoment++;
            }

            oldState = newState;

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

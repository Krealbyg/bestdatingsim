using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameMechanics;
using System;

namespace AVRGame.NetStandardLibrary
{
    public class Game : GameMechanics.AVRGame
    {
        Random random = new Random();
        RasterizerState rasterizerState = new RasterizerState() { MultiSampleAntiAlias = true };
        public Game() : base()
        {

        }

        /// <summary>
        /// Initilizes the game.
        /// Create all your non-graphic content here
        /// </summary>
        protected override void __Initialize()
        {

        }

        /// <summary>
        /// Here you can load all the content you need.
        /// Example: Load textures, sounds or texture effects
        /// </summary>
        protected override void __LoadContent()
        {
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

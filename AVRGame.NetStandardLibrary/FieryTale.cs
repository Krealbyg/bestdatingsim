using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using GameMechanics;
using System;
using System.Collections.Generic;

namespace AVRGame.NetStandardLibrary
{
    //This game might show hints of my recent slight obsession with Persona games...

    /* Amount of buttons and which positions to give them:
     * 1: 0 , 329
     * 2: 0, 268 . 0, 380
     * 3: 0, 125 . 0, 250 . 0, 375
     * 4: 0, 100 . 0, 200 . 0, 300 . 0, 400
     */
    
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

        //songs (decided to do music in main file instead of in the level files, thought this'd be better if centralized)
        private Song mementos;
        private Song piano;
        private Song mask;
        private Song hell;

        //Universal variables
        public int gameMoment;//decides the text that shows
        public int soundMoment;//decides which sound should be played
        public bool choiceMoment;//notes if there is a choice on screen or not
        public int currentLevel;//notes which level is currently active, level1 is currentLevel == 0
        public int gokuPoints;//Goku's opinion of Ren, changes based on choices made
        public int goroPoints;//Goro's opinion of Ren, changes based on choices made, high enough points unlock secret romance ending (because I demanded we make a Ren x Goro ending)
        public bool attackedSomeone;//notes if Ren has attacked someone with Arsène
        public bool songPlaying;//notes if there is currently a song playing
     
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
            Startscreen startscreen = new Startscreen(this);
            Components.Add(startscreen);
            Testlevel testLevel = new Testlevel(this);
            Components.Add(testLevel);
            GameOver gameOver = new GameOver(this);
            Components.Add(gameOver);
            Day0 day0 = new Day0(this);
            Components.Add(day0);
            Day1 day1 = new Day1(this);
            Components.Add(day1);
            Day2 day2 = new Day2(this);
            Components.Add(day2);
        }

        /// <summary>
        /// Here you can load all the content you need.
        /// Example: Load textures, sounds or texture effects
        /// </summary>
        protected override void __LoadContent()
        {
            spriteBatch = new BetterSpriteBatch(GraphicsDevice);

            //music (which has been shamelessly ripped from the Persona 5 Royal OST)
            mementos = Content.Load<Song>("MementosSong");
            piano = Content.Load<Song>("VelvetRoomMusic");
            mask = Content.Load<Song>("BeneathTheMask");
            hell = Content.Load<Song>("HellSong");
            MediaPlayer.IsRepeating = true;//makes music repeat
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
            #region music
            if (currentLevel == 0 && songPlaying == false)//main menu song
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(mementos);
                MediaPlayer.Volume = 0.1f;
                songPlaying = true;
            }

            if (currentLevel == 1 && gameMoment <= 21 && songPlaying == false)//main Hell song
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(hell);
                MediaPlayer.Volume = 0.05f;
                songPlaying = true;
            }

            if (currentLevel == 1 && gameMoment > 21 && songPlaying == true)//Ren's dormroom song
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(mask);
                MediaPlayer.Volume = 0.1f;
                songPlaying = false;
            }

            if (currentLevel == 2 && gameMoment <= 4 && songPlaying == false)//Ren's dormroom song again
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(mask);
                MediaPlayer.Volume = 0.1f;
                songPlaying = true;
            }

            if (currentLevel == 3 && gameMoment <= 5 && songPlaying == false && attackedSomeone == false || currentLevel == 3 && gameMoment > 57 && songPlaying == false && attackedSomeone == false)//Ren's dormroom song again
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(mask);
                MediaPlayer.Volume = 0.1f;
                songPlaying = true;
            }

            if (currentLevel == 3 && gameMoment > 5 && gameMoment <= 57 && songPlaying == true)//Outside song
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(hell);
                MediaPlayer.Volume = 0.05f;
                songPlaying = false;
            }

            if (attackedSomeone == true && songPlaying == false)//gameover song
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(piano);
                MediaPlayer.Volume = 0.4f;
                songPlaying = true;
            }

            if (MediaPlayer.State == MediaState.Stopped)//sets songPlaying to false when no song is playing
            {
                songPlaying = false;
            }
            #endregion

            //mouse input
            MouseState newState = Mouse.GetState();
            
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released && choiceMoment == false && newState.Y >= 520)//only once per click (no holding) and while no choices on screen and while hovering over the text bar.
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

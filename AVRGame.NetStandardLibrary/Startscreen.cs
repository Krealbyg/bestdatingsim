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
    //quick startscreen to either go to the test level or to start the real game
    public class Startscreen : DrawableGameComponent
    {
        private FieryTale fieryTale;

        //lists
        private List<Button> buttons;

        //background
        private Texture2D background;

        public Startscreen(FieryTale fieryTale) : base(fieryTale)//constructor, inherit some stuff from main file (like spritebatch)
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //textures
            background = fieryTale.Content.Load<Texture2D>("MainMenu");

            //loads buttons
            var startButton = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 268),//360(center of screen) - 20 - 72(button height)
                ButtonText = "Start Game",
            };

            var testButton = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 380),//360(center of screen) + 20
                ButtonText = "Test level",
            };

            //creates button click events
            startButton.Click += StartButton_Click;
            testButton.Click += TestButton_Click;

            //puts buttons in list
            buttons = new List<Button>()
            {
                startButton,
                testButton
            };
            base.LoadContent();
        }

        private void TestButton_Click(object sender, EventArgs e)//test level button event
        {
            if (fieryTale.currentLevel == 0)//only when in no level
            {
                fieryTale.currentLevel = 100;//number we will never get to normally
                fieryTale.choiceMoment = false;//gives back control
                MediaPlayer.Stop();//stops menu song
            }
        }

        private void StartButton_Click(object sender, EventArgs e)//start game button event
        {
            if (fieryTale.currentLevel == 0)//only when in no level
            {
                fieryTale.currentLevel = 1;//starts first level
                fieryTale.choiceMoment = false;//gives back control
                MediaPlayer.Stop();//stops menu song
            }
        }

        public override void Update(GameTime gameTime)
        {   
            foreach (var button in buttons)//updates all the buttons
                button.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            fieryTale.spriteBatch.Begin();

            if (fieryTale.currentLevel == 0)
            {
                fieryTale.spriteBatch.Draw(background, new Rectangle(0, 0, 1280, 720), Color.White);
                foreach (var button in buttons)//draws buttons
                    button.Draw(gameTime);
                fieryTale.choiceMoment = true;//takes away control
            }

            fieryTale.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

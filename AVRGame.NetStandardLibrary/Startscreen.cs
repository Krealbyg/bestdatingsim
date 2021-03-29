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
    //maybe add nice Title to it at some point
    public class Startscreen : DrawableGameComponent
    {
        private FieryTale fieryTale;

        private bool levelselect;
        private bool time;

        //lists
        private List<Button> buttons;
        private List<Button> levels;

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

            #region buttons
            //loads buttons
            var startButton = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 268),//360(center of screen) - 20 - 72(button height)
                ButtonText = "Start Game",
            };

            var selectButton = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 380),//360(center of screen) + 20
                ButtonText = "Level select",
            };

            //levels
            var day1Button = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 20),
                ButtonText = "Day 1",
            };
            var day2Button = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 122),
                ButtonText = "Day 2",
            };
            var day5Button = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 224),
                ButtonText = "Day 5",
            };
            var day6Button = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 326),
                ButtonText = "Day 6",
            };
            var day10Button = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 428),
                ButtonText = "Day 10",
            };
            var endingButton = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 530),
                ButtonText = "Ending",
            };
            var testButton = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 632),
                ButtonText = "Test level",
            };

            //creates button click events
            startButton.Click += StartButton_Click;
            testButton.Click += TestButton_Click;
            selectButton.Click += SelectButton_Click;
            day1Button.Click += Day1Button_Click;
            day2Button.Click += Day2Button_Click;
            day5Button.Click += Day5Button_Click;
            day6Button.Click += Day6Button_Click;
            day10Button.Click += Day10Button_Click;
            endingButton.Click += EndingButton_Click;

            //puts buttons in list
            buttons = new List<Button>()
            {
                startButton,
                selectButton
            };

            levels = new List<Button>
            {
                day1Button,
                day2Button,
                day5Button,
                day6Button,
                day10Button,
                endingButton,
                testButton,
            };
            #endregion

            base.LoadContent();
        }

        #region click events
        private void EndingButton_Click(object sender, EventArgs e)
        {
            if (fieryTale.currentLevel == 0 && levelselect == true)//day choice button, only on select
            {
                fieryTale.currentLevel = 9;
                fieryTale.choiceMoment = false;//gives back control
                MediaPlayer.Stop();//stops menu song
            }
        }

        private void Day10Button_Click(object sender, EventArgs e)
        {
            if (fieryTale.currentLevel == 0 && levelselect == true)//day choice button, only on select
            {
                fieryTale.currentLevel = 7;
                fieryTale.choiceMoment = false;//gives back control
                MediaPlayer.Stop();//stops menu song
            }
        }

        private void Day6Button_Click(object sender, EventArgs e)
        {
            if (fieryTale.currentLevel == 0 && levelselect == true)//day choice button, only on select
            {
                fieryTale.currentLevel = 6;
                fieryTale.choiceMoment = false;//gives back control
                MediaPlayer.Stop();//stops menu song
            }
        }

        private void Day5Button_Click(object sender, EventArgs e)
        {
            if (fieryTale.currentLevel == 0 && levelselect == true)//day choice button, only on select
            {
                fieryTale.currentLevel = 4;
                fieryTale.choiceMoment = false;//gives back control
                MediaPlayer.Stop();//stops menu song
            }
        }

        private void Day2Button_Click(object sender, EventArgs e)
        {
            if (fieryTale.currentLevel == 0 && levelselect == true)//day choice button, only on select
            {
                fieryTale.currentLevel = 3;
                fieryTale.choiceMoment = false;//gives back control
                MediaPlayer.Stop();//stops menu song
            }
        }

        private void Day1Button_Click(object sender, EventArgs e)
        {
            if (fieryTale.currentLevel == 0 && levelselect == true)//day choice button, only on select
            {
                fieryTale.currentLevel = 2;
                fieryTale.choiceMoment = false;//gives back control
                MediaPlayer.Stop();//stops menu song
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (fieryTale.currentLevel == 0 && levelselect == false)//only when in no level and not on select
            {
                levelselect = true;
            }
        }

        private void TestButton_Click(object sender, EventArgs e)//test level button event only on select
        {
            if (fieryTale.currentLevel == 0 && levelselect == true)//only when in no level
            {
                fieryTale.currentLevel = 100;//number we will never get to normally
                fieryTale.choiceMoment = false;//gives back control
                MediaPlayer.Stop();//stops menu song
            }
        }

        private void StartButton_Click(object sender, EventArgs e)//start game button event
        {
            if (fieryTale.currentLevel == 0 && levelselect == false)//only when in no level and not on select
            {
                fieryTale.currentLevel = 1;//starts first level
                fieryTale.choiceMoment = false;//gives back control
                MediaPlayer.Stop();//stops menu song
            }
        }
        #endregion

        public override void Update(GameTime gameTime)
        {
            //little timer for level select screen
            float timer = (float)gameTime.TotalGameTime.Seconds;
            if (levelselect == true && time == false)
            {
                timer = 0;
                time = true;
            }

            foreach (var button in buttons)//updates all the buttons
                button.Update(gameTime);

            if (timer > 1)//makes it so cant accidentally instantly click a level after clicking level select button.
            {
                foreach (var button in levels)//updates all the buttons
                    button.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            fieryTale.spriteBatch.Begin();

            if (fieryTale.currentLevel == 0)
            {
                fieryTale.choiceMoment = true;//takes away control
                fieryTale.spriteBatch.Draw(background, new Rectangle(0, 0, 1280, 720), Color.White);
                if (levelselect == false)
                {
                    foreach (var button in buttons)//draws buttons
                        button.Draw(gameTime);
                }
                if (levelselect == true)
                {
                    foreach (var button in levels)//Draws
                        button.Draw(gameTime);
                }
            }

            fieryTale.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

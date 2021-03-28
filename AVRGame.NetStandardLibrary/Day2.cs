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
    public class Day2 : DrawableGameComponent
    {
        FieryTale fieryTale;

        private int obamaoption;//for the choice with janitor obama care
        private int sinsoption;

        //Lists for choices
        private List<Button> obamachoice;
        private List<Button> sinschoice;

        //Fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //Textures
        private Texture2D rennormal;
        private Texture2D goku;
        private Texture2D textbox;
        private Texture2D dorm;
        private Texture2D shiki;
        private Texture2D sabel;
        private Texture2D yasutora;
        private Texture2D kase;
        private Texture2D classroom;
        private Texture2D sins;
        private Texture2D mrcare;

        //Goro expressions
        private Texture2D goroneutral;
        private Texture2D gorosmiling;
        private Texture2D gorosad;
        private Texture2D goroshocked;

        //sounds
        private SoundEffect persona;
        private SoundEffect punishment;

        public Day2(FieryTale fieryTale) : base(fieryTale)
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //same as always
            rennormal = fieryTale.Content.Load<Texture2D>("RenNormal");
            goku = fieryTale.Content.Load<Texture2D>("Drip_Goku");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            dorm = fieryTale.Content.Load<Texture2D>("Dorm");
            shiki = fieryTale.Content.Load<Texture2D>("Shiki");
            sabel = fieryTale.Content.Load<Texture2D>("Sabel");
            yasutora = fieryTale.Content.Load<Texture2D>("Yasutora");
            kase = fieryTale.Content.Load<Texture2D>("Kase");
            sins = fieryTale.Content.Load<Texture2D>("Sinsleft");
            goroneutral = fieryTale.Content.Load<Texture2D>("GoroNeutral");
            gorosmiling = fieryTale.Content.Load<Texture2D>("GoroSmiling");
            gorosad = fieryTale.Content.Load<Texture2D>("GoroSad");
            goroshocked = fieryTale.Content.Load<Texture2D>("GoroShocked");
            classroom = fieryTale.Content.Load<Texture2D>("Classroom");
            mrcare = fieryTale.Content.Load<Texture2D>("MrCare");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");
            persona = fieryTale.Content.Load<SoundEffect>("MagatsuIzanagi");
            punishment = fieryTale.Content.Load<SoundEffect>("ProperPunishment");

            #region buttons

            //obamachoice
            var obamachoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 100),
                ButtonText = "Sorry"
            };
            var obamachoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 200),
                ButtonText = "Move old man"
            };
            var obamachoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 300),
                ButtonText = "..."
            };
            var obamachoice4 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 400),
                ButtonText = "Persona!"
            };

            //mrsinschoice
            var sinschoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 100),
                ButtonText = "Nah"
            };
            var sinschoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 200),
                ButtonText = "Tell me about yourself"
            };
            var sinschoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 300),
                ButtonText = "..."
            };
            var sinschoice4 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 400),
                ButtonText = "Wait, I know you..."
            };
            #endregion

            #region button choice event creation

            obamachoice1.Click += Obamachoice1_Click;
            obamachoice2.Click += Obamachoice2_Click;
            obamachoice3.Click += Obamachoice3_Click;
            obamachoice4.Click += Obamachoice4_Click;

            sinschoice1.Click += Sinschoice1_Click;
            sinschoice2.Click += Sinschoice2_Click;
            sinschoice3.Click += Sinschoice3_Click;
            sinschoice4.Click += Sinschoice4_Click;

            #endregion

            #region filling lists

            obamachoice = new List<Button>
            {
                obamachoice1,
                obamachoice2,
                obamachoice3,
                obamachoice4
            };

            sinschoice = new List<Button>
            {
                sinschoice1,
                sinschoice2,
                sinschoice3,
                sinschoice4
            };

            #endregion

            base.LoadContent();
        }

        private void Sinschoice4_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 16)
            {
                sinsoption = 4;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Sinschoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 16)
            {
                sinsoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Sinschoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 16)
            {
                sinsoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Sinschoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 16)
            {
                obamaoption = 4;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Obamachoice4_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 7)
            {
                obamaoption = 4;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Obamachoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 7)
            {
                obamaoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Obamachoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 7)
            {
                obamaoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Obamachoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 7)
            {
                obamaoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 3 && fieryTale.attackedSomeone == false)
            {
                if (fieryTale.gameMoment == 10 && obamaoption == 4 && fieryTale.soundMoment == 0)
                {
                    punishment.Play();//plays sound
                    fieryTale.soundMoment++;//stops looping
                }
                
                //update buttons
                foreach (var button in obamachoice)
                    button.Update(gameTime);
                foreach (var button in sinschoice)
                    button.Update(gameTime);

                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 3 && fieryTale.attackedSomeone == false)
            {
                fieryTale.spriteBatch.Begin();

                //backgrounds
                
                //Textbox
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);//720 - 200 = 520, 1280 is screen width, 200 randomly decided

                if (fieryTale.gameMoment == 0)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I'm woken up by my alarm.", new Vector2(10, 580), Color.White);//positions of text arbitrarily decided until it looked good
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 1)
                {
                    fieryTale.spriteBatch.DrawString(Names, "It's my second schoolday in Hell.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 2)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "God, shut the fuck up already [I smash my alarm]", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 3)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Finally, some peace...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 4)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "FUCK! I'm gonna be late!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 5)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I quickly rush out the door and to class.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 6)
                {
                    fieryTale.spriteBatch.DrawString(Names, "In my haste I don't notice the janitor standing in my way and run into him.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 7)
                {
                    foreach (var button in obamachoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 8)
                {
                    if (obamaoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Sorry janitor-san, my bad. I am in a bit of a hurry.", new Vector2(10, 580), Color.White);
                    }
                    else if (obamaoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Move it old man, I don't have time for this nonsense!", new Vector2(10, 580), Color.White);
                    }
                    else if (obamaoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                    }
                    else if (obamaoption == 4)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I tear off my mask (glasses) and summon forth Magatsu Izanagi from the sea of my soul.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 9)
                {
                    if (obamaoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(mrcare, new Rectangle(1000, 470, 350, 250), Color.White);//822 X 600
                        fieryTale.spriteBatch.DrawString(Names, "Janitor:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Ah no worries kiddo, all is forgiven.", new Vector2(10, 580), Color.White);
                    }
                    else if (obamaoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(mrcare, new Rectangle(1000, 470, 350, 250), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Janitor:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "That is no way to speak to an elder, young man. You better learn to show some respect.", new Vector2(10, 580), Color.White);
                    }
                    else if (obamaoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(mrcare, new Rectangle(1000, 470, 350, 250), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Janitor:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Have a nice day kiddo, make the most of it.", new Vector2(10, 580), Color.White);
                    }
                    else if (obamaoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(mrcare, new Rectangle(1000, 470, 350, 250), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Janitor:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "KIDDO WHAT THE FUCK IS THAT!?!?", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 10)
                {
                    if (obamaoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Thank you for understanding. Say, can I ask you something?", new Vector2(10, 580), Color.White);
                    }
                    else if (obamaoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I will give my respect to who I see fit. Now move.", new Vector2(10, 580), Color.White);
                    }
                    else if (obamaoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                    }
                    else if (obamaoption == 4)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "You need proper punishment.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 11)
                {
                    if (obamaoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(mrcare, new Rectangle(1000, 470, 350, 250), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Janitor:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Sure kid, waddayawannaknow?", new Vector2(10, 580), Color.White);
                    }
                    else if (obamaoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I try to shove him aside but I'm unable to... I walk around him in shame.", new Vector2(10, 580), Color.White);
                    }
                    else if (obamaoption == 3)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I quickly run to class.", new Vector2(10, 580), Color.White);
                    }
                    else if (obamaoption == 4)
                    {
                        fieryTale.attackedSomeone = true;
                    }
                }
                if (fieryTale.gameMoment == 12)
                {
                    if (obamaoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I forgot the way to my classroom, could you point me to 2-6?", new Vector2(10, 580), Color.White);
                    }
                    else if (obamaoption == 2)
                    {
                        fieryTale.gameMoment = 14;
                    }
                    else if (obamaoption == 3)
                    {
                        fieryTale.gameMoment = 14;
                    }
                }
                if (fieryTale.gameMoment == 13)
                {
                    if (obamaoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "The janitor gives me directions and I run off to class.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 14)
                {
                    if (obamaoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I am faster than expected and arrive at class slightly early.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 15)
                {
                    if (obamaoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Mr. Sins isn't busy, perhaps I could talk to him.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 16)
                {
                    foreach (var button in sinschoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                fieryTale.spriteBatch.End();
            }
        }
    }
}

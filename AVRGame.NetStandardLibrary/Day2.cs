﻿using System;
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
        private int sinsoption;//for when talking to sins
        private int bitchoption;//for when talking to bitch teacher
        private int jockoption;//for when talking to jock

        //Lists for choices
        private List<Button> obamachoice;
        private List<Button> sinschoice;
        private List<Button> talkchoice;
        private List<Button> bitchchoice;
        private List<Button> jockchoice;

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
        private Texture2D hell;
        private Texture2D classroom;
        private Texture2D sins;
        private Texture2D mrcare;
        private Texture2D bitch;

        //Goro expressions
        private Texture2D goroneutral;
        private Texture2D gorosmiling;
        private Texture2D gorosad;
        private Texture2D goroshocked;

        //sounds
        private SoundEffect persona;
        private SoundEffect asterius;
        private SoundEffect punishment;
        private SoundEffect die;

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
            bitch = fieryTale.Content.Load<Texture2D>("BITCH");
            hell = fieryTale.Content.Load<Texture2D>("Hell");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");
            persona = fieryTale.Content.Load<SoundEffect>("MagatsuIzanagi");
            punishment = fieryTale.Content.Load<SoundEffect>("ProperPunishment");
            asterius = fieryTale.Content.Load<SoundEffect>("Asterius");
            die = fieryTale.Content.Load<SoundEffect>("Die");

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

            //betweenlessontalk aka illusion of choice
            var talkchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 100),
                ButtonText = "Sabel"
            };
            var talkchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 200),
                ButtonText = "Kase"
            };
            var talkchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 300),
                ButtonText = "Yasutora"
            };
            var talkchoice4 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 400),
                ButtonText = "Shiki"
            };

            //talking to the bitch
            var bitchchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 100),
                ButtonText = "Persona!"
            };
            var bitchchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 200),
                ButtonText = "..."
            };
            var bitchchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 300),
                ButtonText = "Obey"
            };
            var bitchchoice4 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 400),
                ButtonText = "Don't speak to me like that"
            };

            //jock convo
            var jockchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 125),
                ButtonText = "Persona!"
            };
            var jockchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 250),
                ButtonText = "No"
            };
            var jockchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 375),
                ButtonText = "You can copy from me"
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

            talkchoice1.Click += Talkchoice1_Click;
            talkchoice2.Click += Talkchoice2_Click;
            talkchoice3.Click += Talkchoice3_Click;
            talkchoice4.Click += Talkchoice4_Click;

            bitchchoice1.Click += Bitchchoice1_Click;
            bitchchoice2.Click += Bitchchoice2_Click;
            bitchchoice3.Click += Bitchchoice3_Click;
            bitchchoice4.Click += Bitchchoice4_Click;

            jockchoice1.Click += Jockchoice1_Click;
            jockchoice2.Click += Jockchoice2_Click;
            jockchoice3.Click += Jockchoice3_Click;
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

            talkchoice = new List<Button>
            {
                talkchoice1,
                talkchoice2,
                talkchoice3,
                talkchoice4
            };

            bitchchoice = new List<Button>
            {
                bitchchoice1,
                bitchchoice2,
                bitchchoice3,
                bitchchoice4
            };

            jockchoice = new List<Button>
            {
                jockchoice1,
                jockchoice2,
                jockchoice3
            };
            #endregion

            base.LoadContent();
        }

        

        #region button click events
        //jock
        private void Jockchoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 48)
            {
                jockoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Jockchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 48)
            {
                jockoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Jockchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 48)
            {
                jockoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }
        
        //bitch
        private void Bitchchoice4_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 32)
            {
                bitchoption = 4;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Bitchchoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 32)
            {
                bitchoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Bitchchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 32)
            {
                bitchoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Bitchchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 32)
            {
                bitchoption = 1;
                asterius.Play(volume: 0.8f, 0.0f, 0.0f);
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        //illusion
        private void Talkchoice4_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 29)
            {
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Talkchoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 29)
            {
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Talkchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 29)
            {
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Talkchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 29)
            {
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        //sins
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
                sinsoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        //obama care
        private void Obamachoice4_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 7)
            {
                persona.Play();
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
        #endregion

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 3 && fieryTale.attackedSomeone == false)
            {
                if (fieryTale.gameMoment == 10 && obamaoption == 4 && fieryTale.soundMoment == 0)
                {
                    punishment.Play(volume: 0.75f, 0.0f, 0.0f);//plays sound
                    fieryTale.soundMoment++;//stops looping
                }
                if (fieryTale.gameMoment == 35 && bitchoption == 1 && fieryTale.soundMoment <= 1)
                {
                    die.Play();
                    fieryTale.soundMoment = 2;
                }
                
                //update buttons
                foreach (var button in obamachoice)
                    button.Update(gameTime);
                foreach (var button in sinschoice)
                    button.Update(gameTime);
                foreach (var button in talkchoice)
                    button.Update(gameTime);
                foreach (var button in bitchchoice)
                    button.Update(gameTime);
                foreach (var button in jockchoice)
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
                if (fieryTale.gameMoment <= 5)
                {
                    fieryTale.spriteBatch.Draw(dorm, new Rectangle(0, 0, 1280, 760), Color.White);
                }
                else if (fieryTale.gameMoment > 5 && fieryTale.gameMoment <= 13)
                {
                    fieryTale.spriteBatch.Draw(hell, new Rectangle(0, 0, 1280, 720), Color.White);
                }
                else if (fieryTale.gameMoment > 13)
                {
                    fieryTale.spriteBatch.Draw(classroom, new Rectangle(0, 0, 1280, 760), Color.White);
                }

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
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 3)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Finally, some peace...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
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
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 6)
                {
                    fieryTale.spriteBatch.DrawString(Names, "In my haste I don't notice the janitor standing in my way and run into him.", new Vector2(10, 580), Color.White);
                }
                #region obama convo
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
                        MediaPlayer.Stop();
                        fieryTale.attackedSomeone = true;
                        fieryTale.gameMoment = 0;
                        fieryTale.soundMoment = 0;
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
                    fieryTale.spriteBatch.DrawString(Names, "The janitor gives me directions and I run off to class.", new Vector2(10, 580), Color.White);
                }
                #endregion
                if (fieryTale.gameMoment == 14)
                {
                    
                    fieryTale.spriteBatch.DrawString(Names, "I am faster than expected and arrive at class slightly early.", new Vector2(10, 580), Color.White);
                    
                }
                if (fieryTale.gameMoment == 15)
                {
                    
                    fieryTale.spriteBatch.DrawString(Names, "Mr. Sins isn't busy, perhaps I could talk to him.", new Vector2(10, 580), Color.White);
                   
                }
                #region sins convo
                if (fieryTale.gameMoment == 16)
                {
                    foreach (var button in sinschoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 17)
                {
                    if (sinsoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I decide not to.", new Vector2(10, 580), Color.White);
                    }
                    else if (sinsoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Hello Mr. Sins, I was wondering, could you tell me a something about yourself?", new Vector2(10, 580), Color.White);
                    }
                    else if (sinsoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                    }
                    else if (sinsoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Wait, don't I know you from somewhere?", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 18)
                {
                    if (sinsoption == 1)
                    {
                        fieryTale.gameMoment = 26;
                    }
                    else if (sinsoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Sure. For starters I was not always a teacher, I've held many different jobs.", new Vector2(10, 580), Color.White);
                    }
                    else if (sinsoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Hey, what's up kid?", new Vector2(10, 580), Color.White);
                    }
                    else if (sinsoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "No idea what you're talking about kid.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 19)
                {
                    if (sinsoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Could you tell me a couple of them?", new Vector2(10, 580), Color.White);
                    }
                    else if (sinsoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                    }
                    else if (sinsoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I have seen you before, I think in a video on the internet...", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 20)
                {
                    if (sinsoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Well, I delivered pizza's once, was a plumber, scientist, doctor and was even an astronaut once.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "There are probably more, but they've slipped my mind. Was that everything kid?", new Vector2(10, 600), Color.White);
                    }
                    else if (sinsoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Stop staring kid and take a seat. [I take a seat]", new Vector2(10, 580), Color.White);
                    }
                    else if (sinsoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Kid, you're probably mistaking me for someone else.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 21)
                {
                    if (sinsoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Yes, that is quite alright, thank you Mr. Sins!", new Vector2(10, 580), Color.White);
                    }
                    else if (sinsoption == 3)
                    {
                        fieryTale.gameMoment = 26;
                    }
                    else if (sinsoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "No, I recognize you. You're hiding something... What is it you don't want us to know?", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 22)
                {
                    if (sinsoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Very well, take a seat, young Amamiya. [I take a seat]", new Vector2(10, 580), Color.White);
                    }
                    else if (sinsoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "You better stop talking, Kid. Last warning.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 23)
                {
                    if (sinsoption == 2)
                    {
                        fieryTale.gameMoment = 26;
                    }
                    else if (sinsoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I REMEMBER NOW! You're quite the star online...", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 24)
                {
                    if (sinsoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "THAT IS ENOUGH! I told you to drop it, now drop it. Take. A. Seat.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 25)
                {
                    if (sinsoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Hit a soft spot I see... [I take a seat]", new Vector2(10, 580), Color.White);
                    }
                }
                #endregion
                if (fieryTale.gameMoment == 26)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Same old boring lesson as last time.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 27)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Mr. Sins ends the lesson and wishes us good luck on the next one.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 28)
                {
                    fieryTale.spriteBatch.DrawString(Names, "This seems to be a window to talk to some classmates. But who?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 29)
                {
                    foreach (var button in talkchoice)//illusion of choice, just like many AAA games do
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 30)
                {
                    fieryTale.spriteBatch.DrawString(Names, "As I walk towards my classmate, our teacher comes walking in.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 31)
                {
                    fieryTale.spriteBatch.Draw(bitch, new Rectangle(980, 300, 300, 420), Color.White);//1280 x 1786
                    fieryTale.spriteBatch.DrawString(Names, "Teacher:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Young man, how dare you be absent from your seat? SIT DOWN RIGHT NOW!", new Vector2(10, 580), Color.White);
                }
                #region bitch convo
                if (fieryTale.gameMoment == 32)
                {
                    foreach (var button in bitchchoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 33)
                {
                    if (bitchoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I rip off my mask (glasses) and call forth Asterius from the sea of my soul.", new Vector2(10, 580), Color.White);
                    }
                    else if (bitchoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                    }
                    else if (bitchoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Sorry Miss. [I sit back down]", new Vector2(10, 580), Color.White);
                    }
                    else if (bitchoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Who are you to talk to me like that?", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 34)
                {
                    if (bitchoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(bitch, new Rectangle(980, 300, 300, 420), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Bitch:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "What the Hell is that monstrosity? You better get rid of it and sit back down!", new Vector2(10, 580), Color.White);
                    }
                    else if (bitchoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(bitch, new Rectangle(980, 300, 300, 420), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Bitch:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Young man I am speaking to you, answer me and sit down!", new Vector2(10, 580), Color.White);
                    }
                    else if (bitchoption == 3)
                    {
                        fieryTale.gameMoment = 38;
                    }
                    else if (bitchoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(bitch, new Rectangle(980, 300, 300, 420), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Bitch:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I am your superior and you will listen to me. Now SIT DOWN!", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 35)
                {
                    if (bitchoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Die! Die! DIE!", new Vector2(10, 580), Color.White);
                    }
                    else if (bitchoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                    }
                    else if (bitchoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I do not appreciate how you treat your students. How did you even get a position like this?", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 36)
                {
                    if (bitchoption == 1)
                    {
                        MediaPlayer.Stop();
                        fieryTale.attackedSomeone = true;
                        fieryTale.gameMoment = 0;
                        fieryTale.soundMoment = 0;
                    }
                    else if (bitchoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(bitch, new Rectangle(980, 300, 300, 420), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Bitch:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I will not stand for this. Sit down this instant or go to the principal!", new Vector2(10, 580), Color.White);
                    }
                    else if (bitchoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(bitch, new Rectangle(980, 300, 300, 420), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Bitch:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Well this is Hell, and I will remind you of that. Now sit down! [I sit down]", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 37)
                {
                    if (bitchoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "... [I sit down]", new Vector2(10, 580), Color.White);
                    }
                    else if (bitchoption == 4)
                    {
                        fieryTale.gameMoment = 38;
                    }
                }
                #endregion
                if (fieryTale.gameMoment == 38)
                {
                    fieryTale.spriteBatch.DrawString(Names, "This lesson truly reminded me I was in Hell.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 39)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I end the lesson with a mountain of homework to make.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 40)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I pack my stuff, but before I'm able to leave I hear someone shouting.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 41)
                {
                    fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Jock:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Hey four eyes, get over here!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 42)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 43)
                {
                    fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Jock:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Hey glasses, I'm talking to you!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 44)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "What, me?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 45)
                {
                    fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Jock:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Yeah, you. The other nerd with glasses already left.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 46)
                {
                    fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Jock:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Now listen. As you know Ms. Bitch gave us a shit ton of homework and...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 47)
                {
                    fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Jock:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You're gonna make it for me, understand?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 48)
                {
                    foreach (var button in jockchoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 49)
                {
                    if (jockoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I rip off my mask (glasses) and call forth Asterius from the sea of my soul.", new Vector2(10, 580), Color.White);
                    }
                    else if (jockoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Which part of your unevolved monkey brain entertained the thought I'd ever make your homework for you?", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Newsflash: I won't.", new Vector2(10, 600), Color.White);
                    }
                    else if (jockoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Look mate, I'm not making the homework twice, but you can copy the answers from me.", new Vector2(10, 580), Color.White);
                    }
                }

                fieryTale.spriteBatch.End();
            }
        }
    }
}

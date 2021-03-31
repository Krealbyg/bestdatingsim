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
    public class Day5 : DrawableGameComponent
    {
        private FieryTale fieryTale;

        //variables
        private int halloption;//for the hallway choice
        private int jockoption;//for the jock choice
        private int gorooption;//for talking to goro

        //lists
        private List<Button> hallchoice;
        private List<Button> jockchoice;
        private List<Button> gorochoice;
        private List<Button> nextday;

        //Fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //textures
        private Texture2D rennormal;
        private Texture2D anna;
        private Texture2D textbox;
        private Texture2D dorm;
        private Texture2D yasutora;
        private Texture2D shiki;
        private Texture2D sabel;
        private Texture2D classroom;
        private Texture2D sins;
        private Texture2D hallway;
        private Texture2D principal;

        //Goro expressions
        private Texture2D goroneutral;
        private Texture2D gorosmiling;
        private Texture2D goroshocked;
        private Texture2D gorococky;

        //sounds
        private SoundEffect mizanagi;
        private SoundEffect punishment;

        public Day5(FieryTale fieryTale) : base(fieryTale)
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Same shit, a different class. I'll get it right sometime. Oh maybe not tonight...
            rennormal = fieryTale.Content.Load<Texture2D>("RenNormal");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            dorm = fieryTale.Content.Load<Texture2D>("Dorm");
            anna = fieryTale.Content.Load<Texture2D>("Anna");
            yasutora = fieryTale.Content.Load<Texture2D>("Yasutora");
            shiki = fieryTale.Content.Load<Texture2D>("Shiki");
            sabel = fieryTale.Content.Load<Texture2D>("Sabel");
            sins = fieryTale.Content.Load<Texture2D>("Sinsleft");
            goroneutral = fieryTale.Content.Load<Texture2D>("GoroNeutral");
            gorosmiling = fieryTale.Content.Load<Texture2D>("GoroSmiling");
            goroshocked = fieryTale.Content.Load<Texture2D>("GoroShocked");
            gorococky = fieryTale.Content.Load<Texture2D>("GoroCocky");
            classroom = fieryTale.Content.Load<Texture2D>("Classroom");
            hallway = fieryTale.Content.Load<Texture2D>("Hallway");
            principal = fieryTale.Content.Load<Texture2D>("Principal");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");
            mizanagi = fieryTale.Content.Load<SoundEffect>("MagatsuIzanagi");
            punishment = fieryTale.Content.Load<SoundEffect>("ProperPunishment");

            #region buttons
            //hallway
            var hallchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 100),
                ButtonText = "Persona!"
            };
            var hallchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 200),
                ButtonText = "Stop"
            };
            var hallchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 300),
                ButtonText = "Let me help you there"
            };
            var hallchoice4 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 400),
                ButtonText = "Nothing"
            };

            //jock
            var jockchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 268),
                ButtonText = "Talk to him"
            };
            var jockchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 380),
                ButtonText = "Don't talk to him"
            };

            //goro
            var gorochoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 268),
                ButtonText = "Yes"
            };
            var gorochoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 380),
                ButtonText = "No"
            };

            //endday
            var nextlevel = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 279),
                ButtonText = "Next Day"
            };

            #endregion

            #region button choice event creation

            hallchoice1.Click += Hallchoice1_Click;
            hallchoice2.Click += Hallchoice2_Click;
            hallchoice3.Click += Hallchoice3_Click;
            hallchoice4.Click += Hallchoice4_Click;

            jockchoice1.Click += Jockchoice1_Click;
            jockchoice2.Click += Jockchoice2_Click;

            gorochoice1.Click += Gorochoice1_Click;
            gorochoice2.Click += Gorochoice2_Click;

            nextlevel.Click += Nextlevel_Click;

            #endregion

            #region filling lists

            hallchoice = new List<Button>
            {
                hallchoice1,
                hallchoice2,
                hallchoice3,
                hallchoice4
            };

            jockchoice = new List<Button>
            {
                jockchoice1,
                jockchoice2
            };

            gorochoice = new List<Button>
            {
                gorochoice1,
                gorochoice2
            };

            nextday = new List<Button>
            {
                nextlevel
            };

            #endregion

            base.LoadContent();
        }

        #region button click events
        private void Nextlevel_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 81)
            {
                fieryTale.currentLevel = 6;//starts next level
                fieryTale.gameMoment = 0;//resets the gameMoment count
                fieryTale.soundMoment = 0;//resets soundMoment
                MediaPlayer.Stop();//stops the chill music
                fieryTale.choiceMoment = false;
            }
        }

        //goro
        private void Gorochoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 71)
            {
                gorooption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Gorochoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 71)
            {
                gorooption = 1;
                fieryTale.goroPoints++;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        //jock
        private void Jockchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 38)
            {
                jockoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Jockchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 38)
            {
                jockoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        //hallway
        private void Hallchoice4_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 15)
            {
                halloption = 4;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Hallchoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 15)
            {
                halloption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Hallchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 15)
            {
                halloption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Hallchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 15)
            {
                halloption = 1;
                mizanagi.Play();
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }
        #endregion

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 5 && fieryTale.attackedSomeone == false)
            {
                if (fieryTale.gameMoment == 22 && fieryTale.soundMoment == 0 && halloption == 1)
                {
                    punishment.Play();
                    fieryTale.soundMoment++;
                }
                
                //button updates
                foreach (var button in hallchoice)
                    button.Update(gameTime);
                foreach (var button in jockchoice)
                    button.Update(gameTime);
                foreach (var button in gorochoice)
                    button.Update(gameTime);
                foreach (var button in nextday)
                    button.Update(gameTime);

                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 5 && fieryTale.attackedSomeone == false)
            {
                fieryTale.spriteBatch.Begin();

                //backgrounds
                if (fieryTale.gameMoment <= 4 || fieryTale.gameMoment > 66)
                {
                    fieryTale.spriteBatch.Draw(dorm, new Rectangle(0, 0, 1280, 760), Color.White);
                }
                else if (fieryTale.gameMoment > 4 && fieryTale.gameMoment <= 24 || fieryTale.gameMoment > 50 && fieryTale.gameMoment <= 66)
                {
                    fieryTale.spriteBatch.Draw(hallway, new Rectangle(0, 0, 1280, 720), Color.White);
                }
                else if (fieryTale.gameMoment > 24 && fieryTale.gameMoment <= 50)
                {
                    fieryTale.spriteBatch.Draw(classroom, new Rectangle(0, 0, 1280, 760), Color.White);
                }


                //textbox
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);//720 - 200 = 520, 1280 is screen width, 200 randomly decided

                //scenes
                if (fieryTale.gameMoment == 0)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I wake up, but my alarm isn't going off.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 1)
                {
                    fieryTale.spriteBatch.DrawString(Names, "It seems I've woken up early for once.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 2)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I can take my time doing my morning routine, for once.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 3)//I wonder as well. Jordy wrote this, but he never gave me an answer.
                {
                    fieryTale.spriteBatch.DrawString(Names, "Sadly it seems Akechi has already left for today, I wonder where he goes this early.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 4)
                {
                    fieryTale.spriteBatch.DrawString(Names, "After eating breakfast and getting my stuff ready, I leisurely leave for class.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 5)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I run into two of my classmates on the way there.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 6)
                {
                    fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Shiki:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "OH. MY. GOD. Your edgy emo look is, like, totally ruining my vibe!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 7)
                {
                    fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Shiki:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Trash like you shouldn't be allowed to walk the same halls as moi.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 8)
                {
                    fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Shiki:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Begone you eye sore!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 9)
                {
                    fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Please, leave me alone, I do not wish for people to talk to me.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 10)
                {
                    fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Shiki:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Say something loser-boy?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 11)
                {
                    fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Shiki:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You ever hear of chairs? But I guess it's fitting for trash like you to eat your food on the floor.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 12)//what a cunt
                {
                    fieryTale.spriteBatch.DrawString(Names, "She kicks his food out of his hands.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 13)
                {
                    fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Shiki:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Now pick it off of the floor like a good little pig!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 14)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I'm in a position to speak up to Shiki, but what should I say?", new Vector2(10, 580), Color.White);
                }
                #region hallway convo
                if (fieryTale.gameMoment == 15)
                {
                    foreach (var button in hallchoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 16)
                {
                    if (halloption == 1)//honestly, deserved. Also yes I reused this persona, because it's cool
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I rip off my mask (glasses) and summon forth Magatsu Izanagi from the sea of my soul.", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "HEY! Stop that!", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 3)//asshole Ren
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "No, no, no, you're doing it all wrong. Let me help", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 4)//Apathetic Ren
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I decide to do nothing and leave.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 17)
                {
                    if (halloption == 1)
                    {
                        fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Shiki:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "AAAAAAAAAAAAAAAAAAAAAAHHHHHHHHH!!", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 2)
                    {
                        fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Shiki:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Who do you think you are, telling me what to do?", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 3)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I step on Sabel's head.", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 4)
                    {
                        fieryTale.gameMoment = 25;
                    }
                }
                if (fieryTale.gameMoment == 18)
                {
                    if (halloption == 1)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "AAAAAAAAAAAAAAAAAAAAAHHHHH!!", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Who I am does not matter. You should pick on people your own size, you cunt.", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Like this you really show who's better.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 19)
                {
                    if (halloption == 1)
                    {
                        fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Shiki:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "What the fuck is that thing?!", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Sabel takes this opportunity to run.", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 3)
                    {
                        fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Shiki:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Ha, I like your style new kid.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 20)
                {
                    if (halloption == 1)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Please Amamiya-san have mercy I don't want to die!", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 2)
                    {
                        fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Shiki:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Fuck you let him get away. I wasn't done yet, I still needed to wipe my boots on him.", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 3)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I step off of Sabel and push Shiki away.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 21)
                {
                    if (halloption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Shiki tries to hind behind Sabel. She seems to have pissed her pants.", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "You should be ashamed of yourself. NOW GET OUT OF MY SIGHT!", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "You dare speak to me? Now get out of my sight, both of you!", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 22)
                {
                    if (halloption == 1)//again, love this line
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "You need proper punishment.", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Shiki visibly flinches from my outburst and hurries off to homeroom.", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 3)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I leave for homeroom.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 23)
                {
                    if (halloption == 1)
                    {
                        MediaPlayer.Stop();
                        fieryTale.attackedSomeone = true;
                        fieryTale.gameMoment = 0;
                        fieryTale.soundMoment = 0;
                    }
                    else if (halloption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Damn where did Sabel run off to?", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 3)
                    {
                        fieryTale.gameMoment = 25;
                    }
                }
                if (fieryTale.gameMoment == 24)
                {
                    if (halloption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I look around a bit for Sabel, but then go to homeroom.", new Vector2(10, 580), Color.White);
                    }
                }
                #endregion
                if (fieryTale.gameMoment == 25)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I sit down at my place and wait for homeroom to start.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 26)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Mr Sins comes walking in.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 27)
                {
                    fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Alright quiet down class, we're beginning the lesson.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 28)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Another man enters the classroom.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 29)//No idea who this guy is, he's not a reference to anyone I know. 
                {
                    fieryTale.spriteBatch.Draw(principal, new Rectangle(950, 240, 360, 600), Color.White);//360 x 600
                    fieryTale.spriteBatch.DrawString(Names, "Carter:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Good day children. I am the principal of this fine school, Principal Carter.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 30)
                {
                    fieryTale.spriteBatch.Draw(principal, new Rectangle(950, 240, 360, 600), Color.White);//360 x 600
                    fieryTale.spriteBatch.DrawString(Names, "Carter:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Mr Sins, would it be alright if I took Yasutora outside for a little chat?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 31)
                {
                    fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Yes, of course. Try to have him back by the end of the lesson for homework.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 32)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Yasutora stands up, he seems to be sweating.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 33)
                {
                    fieryTale.spriteBatch.DrawString(Names, "He and Carter leave the room.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 34)
                {
                    fieryTale.spriteBatch.DrawString(Names, "The rest of the lesson is quite uneventful.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 35)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Near the end, Yasutora returns.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 36)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Mr Sins gives us our homework and dismisses class.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 37)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Yasutora seems troubled, perhaps I should talk to him.", new Vector2(10, 580), Color.White);
                }
                #region jock convo
                if (fieryTale.gameMoment == 38)//nothing to really say about this convo. Just let's you get to know a classmate better I guess
                {
                    foreach (var button in jockchoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 39)
                {
                    if (jockoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I walk over to Yasutora.", new Vector2(10, 580), Color.White);
                    }
                    else if (jockoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I decide it's none of by business.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 40)
                {
                    if (jockoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Hey man, what was that about?", new Vector2(10, 580), Color.White);
                    }
                    else if (jockoption == 2)
                    {
                        fieryTale.gameMoment = 47;
                    }
                }
                if (fieryTale.gameMoment == 41)
                {
                    if (jockoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Yasutora:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "That's none of your business!", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 42)
                {
                    if (jockoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Calm down man, just asking. You look upset.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 43)
                {
                    if (jockoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Yasutora:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Well... I'm close to being expelled for how I treat others, but I can't help it.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 44)
                {
                    if (jockoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "That's rough buddy. Take care alright?", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 45)
                {
                    if (jockoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Yasutora:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Thanks. And don't tell anyone about this!", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 46)
                {
                    if (jockoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I won't, don't worry. [I sit back down]", new Vector2(10, 580), Color.White);
                    }
                }
                #endregion
                if (fieryTale.gameMoment == 47)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Class resumes, same old boring crap as usual.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 48)//P5 reference. Morgana is a talking cat with human intelligence and a human personality. He's Ren's pet, but they're more like best friends that live together. Morgana went with Ren everywhere, even to class.
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "It's times like this I really miss Morgana...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 49)//I wouldn't fault you for forgetting Ren is dead. He left a lot of people behind that cared about him
                {
                    fieryTale.spriteBatch.DrawString(Names, "I spend the rest of class thinking about the friends I left behind.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 50)
                {
                    fieryTale.spriteBatch.DrawString(Names, "After my last class I grab my stuff and leave the classroom.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 51)
                {
                    fieryTale.spriteBatch.DrawString(Names, "As I walk out into the corridor I am ambushed by someone yelling my name.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 52)//return of the thirst
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "REN! REN! OVER HERE!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 53)//what a mouthful
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Who's yell- oh Nishikinomiya-senpai, it's you. what's up?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 54)//which is why I added this
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Heyyy Ren! You can just call me Anna if you want.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 55)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I wanted to ask you something, urgently.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 56)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Alright, spill it.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 57)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Well you might not know this, but tomorrow is free day from school.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 58)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "So you have some time to just hang around on campus a bit.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 59)//would just make life harder for us if there was like an entire city
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "We aren't allowed to leave campus though.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 60)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Anyway, that's not important, sorry I got sidetracked.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 61)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I wanted to ask... You wanna hang out tomorrow? It'll be fun!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 62)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Well I don't have any plans so I suppo-", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 63)//Ren didn't even really agree yet
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "REALLY?! YES! I'll come pick you up at your dormroom tomorrow!", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 64)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I'll come pick you up at your dormroom tomorrow! Somewhere in the early afternoon.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 65)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "See you then, Ren~!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 66)//Guess you have
                {
                    fieryTale.spriteBatch.DrawString(Names, "I watch as Anna skips off happily, apparently I've just made plans.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 67)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I return to my dormroom.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 68)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Akechi is sitting in our living room, studying.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 69)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Hey Akechi, you got any plans for tomorrow?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 70)
                {
                    fieryTale.spriteBatch.Draw(gorococky, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Akechi:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Why, did you want to ask me on a date?", new Vector2(10, 580), Color.White);
                }
                #region Goro convo
                if (fieryTale.gameMoment == 71)
                {
                    foreach (var button in gorochoice)//chance for goropoint
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 72)
                {
                    if (gorooption == 1)//hopeful Ren
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Well I was thinking about it, but if you have plans...", new Vector2(10, 580), Color.White);
                    }
                    else if (gorooption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "No, just interested.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 73)
                {
                    if (gorooption == 1)//sad boy hours. Ren's got a prior appointment as well anyway.
                    {
                        fieryTale.spriteBatch.Draw(goroshocked, new Rectangle(1000, 340, 380, 380), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Akechi:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "O-oh, well I'm afraid I've got a prior appointment.", new Vector2(10, 580), Color.White);
                    }
                    else if (gorooption == 2)
                    {
                        fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Akechi:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Well if you got to know: Yes I have plans, that is all you're getting.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 74)
                {
                    if (gorooption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Shame, another time then. Wanna get dinner?", new Vector2(10, 580), Color.White);
                    }
                    else if (gorooption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Hmmm, very well I won't ask further. Wanna get dinner?", new Vector2(10, 580), Color.White);
                    }
                }
                #endregion
                if (fieryTale.gameMoment == 75)
                {
                    fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Akechi:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Yes, let's go, I'm starving.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 76)
                {
                    fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Akechi:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Oh, and Ren...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 77)//Goro is always reffered to by his last name in P5R, but thought he'd have opened up enough to let Ren call him Goro
                {
                    fieryTale.spriteBatch.Draw(gorosmiling, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You can call me Goro.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 78)//nice little dinner date.
                {
                    fieryTale.spriteBatch.DrawString(Names, "I go out for dinner with Goro.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 79)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Afterwards we return to our dormroom and play some chess.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 80)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Goro and I eventually go to our seperate rooms and I go to bed.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 81)
                {
                    foreach (var button in nextday)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }

                fieryTale.spriteBatch.End();
            }
        }
    }
}
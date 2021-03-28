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
    public class Day1 : DrawableGameComponent
    {
        FieryTale fieryTale;

        private int whichtalk; //which person you decided to talk to
        private int talkoption;//which option you chose when talking to someone

        //Lists (one for every choice moment)
        private List<Button> talkchoice;
        private List<Button> nerdchoice;
        private List<Button> bratchoice;
        private List<Button> jockchoice;
        private List<Button> emochoice;

        //Fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //Textures
        private Texture2D ren;
        private Texture2D rennormal;
        private Texture2D goku;
        private Texture2D background;
        private Texture2D textbox;
        private Texture2D anna;
        private Texture2D dorm;
        private Texture2D shiki;
        private Texture2D sabel;
        private Texture2D yasutora;

        //Sounds
        private SoundEffect drip;
        private SoundEffect teleport;

        public Day1(FieryTale fieryTale) : base(fieryTale)//constructor
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //you know the drill
            ren = fieryTale.Content.Load<Texture2D>("Ren");
            rennormal = fieryTale.Content.Load<Texture2D>("RenNormal");
            goku = fieryTale.Content.Load<Texture2D>("Drip_Goku");
            background = fieryTale.Content.Load<Texture2D>("Hell");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            anna = fieryTale.Content.Load<Texture2D>("Anna");
            dorm = fieryTale.Content.Load<Texture2D>("Dorm");
            shiki = fieryTale.Content.Load<Texture2D>("Shiki");
            sabel = fieryTale.Content.Load<Texture2D>("Sabel");
            yasutora = fieryTale.Content.Load<Texture2D>("Yasutora");
            drip = fieryTale.Content.Load<SoundEffect>("DripSound");
            teleport = fieryTale.Content.Load<SoundEffect>("Teleportsound");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");

            //put stuff having to do with buttons in regions because was a lot
            #region buttons
            //first choice
            var talkchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 100),
                ButtonText = "Nerd"
            };
            var talkchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 200),
                ButtonText = "Brat"
            };
            var talkchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 300),
                ButtonText = "Jock"
            };
            var talkchoice4 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 400),
                ButtonText = "Emo"
            };

            //when talking to nerd
            var nerdchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 125),
                ButtonText = "Hey"
            };
            var nerdchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 250),
                ButtonText = "..."
            };
            var nerdchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 375),
                ButtonText = "Boring"
            };

            //when talking to brat
            var bratchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 125),
                ButtonText = "Hey"
            };
            var bratchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 250),
                ButtonText = "..."
            };
            var bratchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 375),
                ButtonText = "Who are you?"
            };

            //when talking to jock
            var jockchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 125),
                ButtonText = "Hey"
            };
            var jockchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 250),
                ButtonText = "..."
            };
            var jockchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 375),
                ButtonText = "Who might you be?"
            };

            //when talking to emo
            var emochoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 125),
                ButtonText = "Hey"
            };
            var emochoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 250),
                ButtonText = "..."
            };
            var emochoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 375),
                ButtonText = "Speak up!"
            };

            #endregion

            #region buttons choice event creation

            //talkchoice
            talkchoice1.Click += Talkchoice1_Click;
            talkchoice2.Click += Talkchoice2_Click;
            talkchoice3.Click += Talkchoice3_Click;
            talkchoice4.Click += Talkchoice4_Click;

            //nerchoice
            nerdchoice1.Click += Nerdchoice1_Click;
            nerdchoice2.Click += Nerdchoice2_Click;
            nerdchoice3.Click += Nerdchoice3_Click;

            //bratchoice
            bratchoice1.Click += Bratchoice1_Click;
            bratchoice2.Click += Bratchoice2_Click;
            bratchoice3.Click += Bratchoice3_Click;

            //jockchoice
            jockchoice1.Click += Jockchoice1_Click;
            jockchoice2.Click += Jockchoice2_Click;
            jockchoice3.Click += Jockchoice3_Click;

            //emochoice
            emochoice1.Click += Emochoice1_Click;
            emochoice2.Click += Emochoice2_Click;
            emochoice3.Click += Emochoice3_Click;
            #endregion

            #region filling lists
            talkchoice = new List<Button>
            {
                talkchoice1,
                talkchoice2,
                talkchoice3,
                talkchoice4
            };
            nerdchoice = new List<Button>
            {
                nerdchoice1,
                nerdchoice2,
                nerdchoice3
            };
            bratchoice = new List<Button>
            {
                bratchoice1,
                bratchoice2,
                bratchoice3
            };
            jockchoice = new List<Button>
            {
                jockchoice1,
                jockchoice2,
                jockchoice3
            };
            emochoice = new List<Button>
            {
                emochoice1,
                emochoice2,
                emochoice3
            };
            #endregion
            base.LoadContent();
        }

        #region button click events

        //emo
        private void Emochoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 14 && whichtalk == 4)
            {
                talkoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Emochoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 14 && whichtalk == 4)
            {
                talkoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Emochoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 14 && whichtalk == 4)
            {
                talkoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        //jock
        private void Jockchoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 14 && whichtalk == 3)
            {
                talkoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Jockchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 14 && whichtalk == 3)
            {
                talkoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Jockchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 14 && whichtalk == 3)
            {
                talkoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        //brat
        private void Bratchoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 14 && whichtalk == 2)
            {
                talkoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Bratchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 14 && whichtalk == 2)
            {
                talkoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Bratchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 14 && whichtalk == 2)
            {
                talkoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        //nerd
        private void Nerdchoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 14 && whichtalk == 1)
            {
                talkoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Nerdchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 14 && whichtalk == 1)
            {
                talkoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Nerdchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 14 && whichtalk == 1)
            {
                talkoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        //talk
        private void Talkchoice4_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 12)
            {
                whichtalk = 4;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Talkchoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 12)
            {
                whichtalk = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Talkchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 12)
            {
                whichtalk = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Talkchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 12)
            {
                whichtalk = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }
        #endregion
        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 2 && fieryTale.attackedSomeone == false)//only in this level and no gameover
            {

                //update the buttons
                foreach (var button in talkchoice)
                    button.Update(gameTime);
                foreach (var button in nerdchoice)
                    button.Update(gameTime);
                foreach (var button in bratchoice)
                    button.Update(gameTime);
                foreach (var button in jockchoice)
                    button.Update(gameTime);
                foreach (var button in emochoice)
                    button.Update(gameTime);
               
                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 2 && fieryTale.attackedSomeone == false)//only while this level and no gameover
            {
                fieryTale.spriteBatch.Begin();
                
                //backgrounds
                

                //Textbox
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);//720 - 200 = 520, 1280 is screen width, 200 randomly decided

                //Scenes
                if (fieryTale.gameMoment == 0)
                {
                    fieryTale.spriteBatch.DrawString(Names, "You've woken up for your first day of school... in Hell.", new Vector2(10, 580), Color.White);//positions of text arbitrarily decided until it looked good
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 1)
                {
                    fieryTale.spriteBatch.DrawString(Names, "You decide you should probably wear some normal clothes to school.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 2)
                {
                    fieryTale.spriteBatch.DrawString(Names, "In a flash of blue fire your clothes change into what your usual outfit.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 3)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);//669 x 694 (size of original image)
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Looking good, me.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 4)
                {
                    fieryTale.spriteBatch.DrawString(Names, "You get ready and then set off for homeroom.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 5)
                {
                    fieryTale.spriteBatch.DrawString(Names, "You seem to have arrived a bit early and decide to introduce yourself to a classmate.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 6)
                {
                    fieryTale.spriteBatch.DrawString(Names, "A couple individuals catch your eye.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 7)
                {
                    fieryTale.spriteBatch.DrawString(Names, "At the front of the class, you see a nerdy looking girl.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 8)
                {
                    fieryTale.spriteBatch.DrawString(Names, "A bit behind the nerd is sitting your typical rich brat.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 9)
                {
                    fieryTale.spriteBatch.DrawString(Names, "On the other side of the room you see a buff jock.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 10)
                {
                    fieryTale.spriteBatch.DrawString(Names, "All the way at the back near the window you see an emo.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 11)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Quite the assortment of individuals, who will you talk to though?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 12)
                {
                    foreach (var button in talkchoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 13)
                {
                    if (whichtalk == 1)//nerd
                    {
                        fieryTale.spriteBatch.DrawString(Names, "You walk up to the nerd.", new Vector2(10, 580), Color.White);
                    }
                    else if (whichtalk == 2)//brat
                    {
                        fieryTale.spriteBatch.DrawString(Names, "You walk up to the brat.", new Vector2(10, 580), Color.White);
                    }
                    else if (whichtalk == 3)//jock
                    {
                        fieryTale.spriteBatch.DrawString(Names, "You walk up to the jock.", new Vector2(10, 580), Color.White);
                    }
                    else if (whichtalk == 4)//emo
                    {
                        fieryTale.spriteBatch.DrawString(Names, "You walk up to the emo.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 14)
                {
                    if (whichtalk == 1)//nerd
                    {
                        foreach (var button in nerdchoice)
                            button.Draw(gameTime);
                    }
                    else if (whichtalk == 2)//brat
                    {
                        foreach (var button in bratchoice)
                            button.Draw(gameTime);
                    }
                    else if (whichtalk == 3)//jock
                    {
                        foreach (var button in jockchoice)
                            button.Draw(gameTime);
                    }
                    else if (whichtalk == 4)//emo
                    {
                        foreach (var button in emochoice)
                            button.Draw(gameTime);
                    }
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 15)
                {
                    if (whichtalk == 1)//nerd
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Hello there, my name is Ren. And who are you?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);//change sprite later
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Hello classmate-san! My name is Kase Daiki, and who might you be?", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 2)//brat
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Hello my name is Ren Amamiya, I am a bit new here. Who are you if I may ask?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Who might you be?", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 3)//jock
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "hello, my name is Re-", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);//225 x 350
                            fieryTale.spriteBatch.DrawString(Names, "Jock:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Hey skinny guy! You must be new here, introduce yourself.", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 4)//emo
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Hello, my name is Ren, nice to meet you.", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Hey kid my name is Ren, who are you?", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 16)
                {
                    if (whichtalk == 1)//nerd
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "HI, I am Kase, nice to meet you Ren. Are you new here?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Ehm how can I help you classmate-san?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I am Ren, what do you want?", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 2)//brat
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);//1125 x 1141
                            fieryTale.spriteBatch.DrawString(Names, "Brat:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "[She glares at you] Sigh, it is Shiki if you must know, now please get out of my face,", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "you are disturbing my aura.", new Vector2(10, 600), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);//1125 x 1141
                            fieryTale.spriteBatch.DrawString(Names, "Brat:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Ehm... can I help you?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);//1125 x 1141
                            fieryTale.spriteBatch.DrawString(Names, "Brat:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Excuse me!? Do you even know who you are using that tone against?", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 3)//jock
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);//225 x 350
                            fieryTale.spriteBatch.DrawString(Names, "Jock:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "What do you want from me?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);//225 x 350
                            fieryTale.spriteBatch.DrawString(Names, "Jock:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "What?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...and who might you be?", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 4)//emo
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);//1199 x 1771
                            fieryTale.spriteBatch.DrawString(Names, "Emo:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Sabel, pleased to meet you. What made you talk to me?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Emo:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Emo:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "My name is Sabel, Ren-sama.", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 17)
                {
                    if (whichtalk == 1)//nerd
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Yes, I arrived yesterday in fact, how did you know?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Well, I wanted to share what I was reading to the new kid!", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 2)//brat
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Well, nice to meet such a friendly person. You do anything interesting?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "No that is why I asked who you were, are you going to tell me? Or are you just going to keep wasting my time?", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 3)//jock
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Calm down dude, I was just trying to introduce myself.", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Jock:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "WHO MIGHT I BE?! I asked you a question first you punk. Or do I need to beat it out of you?", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 4)//emo
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Well, I wanted to introduce myself to one of my classmates.", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Come on kid, speak up some more!", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 18)
                {
                    if (whichtalk == 1)//nerd
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "You do not look like you are from here, no offence though.", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Classmate-san? You there?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "That sounds boring and stupid, please leave me alone.", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 2)//brat
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Brat:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Please just leave me alone, your presence is ruining my mojo and I cannot have that today, so Buh-Bye", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Brat:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "You are really weirding me out, don’t you belong with weird and silent back there?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Brat:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I do not like your tone mister! I deserve some more respect around here!", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "And no, I will not be telling my name to such a low-class person as yourself!", new Vector2(10, 600), Color.White);
                        }
                    }
                    else if (whichtalk == 3)//jock
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Jock:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I do not care for who you are, you punk. So get out of the sight of Yasutora Sado, the strongest high schooler there is!", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Jock:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "If you do not start speaking in 3 seconds I will start beating you.", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "It is no concern to you who I am.", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 4)//emo
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Emo:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I appreciate the gesture sir, but I rather sit alone If you do not mind", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Emo:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Emo:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "EEP! Sorry but I can’t...", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 19)
                {
                    if (whichtalk == 1)//nerd
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I guess that is fair, can you tell me a bit about yourself?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "[starts tearing up] Meanie!", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 2)//brat
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "She waves you away. You take a seat by the window", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Alright then, thank you for wasting my time. [You take a seat by the window]", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 3)//jock
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Alright fine, good luck bathing in your own narcissism. [You take a seat by the window]", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Jock:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "You are below me and you will tell me your name this instant!", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 4)//emo
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Okay, take care Sabel. [You take a seat by the window]", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "There is nothing hard about it, speak up.", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 20)
                {
                    if (whichtalk == 1)//nerd
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Well, I like to read and learn new things. Also love to collect small things.", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "c-cl-classmate-san, please you are scaring me, could you tell me what’s wrong?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "You leave her be. You take a seat by the window", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 2)//brat
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.gameMoment = 24;
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Brat:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "HEY WEIRDO, I am talking to you, do you even know who I am? I am Shiki Batakan, and I am above you,", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "now if you can leave that would be greatly appreciated.", new Vector2(10, 600), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.gameMoment = 24;
                        }
                    }
                    else if (whichtalk == 3)//jock
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.gameMoment = 24;
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Jock:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "3...2...1...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I will do no such thing, now fuck off. [You take a seat by the window]", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 4)//emo
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.gameMoment = 24;
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Emo:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Emo:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "No Ren-sama, please stop pushing so much.", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 21)
                {
                    if (whichtalk == 1)//nerd
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Well, that is nice I suppose, I will see you later. [You take a seat by the window]", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.gameMoment = 24;
                        }
                    }
                    else if (whichtalk == 2)//brat
                    { 
                        if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 3)//jock
                    {
                        if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.gameMoment = 24;
                        }
                    }
                    else if (whichtalk == 4)//emo
                    {   
                        if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "... [You feel this is going nowhere, you take a seat by the window]", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "No wonder you are sitting alone. [You take a seat by the window]", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 22)
                {
                    if (whichtalk == 1)//nerd
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.gameMoment = 24;
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "[sobbing] c-c-c-classmate-san p-p-please stop...", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 2)//brat
                    {
                        if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Brat:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Okay, I am done  with you, weirdo. [She turns away]", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 3)//jock
                    {
                        if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "The Jock tries to punch you, but you effortlessly dodge it. Having embarrassed him enough,", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "you leave and take a seat by the window", new Vector2(10, 610), Color.White);
                        }
                    }
                    else if (whichtalk == 4)//emo
                    {
                        if (talkoption == 2)
                        {
                            fieryTale.gameMoment = 24;
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.gameMoment = 24;
                        }
                    }
                }
                if (fieryTale.gameMoment == 23)
                {
                    if (whichtalk == 1)//nerd
                    {
                        if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "... [You've tortured the poor girl enough, you take a seat by the window]", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 2)//brat
                    {
                        if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "You take your leave and take a seat by the window.", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 3)//jock
                    {
                        if (talkoption == 2)
                        {
                            fieryTale.gameMoment = 24;
                        }
                    }
                }
                if (fieryTale.gameMoment == 24)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Soon after sitting down, your homeroom teacher enters the classroom.", new Vector2(10, 580), Color.White);
                }

                fieryTale.spriteBatch.End();
            }
        }
    }
}

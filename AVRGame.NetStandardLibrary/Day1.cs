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
        private int gorooption;//only for goro
        private int goromancechoice;//for the secret romance ending choice on this day

        //Lists (one for every choice moment)
        private List<Button> talkchoice;
        private List<Button> nerdchoice;
        private List<Button> bratchoice;
        private List<Button> jockchoice;
        private List<Button> emochoice;
        private List<Button> gorochoice;
        private List<Button> goromance;
        private List<Button> endgame;
        private List<Button> nextday;

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

        //Goro expressions
        private Texture2D goroneutral;
        private Texture2D gorosmiling;
        private Texture2D gorosad;
        private Texture2D goroshocked;

        //Sounds
        private SoundEffect drip;
        private SoundEffect persona;
        private Song combat;

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
            drip = fieryTale.Content.Load<SoundEffect>("DripSound");                                                                                                                               
            persona = fieryTale.Content.Load<SoundEffect>("Arsene");
            combat = fieryTale.Content.Load<Song>("Combat");
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

            //when talking to Goro
            var gorochoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 150),
                ButtonText = "Akechi!"
            };
            var gorochoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 300),
                ButtonText = "Persona!"
            };

            //Goro romance chance
            var goromance1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 150),
                ButtonText = "So do I."
            };
            var goromance2= new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 300),
                ButtonText = "Just friends?"
            };

            //Endbuttons
            var endbutton = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)//game exit button
            {
                ButtonPosition = new Vector2(0, 279),
                ButtonText = "End Game",
            };
            var nextlevel = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 279),
                ButtonText = "Next Day"
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

            //gorochoice
            gorochoice1.Click += Gorochoice1_Click;
            gorochoice2.Click += Gorochoice2_Click;

            //goromance
            goromance1.Click += Goromance1_Click;
            goromance2.Click += Goromance2_Click;

            //endbuttons
            endbutton.Click += Endbutton_Click;
            nextlevel.Click += Nextlevel_Click;
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
            gorochoice = new List<Button>
            {
                gorochoice1,
                gorochoice2
            };
            goromance = new List<Button>
            {
                goromance1,
                goromance2
            };
            endgame = new List<Button>
            {
                endbutton
            };
            nextday = new List<Button>
            {
                nextlevel
            };
            #endregion
            base.LoadContent();
        }

        #region button click events
        //endlevel
        private void Nextlevel_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 61 && gorooption == 1)
            {
                fieryTale.currentLevel = 3;//starts next level
                fieryTale.gameMoment = 0;//resets the gameMoment count
                fieryTale.soundMoment = 0;//resets soundMoment
                MediaPlayer.Stop();//stops the chill music
                fieryTale.choiceMoment = false;
            }
        }

        private void Endbutton_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 61 && gorooption == 2)
            {
                fieryTale.Exit();//exits game
            }
        }

        //goromance
        private void Goromance2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 54 && gorooption == 1)
            {
                goromancechoice = 2;
                fieryTale.goroPoints++;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Goromance1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 54 && gorooption == 1)
            {
                goromancechoice = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }
        //goro
        private void Gorochoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 49)
            {
                gorooption = 2;
                persona.Play();
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
                if (fieryTale.songPlaying == true)
                {
                    MediaPlayer.Stop();
                    MediaPlayer.Play(combat);
                    MediaPlayer.Volume = 0.1f;
                    fieryTale.songPlaying = false;
                }
            }
        }

        private void Gorochoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 49)
            {
                gorooption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }
        //emo
        private void Emochoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 14 && whichtalk == 4)
            {
                talkoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
                fieryTale.gokuPoints--;
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
                fieryTale.gokuPoints++;
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
                fieryTale.gokuPoints--;
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
                fieryTale.gokuPoints++;
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
                fieryTale.gokuPoints--;
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
                fieryTale.gokuPoints++;
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
                fieryTale.gokuPoints--;
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
                fieryTale.gokuPoints++;
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
                //soundeffect
                if (fieryTale.gameMoment == 56 && fieryTale.soundMoment == 0 && gorooption == 2)
                {
                    drip.Play(volume: 0.1f, 0.0f, 0.0f);//loud on 100%
                    fieryTale.soundMoment++;//so doesnt loop
                }
                if (fieryTale.gameMoment == 61 && fieryTale.soundMoment == 1 && gorooption == 2)
                {
                    drip.Play(volume: 1f, 0.0f, 0.0f);
                    fieryTale.soundMoment++;//so doesnt loop
                }


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
                foreach (var button in gorochoice)
                    button.Update(gameTime);
                foreach (var button in goromance)
                    button.Update(gameTime);
                foreach (var button in endgame)
                    button.Update(gameTime);
                foreach (var button in nextday)
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
                if (fieryTale.gameMoment <= 4 || fieryTale.gameMoment > 45)//dormroom
                {
                    fieryTale.spriteBatch.Draw(dorm, new Rectangle(0, 0, 1280, 760), Color.White);
                }
                else if (fieryTale.gameMoment > 4 && fieryTale.gameMoment <= 45)//classroom
                {
                    fieryTale.spriteBatch.Draw(classroom, new Rectangle(0, 0, 1280, 760), Color.White);
                }

                //Textbox
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);//720 - 200 = 520, 1280 is screen width, 200 randomly decided

                //Scenes
                if (fieryTale.gameMoment == 0)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I've woken up for my first day of school... in Hell.", new Vector2(10, 580), Color.White);//positions of text arbitrarily decided until it looked good
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 1)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I decide I should probably wear some normal clothes to school.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 2)
                {
                    fieryTale.spriteBatch.DrawString(Names, "In a flash of blue fire my clothes change into my usual outfit.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 3)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);//669 x 694 (size of original image)
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Looking good, me.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 4)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I get ready and then set off for homeroom.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 5)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I seem to have arrived a bit early and decide to introduce myself to a classmate.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 6)
                {
                    fieryTale.spriteBatch.DrawString(Names, "A couple individuals catch my eye.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 7)
                {
                    fieryTale.spriteBatch.DrawString(Names, "At the front of the class, I see a nerdy looking girl.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 8)
                {
                    fieryTale.spriteBatch.DrawString(Names, "A bit behind the nerd is sitting your typical rich brat.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 9)
                {
                    fieryTale.spriteBatch.DrawString(Names, "On the other side of the room I see a buff jock.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 10)
                {
                    fieryTale.spriteBatch.DrawString(Names, "All the way at the back near the window I see an emo.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 11)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Quite the assortment of individuals, who will I talk to though?", new Vector2(10, 580), Color.White);
                }
                #region classmate convo
                if (fieryTale.gameMoment == 12)//first choice
                {
                    foreach (var button in talkchoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 13)
                {
                    if (whichtalk == 1)//nerd
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I walk up to the nerd.", new Vector2(10, 580), Color.White);
                    }
                    else if (whichtalk == 2)//brat
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I walk up to the brat.", new Vector2(10, 580), Color.White);
                    }
                    else if (whichtalk == 3)//jock
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I walk up to the jock.", new Vector2(10, 580), Color.White);
                    }
                    else if (whichtalk == 4)//emo
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I walk up to the emo.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 14)//honestly, this part was hell. So many fucking choices.
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
                if (fieryTale.gameMoment == 15)//here the first instance of the "..." running gag starts. Ren is a silent protagonist in the game, only speaking when you make a choice. This is a little nod to that. Also the "..." option appears in Persona 5 as well sometimes.
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
                            fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);//666 x 1165
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
                            fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "HI, I am Kase, nice to meet you Ren. Are you new here?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)//wanted to use japanese suffixes, because the game is very much inspired by japanese game (Persona) and we've taken a lot of ideas from anime as well.
                        {
                            fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
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
                        if (talkoption == 1)//anything in "[]" are little comments Ren makes while someone else is talking.
                        {
                            fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);//1125 x 1141
                            fieryTale.spriteBatch.DrawString(Names, "Brat:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "[She glares at me] Sigh, it is Shiki if you must know, now please get out of my face,", new Vector2(10, 580), Color.White);
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
                        else if (talkoption == 3)//-sama is very official
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
                            fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Well, I wanted to share what I was reading to the new kid!", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 2)//brat
                    {
                        if (talkoption == 1)//sassy
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
                            fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "You do not look like you are from here, no offence though.", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Classmate-san? You there?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)//harsh
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
                            fieryTale.spriteBatch.DrawString(Talking, "You are really weirding me out, don't you belong with weird and silent back there?", new Vector2(10, 580), Color.White);
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
                            fieryTale.spriteBatch.DrawString(Talking, "I do not care for who you are, you punk. So get out of the sight of Yasutora Sado,", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "the strongest high schooler there is!", new Vector2(10, 600), Color.White);
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
                            fieryTale.spriteBatch.DrawString(Talking, "EEP! Sorry, but I can't...", new Vector2(10, 580), Color.White);
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
                            fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "[starts tearing up] Meanie!", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 2)//brat
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "She waves me away. I take a seat by the window", new Vector2(10, 580), Color.White);
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
                            fieryTale.spriteBatch.DrawString(Talking, "Alright then, thank you for wasting my time. [I take a seat by the window]", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 3)//jock
                    {
                        if (talkoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Alright fine, good luck bathing in your own narcissism. [I take a seat by the window]", new Vector2(10, 580), Color.White);
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
                            fieryTale.spriteBatch.DrawString(Talking, "Okay, take care Sabel. [I take a seat by the window]", new Vector2(10, 580), Color.White);
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
                            fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Well, I like to read and learn new things. Also love to collect small things.", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Nerd:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "c-cl-classmate-san, please you are scaring me, could you tell me what's wrong?", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I leave her be. I take a seat by the window", new Vector2(10, 580), Color.White);
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
                            fieryTale.spriteBatch.DrawString(Talking, "I will do no such thing, now fuck off. [I take a seat by the window]", new Vector2(10, 580), Color.White);
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
                            fieryTale.spriteBatch.DrawString(Talking, "Well, that is nice I suppose, I will see you later. [I take a seat by the window]", new Vector2(10, 580), Color.White);
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
                            fieryTale.spriteBatch.DrawString(Talking, "... [I feel like this is going nowhere, I take a seat by the window]", new Vector2(10, 580), Color.White);
                        }
                        else if (talkoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "No wonder you are sitting alone. [I take a seat by the window]", new Vector2(10, 580), Color.White);
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
                            fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
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
                            fieryTale.spriteBatch.DrawString(Talking, "Okay, I am done with you, weirdo. [She turns away]", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 3)//jock
                    {
                        if (talkoption == 2)//This is Ren after the main events of Persona 5, he's an excellent fighter.
                        {
                            fieryTale.spriteBatch.DrawString(Names, "The Jock tries to punch me, but I effortlessly dodge it. Having embarrassed him enough,", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "I leave and take a seat by the window", new Vector2(10, 610), Color.White);
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
                        if (talkoption == 2)//goodguy Ren
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "... [I've tortured the poor girl enough, I take a seat by the window]", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (whichtalk == 2)//brat
                    {
                        if (talkoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I take my leave and take a seat by the window.", new Vector2(10, 580), Color.White);
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
                #endregion
                if (fieryTale.gameMoment == 24)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Soon after sitting down, my homeroom teacher enters the classroom.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 25)//This guy might look familiar...
                {
                    fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);//524 x 695
                    fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Hello my name is Mister Sins, but you can also call me just Mister or Sins.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 26)
                {
                    fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Let's start with a small introduction round. We'll start in the front and work our way backwards.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 27)
                {
                    fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Let's see... you go first. [he's pointing at the nerd]", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 28)
                {
                    fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Kase:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Hello, my name is Kase Daiki, I love to read and collect things.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 29)
                {
                    fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Brat:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "[whispering] pfff what a nerd.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 30)
                {
                    fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Next up, the lady diagonally behind Kase-chan.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 31)
                {
                    fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Brat:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "That would be me you are talking about. I expected a greater introduction, but alas this will have to do.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 32)
                {
                    fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Shiki:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "My name is Shiki Batakan, I am more famous than any of you will ever be!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 33)
                {
                    fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Yes yes, very interesting. Moving on to the boy with the glasses by the window. [That would be me]", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 34)//activities you can do in Persona 5 Royal
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "My name is Ren Amamiya. I enjoy playing billiards and darts.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 35)
                {
                    fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Jock:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Those aren't even real sports you loser!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 36)
                {
                    fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Alright, the loudmouth is next.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 37)
                {
                    fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Yasutora:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Hmpf fine. I am Yasutora Sado, I play real sports and get all them bitches.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 38)
                {
                    fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Yeah yeah, sure you do. Finally, the person all the way in the back by the window.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 39)
                {
                    fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Hello, my name is Sabel Ammerasou, I like reading manga and hanging with friends.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 40)
                {
                    fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Yasutora:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "HAHAHA what a fucking loser!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 41)
                {
                    fieryTale.spriteBatch.Draw(shiki, new Rectangle(950, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Shiki:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "haha imagine being such a loser!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 42)
                {
                    fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Kase:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Come on guys cut him some slack...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 43)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 44)
                {
                    fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "ENOUGH! I will not tolerate this kind of behaviour in my classroom. Now calm down and let's start the lesson.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 45)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I pay no attention to class. Afterwards I leave for my dormroom.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Hopefully I'll meet my roommate.", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 46)
                {
                    fieryTale.spriteBatch.DrawString(Names, "As I enter my dormroom I'm greeted by my roommate...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 47)
                {
                    fieryTale.spriteBatch.Draw(gorosmiling, new Rectangle(1000, 340, 380, 380), Color.White);//616 x 614
                    fieryTale.spriteBatch.DrawString(Names, "Roommate:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Ah hello, you must be my new roommate. Nice to me-", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 48)//Goro Akechi is a character from Persona 5. He's Ren's rival, semi-friend, teammate for some time, and there's quite a bit of romantic tension between them.
                {
                    fieryTale.spriteBatch.Draw(goroshocked, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Akechi:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Ren?!", new Vector2(10, 580), Color.White);
                }
                #region end of level split paths
                if (fieryTale.gameMoment == 49)
                {
                    foreach (var button in gorochoice)//this is where rest of level splits
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 50)
                {
                    if (gorooption == 1)
                    {
                        fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Akechi:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "So, the great leader of the Phantom Thieves has died then...", new Vector2(10, 580), Color.White);
                    }
                    else if (gorooption == 2)//first chance to summon a persona, thought it appropriate that Ren would summon his main one
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I tear off my mask (glasses) and summon forth Arsene from the sea of my soul.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 51)
                {
                    if (gorooption == 1)
                    {
                        fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Akechi:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Hmmm, well I could imagine a worse roommate if I'm being honest.", new Vector2(10, 580), Color.White);
                    }
                    else if (gorooption == 2)//Goro is also a Persona user, quite a powerful one actually.
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Akechi quickly does the same, summoning forth Loki.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 52)
                {
                    if (gorooption == 1)//Reference to Persona 5 Royal's true ending
                    {
                        fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Akechi:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "You granted my wishes by rejecting Maruki's world, for that I am still grateful.", new Vector2(10, 580), Color.White);
                    }
                    else if (gorooption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "We engage in an intense duel and fight with no regard to ourselves or our surroundings.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 53)
                {
                    if (gorooption == 1)//Goro states something like this in Persona 5 as well
                    {
                        fieryTale.spriteBatch.Draw(gorosad, new Rectangle(1000, 340, 380, 380), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Akechi:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Yet, my mind sometimes wandered to what could've been... I believe we could've been great friends.", new Vector2(10, 580), Color.White);
                    }
                    else if (gorooption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "We wreak havoc and many innocents that stand between us fall.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 54)
                {
                    if (gorooption == 1)
                    {
                        foreach (var button in goromance)//first chance for goropoint in whole game.
                            button.Draw(gameTime);
                        fieryTale.choiceMoment = true;
                    }
                    else if (gorooption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "The dorms are no more, only ruin remains. In the middle of it, we stand.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 55)
                {
                    if (gorooption == 1)
                    {
                        if (goromancechoice == 1)
                        {
                            fieryTale.spriteBatch.Draw(gorosmiling, new Rectangle(1000, 340, 380, 380), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Akechi:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I'm glad you think so as well.", new Vector2(10, 580), Color.White);
                        }
                        else if (goromancechoice == 2)
                        {
                            fieryTale.spriteBatch.Draw(goroshocked, new Rectangle(1000, 340, 380, 380), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Akechi:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "W-what are you insinuating?", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (gorooption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "As we both ready another attack, someone appears before us.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 56)
                {
                    if (gorooption == 1)
                    {
                        fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Akechi:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Anyway, perhaps this is the universe's weird way of giving us a second chance...", new Vector2(10, 580), Color.White);
                    }
                    else if (gorooption == 2)//goku comes in to ruin the fun
                    {
                        fieryTale.spriteBatch.Draw(goku, new Vector2(990, 300), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "This ends here.", new Vector2(10, 580), Color.White);
                        MediaPlayer.Stop();
                    }
                }
                if (fieryTale.gameMoment == 57)
                {
                    if (gorooption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Whatever it is, let us make the best of it.", new Vector2(10, 580), Color.White);
                    }
                    else if (gorooption == 2)
                    {
                        fieryTale.spriteBatch.Draw(goku, new Vector2(990, 300), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "The both of you deserve proper punishment.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 58)
                {
                    if (gorooption == 1)
                    {
                        fieryTale.spriteBatch.Draw(gorosmiling, new Rectangle(1000, 340, 380, 380), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Akechi:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Agreed. Now then, how have you been? Anything of note happen since my death?", new Vector2(10, 580), Color.White);
                    }
                    else if (gorooption == 2)//Goku is like Dr Manhattan at the end of Watchmen
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Goku stretches out his hand towards Akechi and in an instant he is atomised.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 59)
                {
                    if (gorooption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Well, let me think...", new Vector2(10, 580), Color.White);
                    }
                    else if (gorooption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Goku turns his attention to me and I feel an intense sense of dread.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 60)
                {
                    if (gorooption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Akechi and I spend some time catching up, then we both go to bed.", new Vector2(10, 580), Color.White);
                    }
                    else if (gorooption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "This is it, I've made a grave mistake...", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 61)
                {
                    if (gorooption == 1)
                    {
                        foreach (var button in nextday)
                            button.Draw(gameTime);
                    }
                    else if (gorooption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Gameover", new Vector2(10, 580), Color.White);
                        foreach (var button in endgame)
                            button.Draw(gameTime);
                    }
                    fieryTale.choiceMoment = true;
                }
                #endregion
                fieryTale.spriteBatch.End();
            }
        }
    }
}

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
    public class Day10 : DrawableGameComponent
    {
        private FieryTale fieryTale;

        private int spyoption;//which way you decided to deal with Anna the yandere stalker
        private int simpoption;//which way you decide to react to the stalkers confession
        private int shooteroption;//which way you react to Sabel asking about Anna's confession
        private int shotoption;//for when you decide to either kill or only severely maim (subdue) Sabel
        private int gunoption;//which choice for when handed the gun
        private int kissoption;//which way you decide to react to Anna trying to kiss you.

        //lists
        private List<Button> spychoice;
        private List<Button> simpchoice;
        private List<Button> shooterchoice;
        private List<Button> shotchoice;
        private List<Button> gunchoice;
        private List<Button> kisschoice;
        private List<Button> nextday;

        //Fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //textures
        private Texture2D rennormal;
        private Texture2D anna;
        private Texture2D cheem;
        private Texture2D textbox;
        private Texture2D dorm;
        private Texture2D hell;
        private Texture2D sins;
        private Texture2D yasutora;
        private Texture2D kase;
        private Texture2D sabel;
        private Texture2D mrcare;
        private Texture2D hallway;

        //Goro expressions
        private Texture2D goroneutral;
        private Texture2D gorosmiling;
        private Texture2D gorococky;
        private Texture2D goromaid;
        private Texture2D goromaid2;
        private Texture2D gorowink;

        //sound
        private SoundEffect thanatos;
        private SoundEffect endit;
        private SoundEffect silence;
        private SoundEffect izanagi;
        private SoundEffect slash;
        private SoundEffect kaguya;
        private Song combat;

        public Day10(FieryTale fieryTale) : base(fieryTale)
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Honestly Ren's pretty hot as well.
            rennormal = fieryTale.Content.Load<Texture2D>("RenNormal");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            dorm = fieryTale.Content.Load<Texture2D>("Dorm");
            hell = fieryTale.Content.Load<Texture2D>("Hell");
            anna = fieryTale.Content.Load<Texture2D>("Anna");
            cheem = fieryTale.Content.Load<Texture2D>("Cheem");
            yasutora = fieryTale.Content.Load<Texture2D>("Yasutora");
            kase = fieryTale.Content.Load<Texture2D>("Kase");
            sabel = fieryTale.Content.Load<Texture2D>("Sabel");
            sins = fieryTale.Content.Load<Texture2D>("Sinsleft");
            goroneutral = fieryTale.Content.Load<Texture2D>("GoroNeutral");
            gorosmiling = fieryTale.Content.Load<Texture2D>("GoroSmiling");
            gorococky = fieryTale.Content.Load<Texture2D>("GoroCocky");
            goromaid = fieryTale.Content.Load<Texture2D>("Goromaid");
            goromaid2 = fieryTale.Content.Load<Texture2D>("Goromaid2");
            gorowink = fieryTale.Content.Load<Texture2D>("GoroWink");
            mrcare = fieryTale.Content.Load<Texture2D>("MrCare");
            hallway = fieryTale.Content.Load<Texture2D>("Hallway");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");
            thanatos = fieryTale.Content.Load<SoundEffect>("Thanatos");
            endit = fieryTale.Content.Load<SoundEffect>("EndIt");
            izanagi = fieryTale.Content.Load<SoundEffect>("izanagi");
            slash = fieryTale.Content.Load<SoundEffect>("slash");
            kaguya = fieryTale.Content.Load<SoundEffect>("Kaguya");
            silence = fieryTale.Content.Load<SoundEffect>("Silence");
            combat = fieryTale.Content.Load<Song>("Combat");

            #region buttons
            //spy choice
            var spychoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 125),
                ButtonText = "Friendly"
            };
            var spychoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 250),
                ButtonText = "Neutral"
            };
            var spychoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 375),
                ButtonText = "Rude"
            };

            //simp choice
            var simpchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 100),
                ButtonText = "Persona!"
            };
            var simpchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 200),
                ButtonText = "Oh"
            };
            var simpchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 300),
                ButtonText = "Ehm"
            };
            var simpchoice4 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 400),
                ButtonText = "Hmm"
            };

            //shooter choice
            var shooterchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 125),
                ButtonText = "It was me"//Barry!
            };
            var shooterchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 250),
                ButtonText = "I have a hunch"
            };
            var shooterchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 375),
                ButtonText = "No clue mate"
            };

            //shot choice (for when shot at)
            var shotchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 268),//360(center of screen) - 20 - 72(button height)
                ButtonText = "Kill",
            };

            var shotchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 380),//360(center of screen) + 20
                ButtonText = "Subdue",
            };

            //gun choice
            var gunchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 125),
                ButtonText = "Persona"
            };
            var gunchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 250),
                ButtonText = "Let's do this [lie]"
            };
            var gunchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 375),
                ButtonText = "Is that a gun?"
            };

            //kiss choice
            var kisschoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 100),
                ButtonText = "Persona!"
            };
            var kisschoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 200),
                ButtonText = "Make out"
            };
            var kisschoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 300),
                ButtonText = "Dodge"
            };
            var kisschoice4 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 400),
                ButtonText = "Hug"
            };

            //endday
            var nextlevel = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 279),
                ButtonText = "Next Day"
            };
            #endregion

            #region create button click events

            spychoice1.Click += Spychoice1_Click;
            spychoice2.Click += Spychoice2_Click;
            spychoice3.Click += Spychoice3_Click;

            simpchoice1.Click += Simpchoice1_Click;
            simpchoice2.Click += Simpchoice2_Click;
            simpchoice3.Click += Simpchoice3_Click;
            simpchoice4.Click += Simpchoice4_Click;

            shooterchoice1.Click += Shooterchoice1_Click;
            shooterchoice2.Click += Shooterchoice2_Click;
            shooterchoice3.Click += Shooterchoice3_Click;

            shotchoice1.Click += Shotchoice1_Click;
            shotchoice2.Click += Shotchoice2_Click;

            gunchoice1.Click += Gunchoice1_Click;
            gunchoice2.Click += Gunchoice2_Click;
            gunchoice3.Click += Gunchoice3_Click;

            kisschoice1.Click += Kisschoice1_Click;
            kisschoice2.Click += Kisschoice2_Click;
            kisschoice3.Click += Kisschoice3_Click;
            kisschoice4.Click += Kisschoice4_Click;

            nextlevel.Click += Nextlevel_Click;

            #endregion

            #region filling lists

            spychoice = new List<Button>
            {
                spychoice1,
                spychoice2,
                spychoice3
            };

            simpchoice = new List<Button>
            {
                simpchoice1,
                simpchoice2,
                simpchoice3,
                simpchoice4
            };

            shooterchoice = new List<Button>
            {
                shooterchoice1,
                shooterchoice2,
                shooterchoice3
            };

            shotchoice = new List<Button>
            {
                shotchoice1,
                shotchoice2
            };

            gunchoice = new List<Button>
            {
                gunchoice1,
                gunchoice2,
                gunchoice3
            };

            kisschoice = new List<Button>
            {
                kisschoice1,
                kisschoice2,
                kisschoice3,
                kisschoice4
            };

            nextday = new List<Button>
            {
                nextlevel
            };

            #endregion

            base.LoadContent();
        }

        private void Nextlevel_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 108)
            {
                fieryTale.currentLevel = 9;//starts next level
                fieryTale.gameMoment = 0;//resets the gameMoment count
                fieryTale.soundMoment = 0;//resets soundMoment
                MediaPlayer.Stop();//stops the chill music
                fieryTale.choiceMoment = false;
            }
        }

        //kiss
        private void Kisschoice4_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 92)
            {
                kissoption = 4;
                fieryTale.goroPoints++;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Kisschoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 92)
            {
                kissoption = 3;
                fieryTale.goroPoints++;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Kisschoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 92)
            {
                kissoption = 2;
                fieryTale.goroPoints = -100;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Kisschoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 92)
            {
                kissoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        //gun
        private void Gunchoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 62)
            {
                gunoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Gunchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 62)
            {
                gunoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Gunchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 62)
            {
                gunoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        //shot
        private void Shotchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 70)
            {
                shotoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Shotchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 70)
            {
                shotoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        //shooter aka Sabel
        private void Shooterchoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 54)
            {
                shooteroption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Shooterchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 54)
            {
                shooteroption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Shooterchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 54)
            {
                shooteroption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        //simping
        private void Simpchoice4_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 27)
            {
                simpoption = 4;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Simpchoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 27)
            {
                simpoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Simpchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 27)
            {
                simpoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Simpchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 27)
            {
                simpoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        //stalker
        private void Spychoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 11)
            {
                spyoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Spychoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 11)
            {
                spyoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Spychoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 11)
            {
                spyoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 8 && fieryTale.attackedSomeone == false)
            {
                
                if (fieryTale.gameMoment == 28 && fieryTale.soundMoment == 0 && simpoption == 4)
                {
                    silence.Play();
                    fieryTale.soundMoment++;
                }
                if(fieryTale.gameMoment == 31 && fieryTale.soundMoment == 0 && simpoption == 1)
                {
                    thanatos.Play();
                    fieryTale.soundMoment++;
                }
                if (fieryTale.gameMoment == 33 && fieryTale.soundMoment == 1 && simpoption == 1)
                {
                    endit.Play();
                    fieryTale.soundMoment++;
                }
                if (fieryTale.gameMoment == 63 && fieryTale.soundMoment < 2 && shooteroption == 3 && gunoption == 1)
                {
                    kaguya.Play();
                    fieryTale.soundMoment = 2;
                }
                if (fieryTale.gameMoment == 68 && fieryTale.soundMoment < 2 && shooteroption == 1)
                {
                    izanagi.Play();
                    fieryTale.soundMoment = 2;
                }
                if (fieryTale.gameMoment == 71 && fieryTale.soundMoment < 3 && shooteroption == 1)
                {
                    slash.Play();
                    fieryTale.soundMoment++;
                }

                foreach (var button in spychoice)
                    button.Update(gameTime);
                foreach (var button in simpchoice)
                    button.Update(gameTime);
                foreach (var button in shooterchoice)
                    button.Update(gameTime);
                foreach (var button in shotchoice)
                    button.Update(gameTime);
                foreach (var button in gunchoice)
                    button.Update(gameTime);
                foreach (var button in kisschoice)
                    button.Update(gameTime);
                foreach (var button in nextday)
                    button.Update(gameTime);

                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 8 && fieryTale.attackedSomeone == false)
            {
                fieryTale.spriteBatch.Begin();

                //backgrounds
                if (fieryTale.gameMoment <= 5 || fieryTale.gameMoment >= 104)
                {
                    fieryTale.spriteBatch.Draw(dorm, new Rectangle(0, 0, 1280, 760), Color.White);
                }
                else if (fieryTale.gameMoment > 5 && fieryTale.gameMoment < 42 || fieryTale.gameMoment >= 80 && fieryTale.gameMoment < 104)
                {
                    fieryTale.spriteBatch.Draw(hell, new Rectangle(0, 0, 1280, 720), Color.White);
                }
                else if (fieryTale.gameMoment >= 42 && fieryTale.gameMoment < 80)
                {
                    fieryTale.spriteBatch.Draw(hallway, new Rectangle(0, 0, 1280, 720), Color.White);
                }

                //textbox
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);

                //scenes
                if (fieryTale.gameMoment == 0)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I wake up extra early, I've got something to do before class today.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 1)//Wanted to do something more before just starting the day straight away, so a little convo with best girl Goro
                {
                    fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You're up early.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 2)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "There's something I need to do today.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 3)
                {
                    fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Ah, you're finally going to confront that stalker of yours.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 4)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Yes, it's gone on long enough. I want some answers.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 5)
                {
                    fieryTale.spriteBatch.Draw(gorosmiling, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Good luck.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 6)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I leave my dormroom and walk around outside, baiting Anna out.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 7)
                {
                    fieryTale.spriteBatch.DrawString(Names, "It doesn't take long until I spot her, I go to confront her.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 8)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Anna stop hiding, I know you're spying on me. We need to talk, now.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 9)
                {
                    fieryTale.spriteBatch.DrawString(Names, "She comes to stand infront of me, embarrassed.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 10)
                {
                    fieryTale.spriteBatch.DrawString(Names, "How should I confront her?", new Vector2(10, 580), Color.White);
                }
                #region stalker convo
                if (fieryTale.gameMoment == 11)
                {
                    foreach (var button in spychoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 12)
                {
                    if (spyoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Anna, you might mean well, but you've gotta stop following me. It's kinda creepy.", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Look, I don't know what's going on with you lately, but please stop following me.", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 3)//might be the rude choice, but its justified.
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I'm going to get straight to the point. Stop. Following. Me.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 13)
                {
                    if (spyoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Oh, I'm sorry Ren.", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Oh, ok. I didn't know you could see me. Why don't you want me following you?", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "B-b-but...", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 14)
                {
                    if (spyoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Why are you even following me? Don't you have like student council stuff to do?", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Do you hear yourself? This is not something people normally do.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                    }
                    else if (spyoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "No buts. It's really easy. You can't possibly fuck this request up. Just stop stalking me.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 15)
                {
                    if (spyoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Well, yes, but I just made other people do them. Getting to know you is more important.", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "You can just come to me to talk you know? No need for this melodramatic bullshit.", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I-I just want to know you better.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 16)
                {
                    if (spyoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "You went to all this trouble to get to know me? You can just talk to me, you know?", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "It's not as easy as it sounds! I have a hard time asking people things,", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "especially intimate things...", new Vector2(10, 600), Color.White);
                    }
                    else if (spyoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "So you stalked me? You can just strike up a conversation, like a normal person.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Why can't you be normal?", new Vector2(10, 600), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 17)
                {
                    if (spyoption == 1)//Maybe you've been wondering about the ~ thing at the end of words. This indicates the holding of a vowel in Japanese. so Nya becomes Nyaaaa
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Okay, I'll try, just for you! Nya~", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 2)//Ren really is dense isn't he. I'd probs be just as dense in this situation tho, tbh
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "What intimate stuff could you ask me? We're just friends, right?", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "W-Well, I-", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 18)
                {
                    if (spyoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Good, I'm happy you understand. So now that we can converse in a normal way,", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "got anything to say?", new Vector2(10, 600), Color.White);
                    }
                    else if (spyoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "You know... intimate stuff. Can you not fill it in. This is embarrassing.", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Actually, you know what, I don't care.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 19)
                {
                    if (spyoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Well, yes. I wanted to te-", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Anna, I can't read minds. If you have anything to say or ask, just do it.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I'm not in the mood for games.", new Vector2(10, 600), Color.White);
                    }
                    else if (spyoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Aww, you don't care that I'm weird? That's so sweet of you!", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 20)
                {
                    if (spyoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "That reminds me actually, when we where hanging out last time, where'd you run off to?", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "My feelings are not a game, Ren! Can you not understand that?", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 3)//mmmm monke
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Not what I fucking meant, you monkey! You know what forget it, I'm really not in the mood.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 21)
                {
                    if (spyoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Oh, I wasn't feeling so well, so I went home. But I wanted to tell you some-", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I see no need for this outburst, if you want to say something ju-", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I don't know what monkey means, but it sounds like a cute pet name!", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Do you think I'm cute?", new Vector2(10, 600), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 22)
                {
                    if (spyoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Ah, that sucks. Are you alright now?", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 2)
                    {
                        fieryTale.gameMoment = 25;
                    }
                    else if (spyoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "N-no, just forget it. And stop fucking stalking me!", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 23)
                {
                    if (spyoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Well yes. Ren, I need to tell you I lo-", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Hmpf fine. But there is still something I need to tell you, so please listen.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 24)
                {
                    if (spyoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "That's good to hear! Next time you can just tell me instead of ru-", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Look, I just want you to stop following me. I do not wish to hear your excu-", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 25)//finally, the confession
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "WILL YOU JUST LISTEN TO ME?! I'M TRYING TO TELL YOU THAT I LOVE YOU!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 26)
                {
                    if (fieryTale.goroPoints > 3)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "This seems to be a crucial moment. I remember my budding relationship with Goro.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "How should I react?", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "This seems to be a crucial moment. How should I react?", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 27)
                {
                    foreach (var button in simpchoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 28)
                {
                    if (simpoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Anna stands in front of me, desperately waiting for my answer.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (simpoption == 2)//star wars reference
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Oh. A surpise to be sure, but a welcome one.", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Ehm, this comes out of nowhere. You okay?", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 4)//meme
                    {
                        fieryTale.spriteBatch.Draw(cheem, new Rectangle(720, 385, 110, 75), Color.White);//640 x 609
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Silence wench, I no longer wish to be horny, I only wish to be happy!", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 29)
                {
                    if (simpoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I slowly reach for my glasses. Anna looks more desperate and confused.", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 2)//We for the longest time didnt think about the fact Anna is red, so don't ask us how blushing works okay.
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Anna is blushing hard.", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Well, I'm just glad I got that off my chest.", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 4)//bit harsh
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Anna starts bawling her eyes out and runs off.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 30)
                {
                    if (simpoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "R-Ren? What are you do-", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Anna, you alright?", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 3)//friendzoned. Sad girl hours
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I don't really feel the same way about you Anna, but we can stay friends. And who knows,", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "maybe one day... No promises though.", new Vector2(10, 600), Color.White);
                    }
                    else if (simpoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I will make you mine! I have one more trick up my sleeve, just you wait.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 31)
                {
                    if (simpoption == 1)//This persona is pretty cool
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I rip off my glasses and summon forth Thanatos from the sea of my soul.", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Y-yes, I'm fine. It's just, y-your reaction caught me off guard.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I-I'm glad I got this off my chest.", new Vector2(10, 600), Color.White);
                    }
                    else if (simpoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I was really hoping for something more, but I guess I can live with this.", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 4)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I watch her as she keeps on running.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 32)
                {
                    if (simpoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "R-Ren?! W-what is that?! P-please don't, I-I love you! [she's crying]", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Well, Anna, I think you are a great girl, truly, but right now, I'm ready to commit to anything.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                    }
                    else if (simpoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "It will be alright, we always have our friendship to build upon.", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 4)//little thanos reference
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Perhaps I treated her too harshly, oh well.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 33)
                {
                    if (simpoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Let us end it!", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I appreciate you telling me your feelings, even if only after my confrontation.", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Y-Yes, I suppose so. Thank you, Ren.", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 4)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I head off to class.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 34)
                {
                    if (simpoption == 1)//slight overreaction, killing someone who just confessed to you.
                    {
                        MediaPlayer.Stop();
                        fieryTale.attackedSomeone = true;
                        fieryTale.gameMoment = 0;
                        fieryTale.soundMoment = 0;
                    }
                    else if (simpoption == 2)//bitch trynna kill best girl Goro
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Y-you're not hesitant because you have someone else right?! I should have done something about your ro-", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "We'll talk more later, alright? I should get to class now.", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 4)
                    {
                        fieryTale.gameMoment = 42;
                    }
                }
                if (fieryTale.gameMoment == 35)
                {
                    if (simpoption == 2)//not yet at least (if doing secret ending)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "No, I am not currently seeing anyone else. And what was that you were about to say?", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 3)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I wave Anna goodbye as I head off to class. I can feel Anna watching me leave.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 36)
                {
                    if (simpoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "That's a relief! Ehm, I was about to say that... I should have done something about your...", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "ro-ro-routinized waking up late! Yes that!", new Vector2(10, 600), Color.White);
                    }
                    else if (simpoption == 3)
                    {
                        fieryTale.gameMoment = 42;
                    }
                }
                if (fieryTale.gameMoment == 37)
                {
                    if (simpoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "How do you know about that? I never said anything.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 38)
                {
                    if (simpoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Oh well I-I've seen you rushing to c-class from t-time to time.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 39)
                {
                    if (simpoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Hmm, if you say so. Speaking of class, I should get going now before I'm late.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I'll see you later, okay?", new Vector2(10, 600), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 40)
                {
                    if (simpoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Deal! Don't miss me too much! [she winks at me]", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 41)
                {
                    if (simpoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "As I walk off to class, I can feel Anna's penetrating gaze on me.", new Vector2(10, 580), Color.White);
                    }
                }
#endregion
                if (fieryTale.gameMoment == 42)
                {
                    fieryTale.spriteBatch.DrawString(Names, "In the hallway, on my way to class, I run into Sabel.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 43)
                {
                    fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Hey R-Ren, can I ask you something?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 44)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Sure. What is it?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 45)
                {
                    fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Well, I heard that Nishikinomiya-senpai confessed her love to someone today.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 46)
                {
                    fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "It's truly good she found someone, but I-I can't s-stand it. Can I tell you a secret?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 47)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Of course, I won't tell anyone. Thief's honour.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 48)//oh oh
                {
                    fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "W-well, I-I-I l-l-l-l-lo-love... I HAVE A HUGE CRUSH ON THE STUDENT COUNCIL PRESIDENT!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 49)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I look around the hallway to see if anyone could've heard him. We seem to be alone.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 50)
                {
                    fieryTale.spriteBatch.DrawString(Names, "When I look back to Sabel, his face is deep red.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 51)//Ren is always calm as a cucumber
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Hmm, I see. Quite the predicament. Why discuss this with me though?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 52)
                {
                    fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I thought, maybe you'd know who she confessed to? Or know someone who knows, ya know?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 53)//at least on the outside he's calm
                {
                    fieryTale.spriteBatch.DrawString(Names, "This really is quite the predicament. Fuck, what do I say?", new Vector2(10, 580), Color.White);
                }
                #region shooter convo
                if (fieryTale.gameMoment == 54)
                {
                    foreach (var button in shooterchoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 55)
                {
                    if (shooteroption == 1)//Ren just turned into Obi-wan
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Of course I know him, he's me!", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I'm not certain. However, I do have a hunch.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Honestly, no idea mate. Why'd you ask?", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 56)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "WHAT?! YOU?!", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Really, who do you think it is?", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Well I have a plan, but I need to know who did it.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 57)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Sabel starts rummaging through his bag.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 2)//kinda dick move from Ren
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I'm not certain, but my gut tells me it Yasutora.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I'm happy to help you look for this person.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 58)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I cannot believe it, you. Why does it have to be you? I need to take care of this.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "She cannot fall for anyone, but ME!", new Vector2(10, 600), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I see... yes that is possible. When does he usually arrive?", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Really? Good, I will share my plan with you.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 59)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "He has seemingly found what he's been looking for. He looks back to me,", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "rage burning in his eyes.", new Vector2(10, 610), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 640), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "He should be here in a couple minutes, I think at least.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)//pumped up kicks starts playing... I wanted to do that at first, but instead went for persona music
                    {
                        fieryTale.spriteBatch.DrawString(Names, "He rummages through is bag, until he... pulls out a gun?!", new Vector2(10, 580), Color.White);
                        if (fieryTale.songPlaying == false)
                        {
                            MediaPlayer.Stop();
                            MediaPlayer.Play(combat);
                            fieryTale.songPlaying = true;
                        }
                    }
                }
                if (fieryTale.gameMoment == 60)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "He takes.. A gun(?!) out of his bag and points it my way.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        if (fieryTale.songPlaying == false)
                        {
                            MediaPlayer.Stop();
                            MediaPlayer.Play(combat);
                            fieryTale.songPlaying = true;
                        }
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Damn, I'll just have to wait. Can you do me another favour, Ren?", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Take this, I have another one. Together we'll be unstoppable. What will it be, Ren?", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 61)
                {
                    if (shooteroption == 1)//Ren going into Joker mode
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I take a step back and focus all my attention on Sabel.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Sure, don't see why not. What is it?", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Fuck, what do I do?", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 62)
                {
                    if (shooteroption == 1)//understatement
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Calm down Sabel, there is no need for this. You are making a grave mistake.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "When Yasutora comes into class, just go outside for a bit. To the bathroom or something.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        foreach (var button in gunchoice)
                            button.Draw(gameTime);
                        fieryTale.choiceMoment = true;
                    }
                }
                if (fieryTale.gameMoment == 63)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I'm sorry Ren, but I cannot let this go.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Very well, I can do that.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I rip off my glasses and summon forth Kaguya from the sea of my soul.", new Vector2(10, 580), Color.White);
                        }
                        else if (gunoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I see, so that's the plan. I think I'll be able to help you just fine.", new Vector2(10, 580), Color.White);
                        }
                        else if (gunoption == 3)//stupid question honestly. But I think we've already established Ren is thick as pigshit
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Wait, is that a gun? Why do you have a gun?", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 64)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I stay calm, I've been in situations like this hundreds of times.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I go to class and wait for Yasutora to arrive. I then leave for the nearest bathroom.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "What the hell?!", new Vector2(10, 580), Color.White);
                        }
                        else if (gunoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Amazing! Together we will rule this school! No one will ever stand in m- our way again, Ren!", new Vector2(10, 580), Color.White);
                        }
                        else if (gunoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "To make sure no one else goes after the Student Council President, except me!", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 65)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I slowly creep my hand towards my glasses. Any fast movements might make him shoot.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Fuck, what have I gotten myself into this time? I hope he isn't going to do what I think he is.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 1)//While guns do physical damage in real life, gun damage is actually a different damage type in P5(R). Kaguya reflects physical but not gun. I don't care about that and made her able to reflect this gunshot.
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Before I can act, Sabel shoots at Kaguya, who reflects the shot.", new Vector2(10, 580), Color.White);
                        }
                        else if (gunoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "He hands me the gun and starts rummaging in his bag for the second one.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (gunoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I don't know about this Sabel. This is going too far.", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 66)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I see his finger start to flex around the trigger, his eyes are dull, lifeless.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I suddenly hear a gunshot go off, my fear realised. Then I hear some commotion outside.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 1)//Another persona, Girimehkala, can actually reflect both physical and gun, but he's less cool than Kaguya.
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "AH FUCK!", new Vector2(10, 580), Color.White);
                        }
                        else if (gunoption == 2)//Ren is able to move very quickly in the Metaverse, probably enhanced by his Persona.
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I use this opportunity to swiftly move in and hit Sabel with the stock of my gun.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (gunoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "hmm, I expected you to be more supportive. You said you would help me!", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 67)
                {
                    if (shooteroption == 1)//fast enough to dodge bullets even
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I'm completely focused. The bullet barely misses as I move my body out of the way.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "MR SINS LET ME GO! HE DESERVES THIS!!", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Sabel drops the gun and falls over, clutching his stomach.", new Vector2(10, 580), Color.White);
                        }
                        else if (gunoption == 2)//Ren is also very strong
                        {
                            fieryTale.spriteBatch.DrawString(Names, "He instantly buckles over and falls on the ground, out cold.", new Vector2(10, 580), Color.White);
                        }
                        else if (gunoption == 3)//oopsie
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "This is insane. You can just talk to Anna about this. These measures are too drastic!", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 68)
                {
                    if (shooteroption == 1)//cool persona. I say that about all of them, but it's true. Izanagi has big sword.
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I rip off my glasses and summon forth Izanagi from the sea of my soul.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.Draw(sins, new Rectangle(950, 240, 380, 480), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Mr Sins:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Calm down kid, you should be happy you missed him.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Fucking idiot.", new Vector2(10, 580), Color.White);
                        }
                        else if (gunoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Ah fuck, that will probably result in some brain damage. Oh well.", new Vector2(10, 580), Color.White);
                        }
                        else if (gunoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "What did you just call her?! Did you just call her by her first name?!", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 69)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Sabel jumps back, frightened, and nearly loses his balance. The perfect time to strike.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "NO! LET ME GO! SHE BELONGS TO MEEEEEEE-", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Mr Sins comes running over and I see my classmates standing around.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (gunoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Mr Sins comes running over and I quickly try to explain the situation.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (gunoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "She never allowed anyone to do that before...", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 70)
                {
                    if (shooteroption == 1)
                    {
                        foreach (var button in shotchoice)
                            button.Draw(gameTime);
                        fieryTale.choiceMoment = true;
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "They've left my range of hearing. I head back to class. The atmosphere is heavy.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Apparently, they've seen nearly everything.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (gunoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "To my surprise, he actually believes me.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (gunoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Don't jump to conclusions now.", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 71)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Cross slash!", new Vector2(10, 580), Color.White);

                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "My classmates fill me in on what happened. We all patiently wait for Mr Sins to return.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Sabel gets taken to the nurse's office and his gun gets confiscated.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (gunoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "He takes Sabel to the nurse's office and confiscates the guns.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (gunoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I can see the realization in Sabel's eyes. He starts to point the gun at me.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 72)
                {
                    if (shooteroption == 1)
                    {
                        if (shotoption == 1)
                        {
                            MediaPlayer.Stop();
                            fieryTale.attackedSomeone = true;
                            fieryTale.gameMoment = 0;
                            fieryTale.soundMoment = 0;
                        }
                        else if (shotoption == 2)//sword comes in handy. Get it... Handy... ah fuck it
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Izanagi cleanly cuts off Sabel's gunhand.", new Vector2(10, 580), Color.White);
                        }
                    }
                    else if (shooteroption == 2)//nobody even gives a shit about what happened
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Once Mr Sins gets back the rest of the day goes on like nothing happened.", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "My classmates start barraging me with question, all of which I leave unanswered.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (gunoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I go to class and deftly dodge my classmates questions about what happened.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (gunoption == 3)//again, he fast.
                        {
                            fieryTale.spriteBatch.DrawString(Names, "However, my time as a Phantom Thief prepared me for this. I move swiftly.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 73)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.Draw(sabel, new Rectangle(980, 270, 300, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Sabel:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "AH FUCK!", new Vector2(10, 580), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.gameMoment = 80;
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "After that, the lessons continue like nothing ever happened.", new Vector2(10, 580), Color.White);
                        }
                        else if (gunoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "The rest of the days lessons continue like nothing ever happened.", new Vector2(10, 580), Color.White);
                        }
                        else if (gunoption == 3)//ouch
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I disarm him and kick him in the balls hard enough he'll never be able to have children.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 74)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I quickly rush towards Sabel and knock him out.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 1)
                        {
                            fieryTale.gameMoment = 80;
                        }
                        else if (gunoption == 2)
                        {
                            fieryTale.gameMoment = 80;
                        }
                        else if (gunoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "As he collapses from the pain, Mr Sins comes running over and I try to explain.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 75)
                {
                    if (shooteroption == 1)//high on adrenaline
                    {
                        fieryTale.spriteBatch.DrawString(Names, "The next few moments are a blur. Mr Sins arrives, I do some explaining.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Surpisingly, he believes me. He takes Sabel to the nurse's office and confiscates the gun.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 76)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Sabel gets taken to the nurse's office, his gun gets confiscated.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I go to class and deftly dodge any questions thrown my way.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 77)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I notice a couple classmates that seemingly witnessed what happened.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "The rest of the days classes go on like nothing ever happened.", new Vector2(10, 580), Color.White);
                        }
                    }
                }
                if (fieryTale.gameMoment == 78)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "They are in awe and bombard me with questions I deftly avoid answering.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        if (gunoption == 3)
                        {
                            fieryTale.gameMoment = 80;
                        }
                    }
                }
                if (fieryTale.gameMoment == 79)
                {
                    if (shooteroption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Eventually we get to class and the day continues like nothing ever happened.", new Vector2(10, 580), Color.White);
                    }
                }
                #endregion
                if (fieryTale.gameMoment == 80)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Today's classes have ended and I'm back outside.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 81)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I'm making my way back to my dormroom when I hear a loud yelling.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 82)
                {
                    fieryTale.spriteBatch.DrawString(Names, "The yelling is coming closer. When I turn around I see Anna running towards me.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 83)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "REN! WAIT UP!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 84)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I stop walking and wait for her to close the gap.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 85)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "REN! I am so glad I caught up with you! I heard what happened with Sabel.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 86)
                {
                    if (shooteroption == 1)//maiming someone is cool
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "He shot at you! You cut off his hand?! You're so cool! You're my hero!", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                    }
                    else if (shooteroption == 2)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Seems you left at just the right time. You must be so glad!", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                    }
                    else if (shooteroption == 3)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "You stopped him! You're a hero! My hero!", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 87)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I'm just so happy you're alright. I-I don't know what I would've done if something happened to you...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 88)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I appreciate your concern, but I don't really want to talk ab-.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 89)
                {
                    fieryTale.spriteBatch.DrawString(Names, "She moves in awfully close to me.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 90)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I'm sorry, Ren. I was just so worried about you.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 91)//Ren goes into panic mode
                {
                    fieryTale.spriteBatch.DrawString(Names, "She seems to be leaning in for a kiss. Fuck, what do I do.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 92)
                {
                    foreach (var button in kisschoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 93)
                {
                    if (kissoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I panic and rip off my glasses, summoning forth Thanatos from the sea of my soul.", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "...Fuck it.", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 3)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I swiftly dodge out of the way before her lips touch mine.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (kissoption == 4)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "As she moves in close for a kiss, I dodge her face and hug her instead.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 94)
                {
                    if (kissoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Anna jumps backwards in a panic.", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I wrap my right arm around her waist and pull her in close.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (kissoption == 3)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "She loses her balance and falls face first on the floor.", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Anna, I think it better if we stay friends. I'd love to keep hanging out though, as friends.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 95)
                {
                    if (kissoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "R-Ren?! What the fuck is that?!", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "She wraps her arms around my neck as we start to passionately make out.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (kissoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Ren! Why'd you move out the way?! That hurts.", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "[she's crying] O-Okay. Yeah friends, t-that's fine... Sorry about this.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 96)
                {
                    if (kissoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I hesitate, will I really attack someone for this?... yes.", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I put my left hand on her ass and squeeze. She lets out a small moan.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (kissoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I don't want this. You should've asked instead of just going in like that.", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "It's okay, Anna. Don't worry about it. Maybe someday we can be something more,", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "but for now, let's just be friends.", new Vector2(10, 600), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 97)
                {
                    if (kissoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Let us end it!", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "My hands start exploring her body, and hers mine.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (kissoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "W-Well I thought after a stressful situation like today, you could use some relief.", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 4)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "She wipes away her tears and gives her best attempt at a smile.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 98)
                {
                    if (kissoption == 1)
                    {
                        MediaPlayer.Stop();
                        fieryTale.attackedSomeone = true;
                        fieryTale.gameMoment = 0;
                        fieryTale.soundMoment = 0;
                    }
                    else if (kissoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Wait, shit, we're still in public. I pull back.", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Look, I'm just done with you at this point. You don't get to decide that shit for me.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                    }
                    else if (kissoption == 4)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "OKAY!", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 99)
                {
                    if (kissoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "W-We should continue this somewhere private.", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I'll take my leave now. Don't follow me.", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 4)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "She's clearly trying, and failing, to hide her pain.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 100)
                {
                    if (kissoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "M-My dorm should do. M-My roommate is always home very late.", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 3)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I get the feeling she isn't going to leave me alone.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (kissoption == 4)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "She walks off without another word.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 101)
                {
                    if (kissoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "We head for her dormroom. The moment we close the door behind us, we continue.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (kissoption == 3)
                    {
                        if (fieryTale.goroPoints > 4)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I should talk with Goro about this. He'll protect me.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I should talk with Goro about this. I'm sure he'll help.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        
                    }
                    else if (kissoption == 4)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Somehow, I feel this isn't over yet however.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 102)
                {
                    if (kissoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "We explore every centimeter of eachothers bodies.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (kissoption == 3)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "As I walk off, I can feel her watching me.", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 4)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I return to my dormroom.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 103)
                {
                    if (kissoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I, sadly, don't stay the night. I leave before her roommate returns.", new Vector2(10, 580), Color.White);
                    }
                    else if (kissoption == 3)
                    {
                        fieryTale.gameMoment = 104;
                    }
                    else if (kissoption == 4)
                    {
                        fieryTale.gameMoment = 104;
                    }
                }
                if (fieryTale.gameMoment == 104)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I've arrived back at my dormroom. What an eventful day.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 105)
                {
                    if (kissoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I quickly greet Goro and clumsily dodge his questions.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "As I walk off, I can feel her watching me.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 106)
                {
                    if (kissoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I'm exhausted from the day and excuse myself to my room.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "As I walk off, I can feel her watching me.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 107)
                {
                    if (kissoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I lay in bed wishing Anna was with me. I fall asleep.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "As I walk off, I can feel her watching me.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 108)
                {
                    if (kissoption == 2)
                    {
                        foreach (var button in nextday)
                            button.Draw(gameTime);
                        fieryTale.choiceMoment = true;
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "As I walk off, I can feel her watching me.", new Vector2(10, 580), Color.White);
                    }
                }

                fieryTale.spriteBatch.End();
            }
        }
    }
}

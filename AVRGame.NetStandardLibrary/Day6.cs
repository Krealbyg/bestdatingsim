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
    public class Day6 : DrawableGameComponent
    {
        private FieryTale fieryTale;

        private int dateoption;//when choosing which date to do
        private int liboption;//when choosing convo in library
        private int fightoption;//when choosing what to do during lib commotion
        private int maidoption;//when choosing how to react to goro

        //lists
        private List<Button> datechoice;
        private List<Button> libchoice;
        private List<Button> fightchoice;
        private List<Button> maidchoice;

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
        private Texture2D kase;
        private Texture2D hell;
        private Texture2D classroom;
        private Texture2D sins;
        private Texture2D mrcare;
        private Texture2D bitch;
        private Texture2D hallway;
        private Texture2D principal;
        private Texture2D library;
        private Texture2D cafe;

        //Goro expressions
        private Texture2D goroneutral;
        private Texture2D gorosmiling;
        private Texture2D goroshocked;
        private Texture2D gorococky;
        private Texture2D goromaid;
        private Texture2D goromaid2;
        private Texture2D gorowink;

        //sounds
        private SoundEffect ariadne;
        private SoundEffect guidance;

        public Day6(FieryTale fieryTale) : base(fieryTale)
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //fuck
            rennormal = fieryTale.Content.Load<Texture2D>("RenNormal");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            dorm = fieryTale.Content.Load<Texture2D>("Dorm");
            anna = fieryTale.Content.Load<Texture2D>("Anna");
            yasutora = fieryTale.Content.Load<Texture2D>("Yasutora");
            shiki = fieryTale.Content.Load<Texture2D>("Shiki");
            sabel = fieryTale.Content.Load<Texture2D>("Sabel");
            kase = fieryTale.Content.Load<Texture2D>("Kase");
            sins = fieryTale.Content.Load<Texture2D>("Sinsleft");
            goroneutral = fieryTale.Content.Load<Texture2D>("GoroNeutral");
            gorosmiling = fieryTale.Content.Load<Texture2D>("GoroSmiling");
            goroshocked = fieryTale.Content.Load<Texture2D>("GoroShocked");
            gorococky = fieryTale.Content.Load<Texture2D>("GoroCocky");
            goromaid = fieryTale.Content.Load<Texture2D>("Goromaid");
            goromaid2 = fieryTale.Content.Load<Texture2D>("Goromaid2");
            gorowink = fieryTale.Content.Load<Texture2D>("GoroWink");
            classroom = fieryTale.Content.Load<Texture2D>("Classroom");
            mrcare = fieryTale.Content.Load<Texture2D>("MrCare");
            bitch = fieryTale.Content.Load<Texture2D>("BITCH");
            hell = fieryTale.Content.Load<Texture2D>("Hell");
            hallway = fieryTale.Content.Load<Texture2D>("Hallway");
            principal = fieryTale.Content.Load<Texture2D>("Principal");
            library = fieryTale.Content.Load<Texture2D>("Library");
            cafe = fieryTale.Content.Load<Texture2D>("Cafe");
            ariadne = fieryTale.Content.Load<SoundEffect>("Ariadne");
            guidance = fieryTale.Content.Load<SoundEffect>("Guidance");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");

            #region buttons

            //main choice decides date
            var datechoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 125),
                ButtonText = "The Library"
            };
            var datechoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 250),
                ButtonText = "The cafe"
            };
            var datechoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 375),
                ButtonText = "You can decide"
            };

            //library
            var libchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 125),
                ButtonText = "Books"
            };
            var libchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 250),
                ButtonText = "Jobs"
            };
            var libchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 375),
                ButtonText = "..."
            };

            //lib commotion
            var fightchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 125),
                ButtonText = "Interfere"
            };
            var fightchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 250),
                ButtonText = "Persona!"
            };
            var fightchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 375),
                ButtonText = "Do nothing"
            };

            //maid choice
            var maidchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 125),
                ButtonText = "You look great"
            };
            var maidchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 250),
                ButtonText = "You look hideous"
            };
            var maidchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 375),
                ButtonText = "..."
            };

            #endregion

            #region button choice event creation

            datechoice1.Click += Datechoice1_Click;
            datechoice2.Click += Datechoice2_Click;
            datechoice3.Click += Datechoice3_Click;

            libchoice1.Click += Libchoice1_Click;
            libchoice2.Click += Libchoice2_Click;
            libchoice3.Click += Libchoice3_Click;

            fightchoice1.Click += Fightchoice1_Click;
            fightchoice2.Click += Fightchoice2_Click;
            fightchoice3.Click += Fightchoice3_Click;

            maidchoice1.Click += Maidchoice1_Click;
            maidchoice2.Click += Maidchoice2_Click;
            maidchoice3.Click += Maidchoice3_Click;

            #endregion

            #region filling lists

            datechoice = new List<Button>
            {
                datechoice1,
                datechoice2,
                datechoice3
            };

            libchoice = new List<Button>
            {
                libchoice1,
                libchoice2,
                libchoice3
            };

            fightchoice = new List<Button>
            {
                fightchoice1,
                fightchoice2,
                fightchoice3
            };

            maidchoice = new List<Button>
            {
                maidchoice1,
                maidchoice2,
                maidchoice3
            };
            #endregion

            base.LoadContent();
        }

        private void Maidchoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 41 && dateoption == 2)
            {
                maidoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Maidchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 41 && dateoption == 2)
            {
                maidoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Maidchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 41 && dateoption == 2)
            {
                maidoption = 1;
                fieryTale.goroPoints++;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Fightchoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 47 && dateoption == 1)
            {
                fightoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Fightchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 47 && dateoption == 1)
            {
                fightoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Fightchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 47 && dateoption == 1)
            {
                fightoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Libchoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 30 && dateoption == 1)
            {
                liboption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Libchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 30 && dateoption == 1)
            {
                liboption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Libchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 30 && dateoption == 1)
            {
                liboption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Datechoice3_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 22)
            {
                dateoption = 3;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Datechoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 22)
            {
                dateoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Datechoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 22)
            {
                dateoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 6 && fieryTale.attackedSomeone == false)
            {
                //sounds
                if (fieryTale.gameMoment == 51 && fieryTale.soundMoment == 0 && dateoption == 1 && fightoption == 2)
                {
                    ariadne.Play();
                    fieryTale.soundMoment++;
                }
                if (fieryTale.gameMoment == 55 && fieryTale.soundMoment == 1 && dateoption == 1 && fightoption == 2)
                {
                    guidance.Play();
                    fieryTale.soundMoment++;
                }
                
                foreach (var button in datechoice)
                    button.Update(gameTime);
                foreach (var button in libchoice)
                    button.Update(gameTime);
                foreach (var button in fightchoice)
                    button.Update(gameTime);
                foreach (var button in maidchoice)
                    button.Update(gameTime);

                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 6 && fieryTale.attackedSomeone == false)
            {
                fieryTale.spriteBatch.Begin();

                //backgrounds
                if (fieryTale.gameMoment <= 25 || fieryTale.gameMoment > 75)
                {
                    fieryTale.spriteBatch.Draw(dorm, new Rectangle(0, 0, 1280, 760), Color.White);
                }
                if (fieryTale.gameMoment > 25 && fieryTale.gameMoment <= 75 && dateoption == 1)
                {
                    fieryTale.spriteBatch.Draw(library, new Rectangle(0, 0, 1280, 720), Color.White);
                }
                if (fieryTale.gameMoment > 25 && fieryTale.gameMoment <= 75 && dateoption == 2)
                {
                    fieryTale.spriteBatch.Draw(cafe, new Rectangle(0, 0, 1280, 720), Color.White);
                }


                    //textbox
                    fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);

                //scenes
                if (fieryTale.gameMoment == 0)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I wake up without a care in the world.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 1)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Man, I fucking love sleeping in without stress.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 2)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Wonder what Anna has planned for today...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 3)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Oh well, I'll see I guess. First, time for breakfast.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 4)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I enter the living room, it seems Goro is already gone.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 5)
                {
                    fieryTale.spriteBatch.DrawString(Names, "As I finish making breakfast I notice a note on the table", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 6)
                {
                    fieryTale.spriteBatch.DrawString(Names, "'Ren, I'll be out late today, I've got a job. ~Goro'", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 7)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Job? Well I suppose someone as to work at those shops and such...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 8)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I haven't actually had to pay for anything yet though, I just gave them my student card.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 9)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Am I in debt now? Maybe work is more like a punishment and not for income...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 10)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Oh well, that's a possible problem for future me.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 11)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Shame Goro's left already, now I need to fill my time on my own.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 12)
                {
                    if (fieryTale.goroPoints > 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I spend my time pining over Goro... also with some light reading.", new Vector2(10, 580), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I spend my time reading and doing some housework.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 13)
                {
                    fieryTale.spriteBatch.DrawString(Names, "After what feels like ages, I hear the doorbell go off.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 14)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "That must be Anna, right on time. [I open the door]", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 15)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Heyyy Ren, how have you been?", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 16)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I hope you didn't miss me too much Nya~!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 17)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I've been alright. Didn't really miss you, it's only been a day.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 18)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Oh Ren, I love your jokes. Of course you missed me, you silly.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 19)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Sure, whatever you want.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 20)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Alright enough about you and your jokes, let's decide what to do today!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 21)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "There are many places we can visit, like a cafe or the library, what do you think?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 22)
                {
                    foreach (var button in datechoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 23)
                {
                    if (dateoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Let's go to the library.", new Vector2(10, 580), Color.White);
                    }
                    if (dateoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Let's go to a cafe.", new Vector2(10, 580), Color.White);
                    }
                    if (dateoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "You can decide.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 24)
                {
                    if (dateoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Great idea! Come on, I'll take you there!", new Vector2(10, 580), Color.White);
                    }
                    if (dateoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Good idea! There's this little cafe I really enjoy, I'll take you there!", new Vector2(10, 580), Color.White);
                    }
                    if (dateoption == 3)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "R-really?! well, uhm... there this cafe I really like, I'll take you there!", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 25)
                {
                    if (dateoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Anna drags me by my hand to the library.", new Vector2(10, 580), Color.White);
                    }
                    if (dateoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Anna drags me by my hand to a nice little cafe.", new Vector2(10, 580), Color.White);
                    }
                    if (dateoption == 3)
                    {
                        dateoption = 2;
                    }
                }
                #region library date
                if (dateoption == 1)
                {
                    if (fieryTale.gameMoment == 26)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "We eventually arrive and start looking for a place to sit.", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 27)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Oh, I see a free spot over there! Should we sit there?", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 28)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I don't really care as long as we can sit down.", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 29)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "It's settled then. So, anything you want to talk about?", new Vector2(10, 580), Color.White);
                    }
                    #region Anna convo in lib
                    if (fieryTale.gameMoment == 30)
                    {
                        foreach (var button in libchoice)
                            button.Draw(gameTime);
                        fieryTale.choiceMoment = true;
                    }
                    if (fieryTale.gameMoment == 31)
                    {
                        if (liboption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "What kind of books do you like? No better place to ask.", new Vector2(10, 580), Color.White);
                        }
                        else if (liboption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I've been wondering about something, maybe you could help?", new Vector2(10, 580), Color.White);
                        }
                        else if (liboption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 32)
                    {
                        if (liboption == 1)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Well, I like all sorts of books, but my favourite are romance novels.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                        }
                        else if (liboption == 2)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Of course I can help, silly~. What is it? Anything for y- ask away! [she's blushing]", new Vector2(10, 580), Color.White);
                        }
                        else if (liboption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 33)
                    {
                        if (liboption == 1)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I always imagine myself as the girl that gets the guy in the end. Sadly that hasn't happened to me yet...", new Vector2(10, 580), Color.White);
                        }
                        else if (liboption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Well, my roommate left a note this morning about having to go to work, so I was wondering...", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                        }
                        else if (liboption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 34)
                    {
                        if (liboption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I'm sure your day will come, Anna.", new Vector2(10, 580), Color.White);
                        }
                        else if (liboption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "How does that work? The whole jobs in hell thing?", new Vector2(10, 580), Color.White);
                        }
                        else if (liboption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Ren, why are you so silent? Something wrong?", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 35)
                    {
                        if (liboption == 1)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I hope sooner than later [She's blushing and looks away]", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                        }
                        else if (liboption == 2)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Oh it's not very complicated. In Hell people must make up for their sins in some way or another.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                        }
                        else if (liboption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 36)
                    {
                        if (liboption == 1)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "A-anyway, what are your favourite books R-Ren?", new Vector2(10, 580), Color.White);
                        }
                        else if (liboption == 2)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "One way is through labor. It isn't too bad, you get to decide where to work.", new Vector2(10, 580), Color.White);
                        }
                        else if (liboption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Y-YOU AREN'T THINKING OF OTHER GIRLS R-RIGHT?!", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 37)
                    {
                        if (liboption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "What's that supposed to mean? Anyway, back on topic, my favourite genres are Sci-Fi and fantasy.", new Vector2(10, 580), Color.White);
                        }
                        else if (liboption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Hmmm, okay. Why don't I have anything like a job then?", new Vector2(10, 580), Color.White);
                        }
                        else if (liboption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 38)
                    {
                        if (liboption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I suddenly hear yelling from somewhere close by.", new Vector2(10, 580), Color.White);
                        }
                        else if (liboption == 2)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I don't know, maybe you got lucky?", new Vector2(10, 580), Color.White);
                        }
                        else if (liboption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "P-please Ren, say something... I miss your voi- [she suddenly stops and blushes]", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 39)
                    {
                        if (liboption == 1)
                        {
                            fieryTale.gameMoment = 41;
                        }
                        else if (liboption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Hmmm, sure, let's go with that.", new Vector2(10, 580), Color.White);
                        }
                        else if (liboption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I suddenly hear yelling from somewhere close by.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 40)
                    {
                        if (liboption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I suddenly hear yelling from somewhere close by.", new Vector2(10, 580), Color.White);
                        }
                        else if (liboption == 3)
                        {
                            fieryTale.gameMoment = 41;
                        }
                    }
                    #endregion
                    if (fieryTale.gameMoment == 41)
                    {
                        fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Yasutora:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Why are you working so slow?!", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 42)
                    {
                        fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Kase:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I-I have other work to d-do as well, I'm s-sorry.", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 43)
                    {
                        fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Yasutora:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "What do you mean other work? Doing my homework is your top priority! Get back to it!", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 44)
                    {
                        fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Kase:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "[She's crying] Y-y-yes, I-I-I'm s-sorry. I w-will get o-on it.", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 45)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Hey Ren, did you hear all that? Should we do something?", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                    }
                    if (fieryTale.gameMoment == 46)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "B-but I don't want you to get hurt... Ehm, choice is y-yours Ren!", new Vector2(10, 580), Color.White);
                    }
                    #region fight
                    if (fieryTale.gameMoment == 47)
                    {
                        foreach (var button in fightchoice)
                            button.Draw(gameTime);
                        fieryTale.choiceMoment = true;
                    }
                    if (fieryTale.gameMoment == 48)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I guess I can try and do something.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "As I walk up to the commotion, I see Kase in tears, quickly writing stuff down.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I don't know, should we? We were having a pleasant conversation right?", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 49)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "As I walk up to the commotion, Anna suddenly grabs my hand, but lets go just as quick.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (fightoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Yasutora is just standing there smugly, looking at Kase with a menacing stare.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Well, yes. I love chatting with you! B-but I can't just stand by and do nothing.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 50)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "When I look back she's heavily blushing. I keep moving.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I feel an intense rage building up inside of me.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Then do something, you're the student council president after all.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 51)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Hey Yasutora!", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I rip off my mask (glasses) and summon forth Ariadne from the sea of my soul.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "You know what Ren, you're right! Thank you.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 52)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Yasutora:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "What do you want punk?", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...Hot... [I hear her faint]", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "She squares her shoulders and walks over to the 2 students.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 53)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "What I want, is for you to stop bullying this petite girl. She doesn't deserve that.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Yasutora:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Holy fuck! Please have mercy! I'm sorry, I'm sorry, I'll do my own work from now!", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "HEY, you there! Stop harassing that girl right now and make your own work!", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 54)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Yasutora:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "And what if I don't?", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Kase's sobbing turns into full-blown wailing. She tries to speak, but I can't understand it.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Yasutora:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "What are you going to do about it? You're barely a shrimp compared to me.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 55)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I'll be forced to give you some... educational guidance.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "It's educational guidance.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Yasutora towers over Anna. She takes a step back and looks my way.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 56)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I reach for my glasses, but before I could summon forth Ariadne I feel a hand on my neck.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 2)
                        {
                            MediaPlayer.Stop();
                            fieryTale.attackedSomeone = true;
                            fieryTale.gameMoment = 0;
                            fieryTale.soundMoment = 0;
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I see a faint glint of something in her eyes...", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 57)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(mrcare, new Rectangle(1000, 470, 350, 250), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Mr Care:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Calm down kiddos, no need for this ruckus. Let us talk this out peacefully, like real men.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "In one fluid motion, Anna twists Yasutora's arm behind him and forces him on the ground.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 58)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Yasutora and I nod our heads.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "She keeps twisting his arm until he surrenders.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 59)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(mrcare, new Rectangle(1000, 470, 350, 250), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Mr Care:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Good, let us talk in a more secluded part of the library.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Yasutora:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "OW!! I YIELD! I YIELD GODDAMNIT!", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 60)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Mr Care picks us both up without effort and moves us to a different spot.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Good, now leave this poor girl alone and do your own work, lazy fuck!", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 61)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(mrcare, new Rectangle(1000, 470, 350, 250), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Mr Care:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Now, what seems to be the problem, gentlemen?", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Yasutora:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Alright, alright. I'll go to my dorm now, please let go of me.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 62)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(yasutora, new Rectangle(980, 295, 300, 425), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Yasutora:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I was just minding my business when this brat appeared and started yelling.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Very well, now LEAVE!", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 63)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "He was bullying Kase and I stood up for her. This dimwit can't even make his own work apparently.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Yasutora quickly runs away.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 64)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(mrcare, new Rectangle(1000, 470, 350, 250), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Mr Care:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Now now, there's no need to be hurtful kiddos. Let us settle this peacefully.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Kase:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "T-th-thank you student council president-sama! You d-didn't have to do this.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 65)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(mrcare, new Rectangle(1000, 470, 350, 250), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Mr Care:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Ren, how about you go back to your friend and hang out with her.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Nonsense, I am glad to help. Now get some rest okay? You're free now.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 66)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(mrcare, new Rectangle(1000, 470, 350, 250), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Mr Care:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Yasutora, you will stop bullying Kase and do your own work, understand?", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Kase:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "[she's sobbing] T-th-thank you s-so much!!", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 67)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Mr Care looks both of us in the eyes, which sends a chill through my spine.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Kase runs up to Anna and hugs er tightly.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 68)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Yasutora and I both nod our head again. Mr Care carries us back.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "GYA~! CANT. BREATHE.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 69)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "REN!! You did it! You helped Kase out!", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(kase, new Rectangle(960, 220, 380, 680), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Kase:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Oh I-I'm sorry I didn't mean to hurt you. [she let's go of Anna]", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 70)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "She'd thank you herself, but she was too flustered and left for her dorm.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Kase seems a bit flustered. She waves us goodbye and leaves.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 71)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "What you did back there was, like, totally amazing! You're a hero!", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Oh t-that reminds me, I also have s-s-something to do.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 610), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 72)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I-I just remember I need t-to be somewhere, see you around!", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I-I'm sorry Ren, see you around!", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 73)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Anna is blushing deeply. She quickly runs off.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Anna is blushing deeply. She quickly runs off.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 74)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Wait! I didn't even do anything! [Anna's already gone]", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I stand there baffled for a moment, then I return to my dormroom.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 75)
                    {
                        if (fightoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I decide to head back to my dormroom, wondering why Anna thanked me and not Mr. Care.", new Vector2(10, 580), Color.White);
                        }
                        else if (fightoption == 3)
                        {
                            fieryTale.gameMoment = 76;
                        }
                    }
                    #endregion
                }
                #endregion
                #region maid cafe date
                if (dateoption == 2)
                {
                    if (fieryTale.gameMoment == 26)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "We arrive at a maid cafe, where we wait to be seated.", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 27)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I'm so happy I get to take you here, Ren!", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 28)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Yeah I noticed, you haven't let go of my hand the entire time.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 610), Color.White);
                    }
                    if (fieryTale.gameMoment == 29)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "It's fun seeing you happy like this though.", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 30)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I wonder, how would you react if I were to wear a maid outfit?", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 31)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Why don't you try it and see for yourself?", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 32)
                    {
                        if (fieryTale.goroPoints > 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "There is someone else I wouldn't mind seeing in a maid outfit...", new Vector2(10, 580), Color.White);
                        }
                        else
                        {
                            fieryTale.gameMoment = 33;
                        }
                    }
                    if (fieryTale.gameMoment == 33)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Haha, I love your jokes, but if you're serious... I might consider it.", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 34)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "One of the maids walks over to us.", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 35)
                    {
                        fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);//455 x 422
                        fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Hello and welcome to our cafe. Table for tw-", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 36)
                    {
                        fieryTale.spriteBatch.Draw(goromaid2, new Rectangle(900, 350, 380, 370), Color.White);//475 x 464
                        fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "R-Ren?!", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 37)
                    {
                        if (fieryTale.goroPoints > 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "It seems the universe read my mind...", new Vector2(10, 580), Color.White);
                        }
                        else
                        {
                            fieryTale.gameMoment = 38;
                        }
                    }
                    if (fieryTale.gameMoment == 38)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Goro, this is where you work?", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 39)
                    {
                        fieryTale.spriteBatch.Draw(goromaid2, new Rectangle(900, 350, 380, 370), Color.White);//475 x 464
                        fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Yeah... Why are you here?", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 40)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "It's because I took him here.", new Vector2(10, 580), Color.White);
                    }
                    if (fieryTale.gameMoment == 41)
                    {
                        foreach (var button in maidchoice)
                            button.Draw(gameTime);
                        fieryTale.choiceMoment = true;
                    }
                    if (fieryTale.gameMoment == 42)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "You, ehm... look pretty cute in that outfit...", new Vector2(10, 580), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Looking good, Goro.", new Vector2(10, 580), Color.White);
                            }
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Goro, mate, you look hideous in that. No hard feelings.", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 43)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(goromaid2, new Rectangle(900, 350, 380, 370), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "W-what? You mean that? Uhm... thanks... [Goro smiles a little]", new Vector2(10, 580), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.Draw(goromaid2, new Rectangle(900, 350, 380, 370), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "You think so? Thanks I guess...", new Vector2(10, 580), Color.White);
                            }
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(goromaid2, new Rectangle(900, 350, 380, 370), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Well, it's my work outfit, so don't have much choice in the matter.", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(goromaid2, new Rectangle(900, 350, 380, 370), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Ren, you alright? Your staring is weirding me out.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 44)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Y-yeah it really suits you.", new Vector2(10, 580), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Don't mention it.", new Vector2(10, 580), Color.White);
                            }
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Why are you working here anyway, got no dignity left at all?", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 45)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(goromaid2, new Rectangle(900, 350, 380, 370), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Well, maybe I could... wear this at home as well.", new Vector2(10, 580), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Hmmm, you're quite accepting, I thought you'd try and make some funny remark.", new Vector2(10, 580), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 580), Color.White);
                            }
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "It isn't so bad, especially compared to other jobs. Now, table for two?", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "What, cat's got your tongue? Like my outfit that much?", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 46)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "...Can't say I haven't fantasized about that.", new Vector2(10, 580), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Anyway, table for two?", new Vector2(10, 580), Color.White);
                            }
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Yes, please!", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 47)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "I wouldn't mind seeing you in this either, I do believe I have a spare outfit...", new Vector2(10, 580), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Oh, right. Yes, please.", new Vector2(10, 580), Color.White);
                            }
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Goro guides Anna and I to a table.", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Or maybe you're judging me?", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 48)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "You've certainly peaked my inter-", new Vector2(10, 580), Color.White);
                            }
                            else
                            {
                                fieryTale.gameMoment = 51;
                            }
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "You two want something to drink?", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                    }

                    if (fieryTale.gameMoment == 49)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Hey! Aren't you forgetting someone?! You came here with ME, Ren!", new Vector2(10, 580), Color.White);
                            }
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "We'll take some Oo-hot Tea!", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "It's of no matter to me either way. Let me take you to your table.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 50)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Ah right, sorry... Table for two please.", new Vector2(10, 580), Color.White);
                            }
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Very well, coming right up! [He leaves]", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Goro guides Anna and I to a table.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 51)
                    {
                        if (maidoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Goro guides Anna and I to a table.", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Why'd you insult your friend like that, Ren?", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "What will you be having?", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 52)
                    {
                        if (maidoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "What would you like to order?", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I didn't really mean it, it was just cheeky banter. He can handle it.", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "We'll have the relaxing coffee.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 53)
                    {
                        if (maidoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Well have that which you recommend most.", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Oh, I-I see. You two close?", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "We'll have the relaxing coffee.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 54)
                    {
                        if (maidoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I see... I know just the thing. [He leaves]", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "We're roommates now, but we've known eachother for a while. Why, you jealous?", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Very well, coming right up! [He leaves]", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 55)
                    {
                        if (maidoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, " Hpmf. You two seem... awfully close", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "W-what?! N-n-no, I was ju-", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Why didn't you say anything to him?", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 56)
                    {
                        if (maidoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "We've known eachother for a long time, it's only natural. Anything wrong?", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I was just kidding, don't stress about it.", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 57)
                    {
                        if (maidoption == 1)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "Well I guess I felt a bit lef- Actually, forget it. Let's just enjoy our time!", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "O-oh I see... [she's blushing hard]", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "R-Ren, why are you gazing into my eyes like that?", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 58)
                    {
                        if (maidoption == 1)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Goro returns with our order.", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Goro returns with our order.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "...", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 59)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Here you go, Ren, your Love Pancakes~.", new Vector2(10, 580), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Here you go, two Sincere Omelettes", new Vector2(10, 580), Color.White);
                            }
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Anna and I enjoy our Tea while having a nice conversation.", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "R-Ren? Oh my, i-is it getting hotter in here? You gazing into my eyes is s-so se-", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 610), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 60)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(gorowink, new Rectangle(204, 44, 872, 632), Color.White);//872 x 632
                            }
                            else
                            {
                                fieryTale.spriteBatch.DrawString(Names, "Anna and I eat our omelettes while having a nice conversation.", new Vector2(10, 580), Color.White);
                            }
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I-I've got to go now, sorry. Bye~!", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                            fieryTale.spriteBatch.DrawString(Talking, "I-I'm sorry, I just remembered I've got something to do. See ya!", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 61)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "And for the girl, a Sincere Omelette. Enjoy!", new Vector2(10, 580), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "That was a good recommendation from Maid-kun!", new Vector2(10, 580), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 610), Color.White);
                            }
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Just like that, she runs off.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "She quickly runs off, bright red like a tomato.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 62)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.DrawString(Names, "Anna and I eat our food while conversing. She seems troubled, mad?", new Vector2(10, 580), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "B-but I've gotta go now, s-so see you later!", new Vector2(10, 580), Color.White);
                            }
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I say bye to Goro and go back to our dormroom.", new Vector2(10, 580), Color.White);
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "Goro brings me the coffee, he looks confused at the empty seat.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 63)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.DrawString(Names, "Afterwards she quickly excuses herself and runs off.", new Vector2(10, 580), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.DrawString(Names, "Anna quickly runs off, she seemed a bit troubled.", new Vector2(10, 580), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                            }
                        }
                        else if (maidoption == 2)
                        {
                            fieryTale.gameMoment = 76;
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "I shrug it off and drink both the cups of coffee.", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 64)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.DrawString(Names, "I decide to talk to Goro before going home.", new Vector2(10, 580), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.DrawString(Names, "I strike up a convo with Goro before heading back home.", new Vector2(10, 580), Color.White);
                            }
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "After finishing my drinks, I leave for my dormroom, waving to Goro on the way out.", new Vector2(10, 580), Color.White);
                        }
                    }
                    if (fieryTale.gameMoment == 65)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Did you enjoy the pancakes? I made them just for you, with love~.", new Vector2(10, 580), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "How was the food?", new Vector2(10, 580), Color.White);
                            }
                        }
                        else if (maidoption == 3)
                        {
                            fieryTale.gameMoment = 76;
                        }
                    }
                    if (fieryTale.gameMoment == 66)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Don't you have a history with pancakes?", new Vector2(10, 580), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Pretty good, maybe I'll come by again.", new Vector2(10, 580), Color.White);
                            }
                        }
                    }
                    if (fieryTale.gameMoment == 67)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(goromaid2, new Rectangle(900, 350, 380, 370), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "I guess, but in a weird way, that is the reason we are who we are today.", new Vector2(10, 580), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Glad to hear it! I'll see you back home after my shift!", new Vector2(10, 580), Color.White);
                            }
                        }
                    }
                    if (fieryTale.gameMoment == 68)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(goromaid2, new Rectangle(900, 350, 380, 370), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "If I hadn't made that slip-up, you might not have figured out I was the traitor and then...", new Vector2(10, 580), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Yeah, see you later.", new Vector2(10, 580), Color.White);
                            }
                        }
                    }
                    if (fieryTale.gameMoment == 69)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "You would've killed the real me that day. I guess you're right, if that had happened...", new Vector2(10, 580), Color.White);
                            }
                            else
                            {
                                fieryTale.spriteBatch.DrawString(Names, "I go back to our dormroom.", new Vector2(10, 580), Color.White);
                            }
                        }
                    }
                    if (fieryTale.gameMoment == 70)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(goromaid2, new Rectangle(900, 350, 380, 370), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "We wouldn't have gotten the chance to reconcile, to become closer.", new Vector2(10, 580), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                            }
                            else
                            {
                                fieryTale.gameMoment = 76;
                            }
                        }
                    }
                    if (fieryTale.gameMoment == 71)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(goromaid2, new Rectangle(900, 350, 380, 370), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Honestly, right now, I don't want to think about a world like that.", new Vector2(10, 580), Color.White);
                            }
                        }
                    }
                    if (fieryTale.gameMoment == 72)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "You're right, neither do I. I'm happy with what we've gotten.", new Vector2(10, 580), Color.White);
                            }
                        }
                    }
                    if (fieryTale.gameMoment == 73)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.Draw(goromaid, new Rectangle(900, 370, 380, 350), Color.White);
                                fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                                fieryTale.spriteBatch.DrawString(Talking, "Yes, so am I. I've got to get back to work now, I'll see you at home!", new Vector2(10, 580), Color.White);
                            }
                        }
                    }
                    if (fieryTale.gameMoment == 74)
                    {
                        if (maidoption == 1)
                        {
                            if (fieryTale.goroPoints > 3)
                            {
                                fieryTale.spriteBatch.DrawString(Names, "I go back to our dormroom.", new Vector2(10, 580), Color.White);
                            }
                        }
                    }
                    if (fieryTale.gameMoment == 75)
                    {
                        if (fieryTale.goroPoints > 3)
                        {
                            fieryTale.spriteBatch.DrawString(Names, "On my way there, I think about the times Goro and I spend together,", new Vector2(10, 580), Color.White);
                            fieryTale.spriteBatch.DrawString(Names, "back when we were both still alive.", new Vector2(10, 610), Color.White);
                        }
                    }

                }
                #endregion
                if (fieryTale.gameMoment == 76)
                {
                    if (fieryTale.goroPoints > 3)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Back in my dormroom, I longingly await Goro's return.", new Vector2(10, 580), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Back in my dormroom, I continue reading.", new Vector2(10, 580), Color.White);
                    }
                }

                fieryTale.spriteBatch.End();
            }
        }
    }
}

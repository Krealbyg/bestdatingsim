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
    public class Day10 : DrawableGameComponent
    {
        private FieryTale fieryTale;

        private int spyoption;//which way you decided to deal with Anna the yandere stalker
        private int simpoption;//which way you decide to react to the stalkers confession

        //lists
        private List<Button> spychoice;
        private List<Button> simpchoice;

        //Fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //textures
        private Texture2D rennormal;
        private Texture2D anna;
        private Texture2D textbox;
        private Texture2D dorm;
        private Texture2D hell;
        private Texture2D yasutora;
        private Texture2D kase;
        private Texture2D mrcare;
        private Texture2D library;
        private Texture2D cafe;

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
            yasutora = fieryTale.Content.Load<Texture2D>("Yasutora");
            kase = fieryTale.Content.Load<Texture2D>("Kase");
            goroneutral = fieryTale.Content.Load<Texture2D>("GoroNeutral");
            gorosmiling = fieryTale.Content.Load<Texture2D>("GoroSmiling");
            gorococky = fieryTale.Content.Load<Texture2D>("GoroCocky");
            goromaid = fieryTale.Content.Load<Texture2D>("Goromaid");
            goromaid2 = fieryTale.Content.Load<Texture2D>("Goromaid2");
            gorowink = fieryTale.Content.Load<Texture2D>("GoroWink");
            mrcare = fieryTale.Content.Load<Texture2D>("MrCare");
            library = fieryTale.Content.Load<Texture2D>("Library");
            cafe = fieryTale.Content.Load<Texture2D>("Cafe");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");
            thanatos = fieryTale.Content.Load<SoundEffect>("Thanatos");
            endit = fieryTale.Content.Load<SoundEffect>("EndIt");

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
                ButtonPosition = new Vector2(0, 125),
                ButtonText = "Persona!"
            };
            var simpchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 250),
                ButtonText = "Oh"
            };
            var simpchoice3 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 375),
                ButtonText = "Ehm"
            };
            var simpchoice4 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 375),
                ButtonText = "Hmm"
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

            #endregion

            base.LoadContent();
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
                if(fieryTale.gameMoment == 31 && fieryTale.soundMoment == 0)
                {
                    thanatos.Play();
                    fieryTale.soundMoment++;
                }
                if (fieryTale.gameMoment == 33 && fieryTale.soundMoment == 1)
                {
                    endit.Play();
                    fieryTale.soundMoment++;
                }

                foreach (var button in spychoice)
                    button.Update(gameTime);
                foreach (var button in simpchoice)
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
                if (fieryTale.gameMoment <= 5)
                {
                    fieryTale.spriteBatch.Draw(dorm, new Rectangle(0, 0, 1280, 760), Color.White);
                }
                else if (fieryTale.gameMoment > 5)
                {
                    fieryTale.spriteBatch.Draw(hell, new Rectangle(0, 0, 1280, 720), Color.White);
                }

                //textbox
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);

                //scenes
                if (fieryTale.gameMoment == 0)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I wake up extra early, I've got something to do before class today.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 1)
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
                    else if (spyoption == 3)
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
                    if (spyoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Okay, I'll try, just for you! Nya~", new Vector2(10, 580), Color.White);
                    }
                    else if (spyoption == 2)
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
                    else if (spyoption == 3)
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
                if (fieryTale.gameMoment == 25)
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
                    else if (simpoption == 2)
                    {

                    }
                    else if (simpoption == 3)
                    {

                    }
                    else if (simpoption == 4)
                    {

                    }
                }
                if (fieryTale.gameMoment == 29)
                {
                    if (simpoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I slowly reach for my glasses. Anna looks more desperate and confused.", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 2)
                    {

                    }
                    else if (simpoption == 3)
                    {

                    }
                    else if (simpoption == 4)
                    {

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

                    }
                    else if (simpoption == 3)
                    {

                    }
                    else if (simpoption == 4)
                    {

                    }
                }
                if (fieryTale.gameMoment == 31)//This persona is pretty cool
                {
                    if (simpoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I rip off my glasses and summon forth Thanatos from the sea of my soul.", new Vector2(10, 580), Color.White);
                    }
                    else if (simpoption == 2)
                    {

                    }
                    else if (simpoption == 3)
                    {

                    }
                    else if (simpoption == 4)
                    {

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

                    }
                    else if (simpoption == 3)
                    {

                    }
                    else if (simpoption == 4)
                    {

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

                    }
                    else if (simpoption == 3)
                    {

                    }
                    else if (simpoption == 4)
                    {

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
                    else if (simpoption == 2)
                    {

                    }
                    else if (simpoption == 3)
                    {

                    }
                    else if (simpoption == 4)
                    {

                    }
                }

                fieryTale.spriteBatch.End();
            }
        }
    }
}

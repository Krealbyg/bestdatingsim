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

        //lists
        private List<Button> hallchoice;

        //Fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //textures
        private Texture2D rennormal;
        private Texture2D textbox;
        private Texture2D dorm;
        private Texture2D yasutora;
        private Texture2D shiki;
        private Texture2D sabel;
        private Texture2D hell;
        private Texture2D classroom;
        private Texture2D sins;
        private Texture2D mrcare;
        private Texture2D bitch;
        private Texture2D hallway;

        //Goro expressions
        private Texture2D goroneutral;
        private Texture2D gorosmiling;
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
            //same old same old
            rennormal = fieryTale.Content.Load<Texture2D>("RenNormal");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            dorm = fieryTale.Content.Load<Texture2D>("Dorm");
            yasutora = fieryTale.Content.Load<Texture2D>("Yasutora");
            shiki = fieryTale.Content.Load<Texture2D>("Shiki");
            sabel = fieryTale.Content.Load<Texture2D>("Sabel");
            sins = fieryTale.Content.Load<Texture2D>("Sinsleft");
            goroneutral = fieryTale.Content.Load<Texture2D>("GoroNeutral");
            gorosmiling = fieryTale.Content.Load<Texture2D>("GoroSmiling");
            gorococky = fieryTale.Content.Load<Texture2D>("GoroCocky");
            classroom = fieryTale.Content.Load<Texture2D>("Classroom");
            mrcare = fieryTale.Content.Load<Texture2D>("MrCare");
            bitch = fieryTale.Content.Load<Texture2D>("BITCH");
            hell = fieryTale.Content.Load<Texture2D>("Hell");
            hallway = fieryTale.Content.Load<Texture2D>("Hallway");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");
            mizanagi = fieryTale.Content.Load<SoundEffect>("MagatsuIzanagi");
            punishment = fieryTale.Content.Load<SoundEffect>("ProperPunishment");

            #region buttons

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

            #endregion

            #region button choice event creation

            hallchoice1.Click += Hallchoice1_Click;
            hallchoice2.Click += Hallchoice2_Click;
            hallchoice3.Click += Hallchoice3_Click;
            hallchoice4.Click += Hallchoice4_Click;

            #endregion

            #region filling lists

            hallchoice = new List<Button>
            {
                hallchoice1,
                hallchoice2,
                hallchoice3,
                hallchoice4
            };

            #endregion

            base.LoadContent();
        }

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

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 5 && fieryTale.attackedSomeone == false)
            {
                if (fieryTale.gameMoment == 20 && fieryTale.soundMoment == 0)
                {
                    punishment.Play();
                    fieryTale.soundMoment++;
                }
                
                foreach (var button in hallchoice)
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
                if (fieryTale.gameMoment <= 4)
                {
                    fieryTale.spriteBatch.Draw(dorm, new Rectangle(0, 0, 1280, 760), Color.White);
                }
                else if (fieryTale.gameMoment > 4 && fieryTale.gameMoment <= 24)
                {
                    fieryTale.spriteBatch.Draw(hallway, new Rectangle(0, 0, 1280, 720), Color.White);
                }
                else if (fieryTale.gameMoment > 24)
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
                if (fieryTale.gameMoment == 3)
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
                if (fieryTale.gameMoment == 12)
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
                    if (halloption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I rip off my mask (glasses) and summon forth Magatsu Izanagi from the sea of my soul.", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "HEY! Stop that!", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 3)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "No, no, no, you're doing it all wrong. Let me help", new Vector2(10, 580), Color.White);
                    }
                    else if (halloption == 4)
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
                    if (halloption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "You deserve proper punishment.", new Vector2(10, 580), Color.White);
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

                fieryTale.spriteBatch.End();
            }
        }
    }
}

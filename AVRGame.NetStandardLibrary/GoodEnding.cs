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
    public class GoodEnding : DrawableGameComponent
    {
        FieryTale fieryTale;

        private int fightoption;//if you fight back or not

        private List<Button> fightchoice;
        private List<Button> epilogue;
        private List<Button> endgame;

        //fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //textures
        private Texture2D rennormal;
        private Texture2D joker;
        private Texture2D goku;
        private Texture2D textbox;
        private Texture2D velvet;
        private Texture2D bedroom;

        //sounds
        private SoundEffect drip;
        private SoundEffect arsene;
        private SoundEffect showtime;
        private Song bones;
        private Song combat;

        public GoodEnding(FieryTale fieryTale) : base(fieryTale)
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Big epic plot twist ending. (not really, was foreshadowed)
            rennormal = fieryTale.Content.Load<Texture2D>("RenNormal");
            joker = fieryTale.Content.Load<Texture2D>("Ren");
            goku = fieryTale.Content.Load<Texture2D>("Drip_Goku");
            velvet = fieryTale.Content.Load<Texture2D>("VelvetRoom");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            bedroom = fieryTale.Content.Load<Texture2D>("Bedroom");
            drip = fieryTale.Content.Load<SoundEffect>("DripSound");
            arsene = fieryTale.Content.Load<SoundEffect>("Arsene");
            showtime = fieryTale.Content.Load<SoundEffect>("Showtime");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");
            bones = fieryTale.Content.Load<Song>("Bones");
            combat = fieryTale.Content.Load<Song>("Combat");

            #region buttons
            //Fight Goku or not
            var fightchoice1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 268),
                ButtonText = "Fight back"
            };
            var fightchoice2 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 380),
                ButtonText = "Live a lie"
            };

            //start Epilogue
            var epiloguebutton = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 279),
                ButtonText = "Epilogue"
            };

            //end game button
            var nextlevel = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 279),
                ButtonText = "The End"
            };
            #endregion

            #region button click event creation
            fightchoice1.Click += Fightchoice1_Click;
            fightchoice2.Click += Fightchoice2_Click;

            epiloguebutton.Click += Epiloguebutton_Click;

            nextlevel.Click += Nextlevel_Click;
            #endregion

            #region filling lists
            fightchoice = new List<Button>
            {
                fightchoice1,
                fightchoice2
            };

            epilogue = new List<Button>
            {
                epiloguebutton
            };

            endgame = new List<Button>
            {
                nextlevel
            };
            #endregion

            base.LoadContent();
        }

        #region button click events
        private void Nextlevel_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 85)
            {
                fieryTale.currentLevel = 10;//starts next level
                fieryTale.gameMoment = 0;//resets the gameMoment count
                fieryTale.soundMoment = 0;//resets soundMoment
                MediaPlayer.Stop();//stops the chill music
                fieryTale.choiceMoment = false;
            }
        }

        private void Epiloguebutton_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 70)
            {
                fieryTale.gameMoment++;
                fieryTale.choiceMoment = false;
                MediaPlayer.Stop();
                MediaPlayer.Play(bones);
                MediaPlayer.Volume = 0.1f;
            }
        }

        private void Fightchoice2_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 25)
            {
                fightoption = 2;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
            }
        }

        private void Fightchoice1_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 25)
            {
                fightoption = 1;
                fieryTale.choiceMoment = false;
                fieryTale.gameMoment++;
                MediaPlayer.Stop();
                MediaPlayer.Play(combat);
                MediaPlayer.Volume = 0.1f;
            }
        }
        #endregion

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 9 && fieryTale.ending == 1 && fieryTale.goroRomance == false)
            {
                if (fieryTale.gameMoment == 1 && fieryTale.soundMoment == 0)
                {
                    drip.Play(0.1f, 0.0f, 0.0f);
                    fieryTale.soundMoment++;  
                }
                if (fieryTale.gameMoment == 31 && fieryTale.soundMoment == 1)
                {
                    arsene.Play();
                    fieryTale.soundMoment++;
                }
                if (fieryTale.gameMoment == 32 && fieryTale.soundMoment == 2)
                {
                    showtime.Play();
                    fieryTale.soundMoment++;
                }

                foreach (var button in fightchoice)
                    button.Update(gameTime);
                foreach (var button in epilogue)
                    button.Update(gameTime);
                foreach (var button in endgame)
                    button.Update(gameTime);

                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 9 && fieryTale.ending == 1 && fieryTale.goroRomance == false)
            {
                fieryTale.spriteBatch.Begin();

                //backgrounds
                if (fieryTale.gameMoment <= 70)
                {
                    fieryTale.spriteBatch.Draw(velvet, new Rectangle(0, 0, 1280, 720), Color.White);
                }
                else
                {
                    fieryTale.spriteBatch.Draw(bedroom, new Rectangle(0, 0, 1280, 720), Color.White);
                }

                //textbox
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);

                //scenes
                if (fieryTale.gameMoment == 0)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I'm back in the Velvet Room.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 1)//goku become scottish or something idk
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Oi lad! So, here we are yet again.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 2)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You seem to have made quite the name for yourself here wee man.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 3)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I'm proud of you.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 4)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "In a world where you could do anything, you showed me you really are a good guy.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 5)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Thanks da-", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 6)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "So, to reward you for your good behaviour, let me tell you a little something.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 7)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You see, this place is not actually Hell. I created this world to test you.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 8)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You passed my test of personality quite easily.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 9)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Anyway, you never actually died.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 10)//oh my, quite the surprise
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "WH-", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 11)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "But, that's not all. Now that I have seen how good your spirit is...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 12)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I challenge you to a duel! I want to test your might.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 13)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Accept, and we will fight until one of us surrenders.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 14)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "If you win, I return you to your world. Lose, you remain here.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 15)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You can also decline my challenge.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 16)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "If that is what you decide to do, I will return you to your life here.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 17)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "However, you will not remember all I just told you.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 18)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "So what will it be?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 19)//just trying to make it at least slightly understandable why Ren would stay
                {
                    if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "If I return to the real world, I will leave behind Anna.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "If I return to the real world, I will leave behind Goro.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 20)
                {
                    if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I guess she isn't real in the first place, but maybe our love is?", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I guess this isn't the real Goro anyway, but maybe our friendship is?", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 21)//but also showing why Ren shouldn't stay
                {
                    if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "My friends would surely miss me, would Anna?", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "My friends would surely miss me, would this Goro?", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 22)
                {
                    if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Would she even still exist if I leave?", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Would he even still exist if I leave?", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 23)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I've made this choice once before, with Maruki. I fought back then.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 24)//Ren would most certainly not accept, but Ren isn't the one making the decisions here, its the player and they can decide whatever they want.
                {
                    fieryTale.spriteBatch.DrawString(Names, "But, what do I do now?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 25)
                {
                    foreach (var button in fightchoice)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 26)
                {
                    if (fightoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I didn't fight back against Maruki just to let me be controlled by someone else!", new Vector2(10, 580), Color.White);
                    }
                    else if (fightoption == 2)//honestly Maruki does have a slight point, which is what makes him a good villian. He's not evil, just misguided. A gentle madman, if I may.
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Perhaps Maruki had a point. Living a good lie is better than a harsh truth.", new Vector2(10, 580), Color.White);
                    }

                }
                if (fieryTale.gameMoment == 27)
                {
                    if (fightoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I refuse to live a lie!", new Vector2(10, 580), Color.White);
                    }
                    else if (fightoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "I don't want to leave.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 28)
                {
                    if (fightoption == 1)//rebellion is the main theme of P5
                    {
                        fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Perfect! I see you have not lost your rebellious nature!", new Vector2(10, 580), Color.White);
                    }
                    else if (fightoption == 2)
                    {
                        fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Hmm, not what I expected, but very well.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 29)
                {
                    if (fightoption == 1)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "In a flash of blue fire I change back into my Thief outfit.", new Vector2(10, 580), Color.White);
                    }
                    else if (fightoption == 2)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "A single bright flash of light... I wake up, just another day in Hell.", new Vector2(10, 580), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 30)
                {
                    if (fightoption == 1)
                    {
                        fieryTale.spriteBatch.Draw(joker, new Rectangle(1024, 316, 256, 404), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Let's fucking go!", new Vector2(10, 580), Color.White);
                    }
                    else if (fightoption == 2)//sends you to the neutral ending epilogue
                    {
                        fieryTale.gameMoment = 19;
                        fieryTale.ending = 3;
                    }
                }
                if (fieryTale.gameMoment == 31)//Like I said in true ending, Arsene can become quite powerful if you use the Gallows are backwards fusion.
                {
                    fieryTale.spriteBatch.DrawString(Names, "I rip off my mask and summon forth Arsene from the sea of my soul.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 32)
                {
                    fieryTale.spriteBatch.Draw(joker, new Rectangle(1024, 316, 256, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "It's showtime!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 33)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Goku and I engage in an intense battle.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 34)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I seem to outmatch him at the start, but I realize soon that he is holding back.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 35)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Bit by bit he increases his power to test my limits.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 36)//Joker always seemed like someone who'd take enjoyment in his fights.
                {
                    fieryTale.spriteBatch.DrawString(Names, "As the battle rages on, I can't help the grin forming on my lips.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 37)//Joker is quite the show-off, I'm certain he'd miss being a Phantom Thief and doing cool stuff.
                {
                    fieryTale.spriteBatch.DrawString(Names, "Oh how I've missed this.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 38)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I'm pushed to new hights, my limits broken.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 39)
                {
                    fieryTale.spriteBatch.DrawString(Names, "The fight seems to last an enternity, but it can't last forever.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 40)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I can feel myself slipping. It's not enough.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 41)//The world Arcana is a bit weird in the games. It can only really be called upon by a wildcard empowered by the power of friendship or something like it.
                {
                    fieryTale.spriteBatch.DrawString(Names, "If only Satanael was still by my side... If only I could call upon the World Arcana...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 42)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I gather all my strength for one final attack.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 43)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I hit Goku with all my might.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 44)
                {
                    fieryTale.spriteBatch.DrawString(Names, "He is seriously knocked down, but it doesn't last.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 45)//Ren is a wildcare, they get strength from their bonds. He is still very powerful alone however
                {
                    fieryTale.spriteBatch.DrawString(Names, "Alone, I could never truly stand up to him. At least I gave it my all.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 46)
                {
                    fieryTale.spriteBatch.DrawString(Names, "He hits me with one last, devestating, attack.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 47)
                {
                    fieryTale.spriteBatch.DrawString(Names, "As I lay on the floor, Goku walks over and gives me a hand.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 48)
                {
                    fieryTale.spriteBatch.DrawString(Names, "He pulls me back up to my feet. Miraculously, I feel fine.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 49)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Wowie, it's been a while since I've had such an intense fight. You're like, really strong.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 50)
                {
                    fieryTale.spriteBatch.Draw(joker, new Rectangle(1024, 316, 256, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "And yet, I still lost.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 51)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "It was never about winning. I wanted to test your strength, your resolve.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 52)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You faught well, valiantly. I lied about the terms of victory.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 53)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "As long as you fought well, I would've send you back anyway.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 54)//nod to true ending
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I must say, however, I had expected you and Goro to become... even closer.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 55)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "That is why I put him here.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 56)//sequel bait?
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Oh well, I'll let you go now. Perhaps we will see eachother again some day.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 57)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Take care, Ren.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 58)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Goku opens a door back to the real world and then disappears.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 59)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I seem to have made a new, friendly, rival.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 60)
                {
                    if (fieryTale.annaRomance == true)//needed to add a little something for the Anna romance
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I found love here, it saddens me to leave Anna behind.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "It saddens me to leave the new connections I made behind.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    
                }
                if (fieryTale.gameMoment == 61)
                {
                    fieryTale.spriteBatch.DrawString(Names, "But what saddens me most is having to leave Goro.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 62)
                {
                    fieryTale.spriteBatch.DrawString(Names, "We finally got the chance to just hang out as our true selves.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 63)
                {
                    fieryTale.spriteBatch.DrawString(Names, "No threats to fight, no lies.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 64)//He certainly wouldn't
                {
                    fieryTale.spriteBatch.DrawString(Names, "But he wouldn't want me to keep living this lie.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 65)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I already rejected Maruki's reality knowing Goro would die again.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 66)
                {
                    fieryTale.spriteBatch.DrawString(Names, "So why is it still so hard this time?", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 67)//A little nod to Goro's leitmotiv "No more what ifs"
                {
                    fieryTale.spriteBatch.DrawString(Names, "Perhaps it's because those 'what if' scenario's finally could've become true...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 68)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I will always remember Goro, but I will move on as well. I've got to.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 69)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I step through the door...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 70)
                {
                    foreach (var button in epilogue)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 71)//no time skip this time
                {
                    fieryTale.spriteBatch.DrawString(Names, "I wake up, back home.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 72)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Morgana has been sleeping on my chest. I woke him up.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 73)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I explain to him what happened. He nods along, but seems slightly confused.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 74)
                {
                    fieryTale.spriteBatch.DrawString(Names, "We decide to go back to sleep, I've got school tomorrow.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 75)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I guess there is nothing to do now, but live my life.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 76)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I'll finish highschool, then I'll move back to Tokyo to be closer to my friends.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 77)//Yusuke would make a pretty alright roommate I think. He's from P5 btw
                {
                    fieryTale.spriteBatch.DrawString(Names, "Yusuke has already asked me to share an apartment with him, so atleast I won't live alone.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 78)//Good friend Morgana
                {
                    fieryTale.spriteBatch.DrawString(Names, "Of course, I'll also still have Morgana by my side.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 79)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I'll go to university, don't know what for yet though.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 80)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Then, I'll see where life takes me.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 81)
                {
                    fieryTale.spriteBatch.DrawString(Names, "No Metaverse, no Phantom Thieves, no detective rivals. Just normal everyday life.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 82)//As I mentioned somewhere else, Goro challenged Ren to a duel by throwing his glove at him.
                {
                    fieryTale.spriteBatch.DrawString(Names, "But, just in case, I'll keep training and I'll keep carrying that single leather glove.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 83)
                {
                    fieryTale.spriteBatch.DrawString(Names, "For I promised to duel again, and I refuse to lose.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 84)
                {
                    fieryTale.spriteBatch.DrawString(Names, "A new adventure awaits.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 85)//Roll credits
                {
                    foreach (var button in endgame)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }

                fieryTale.spriteBatch.End();
            }
        }
    }
}

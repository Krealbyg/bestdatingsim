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
    public class BadEnding : DrawableGameComponent
    {
        FieryTale fieryTale;

        private List<Button> reset;

        //fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //textures
        private Texture2D rennormal;
        private Texture2D goku;
        private Texture2D textbox;
        private Texture2D velvet;

        //sounds
        private SoundEffect drip;
        private SoundEffect arsene;
        private Song combat;

        public BadEnding(FieryTale fieryTale) : base(fieryTale)
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Bad to the bone
            rennormal = fieryTale.Content.Load<Texture2D>("RenNormal");
            goku = fieryTale.Content.Load<Texture2D>("Drip_Goku");
            velvet = fieryTale.Content.Load<Texture2D>("VelvetRoom");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            drip = fieryTale.Content.Load<SoundEffect>("DripSound");
            arsene = fieryTale.Content.Load<SoundEffect>("Arsene");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");
            combat = fieryTale.Content.Load<Song>("Combat");

            //Reset
            var wakeup = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 279),
                ButtonText = "Wake up"
            };

            wakeup.Click += Wakeup_Click;

            reset = new List<Button>
            {
                wakeup
            };

            base.LoadContent();
        }

        private void Wakeup_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 32)
            {
                fieryTale.currentLevel = 0;//starts next level
                fieryTale.gameMoment = 0;//resets the gameMoment count
                fieryTale.soundMoment = 0;//resets soundMoment
                fieryTale.gokuPoints = 0;//resets goku points
                fieryTale.goroPoints = 0;//resets goro points
                fieryTale.annaRomance = false;//removes romance tag
                fieryTale.goroRomance = false;//removes romance tag
                MediaPlayer.Stop();//stops music
                fieryTale.choiceMoment = false;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 9 && fieryTale.ending == 2)
            {
                if (fieryTale.gameMoment == 3 && fieryTale.soundMoment == 0)
                {
                    drip.Play(0.1f, 0.0f, 0.0f);
                    fieryTale.soundMoment++;
                }
                if (fieryTale.gameMoment == 17 && fieryTale.soundMoment == 1)
                {
                    arsene.Play();
                    fieryTale.soundMoment++;
                }

                foreach (var button in reset)
                    button.Update(gameTime);
                
                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 9 && fieryTale.ending == 2)
            {
                fieryTale.spriteBatch.Begin();

                //backgrounds
                fieryTale.spriteBatch.Draw(velvet, new Rectangle(0, 0, 1280, 720), Color.White);

                //textbox
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);

                //scenes
                if (fieryTale.gameMoment == 0)
                {
                    fieryTale.spriteBatch.DrawString(Names, "The Velvet Room, again again.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 1)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Something's... not right.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 2)//from here on out, some undertale references, just to spice it up a bit.
                {
                    fieryTale.spriteBatch.DrawString(Names, "I feel like I'm going to have a bad time.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 3)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "It's a beautiful day outside...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 4)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Birds are singing...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);

                }
                if (fieryTale.gameMoment == 5)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Flowers are blooming...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 6)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "On days like these, kids like you...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 7)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Should be burning in Hell.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 8)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Aren't we already in He-", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 9)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Don't try to be a fucking smartass.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 10)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You really believed this Highschool in Hell crap? I expected better of you.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 11)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "This is a world I created to test people like you. You've shown me your true colours.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 12)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You got ample opportunity to be a good person, but you decided to be a cunt.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 13)//yeah being a cunt is pretty out of character for Ren, but whatever we put cunty choices in the game. To make up for it, this bad ending.
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You betrayed everything you once stood for.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 14)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Now, I'm going to send you to Hell for real.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 15)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I feel my sins crawling on my back.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 16)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I won't go down without a fight however.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 17)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I rip off my mask and summon forth Arsene from the sea of my soul.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    if (fieryTale.songPlaying == true)
                    {
                        MediaPlayer.Stop();
                        MediaPlayer.Play(combat);
                        MediaPlayer.Volume = 0.1f;
                        fieryTale.songPlaying = false;
                    }
                }
                if (fieryTale.gameMoment == 18)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I launch attack after attack, I summon Persona after Persona, but...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 19)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Nothing. All of it just does nothing.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 20)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I go in for one, final attack.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 21)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Goku dodges it easily and in one fluid motion sends a blast of energy into my body.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 22)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I crash against the wall. I've broken bones I never knew I had.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 23)
                {
                    fieryTale.spriteBatch.DrawString(Names, "As I try to get back up on my feet, Goku picks me up to look me in the eyes.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 24)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 25)
                {
                    fieryTale.spriteBatch.DrawString(Names, "He releases a blast of energy straight into my face and everything goes dark.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 26)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I feel my body getting ripped apart atom by atom for what seems like an eternity.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 27)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Then... nothing. My consciousness is fading. This is it.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 28)
                {
                    fieryTale.spriteBatch.DrawString(Names, "In the distance, a dim light.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 29)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Is this that light at the end of the tunnel people speak of?", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 30)
                {
                    fieryTale.spriteBatch.DrawString(Names, "The light starts to rapidly approach me. Coming closer and closer.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 31)
                {
                    fieryTale.spriteBatch.DrawString(Names, "It blinds me, it envelops me, I can feel its warmth. I can...", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 32)
                {
                    foreach (var button in reset)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }


                fieryTale.spriteBatch.End();
            }
        }
    }
}

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
    public class TimeSkip1 : DrawableGameComponent
    {
        FieryTale fieryTale;

        private List<Button> button;

        //fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //textures
        private Texture2D goku;
        private Texture2D velvet;
        private Texture2D textbox;

        //sounds
        private SoundEffect drip;

        public TimeSkip1(FieryTale fieryTale) : base(fieryTale)
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
            goku = fieryTale.Content.Load<Texture2D>("Drip_Goku");
            velvet = fieryTale.Content.Load<Texture2D>("VelvetRoom");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            drip = fieryTale.Content.Load<SoundEffect>("DripSound");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");

            //button stuff
            var nextlevel = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 279),
                ButtonText = "Next Day"
            };

            nextlevel.Click += Nextlevel_Click;

            button = new List<Button>
                {
                    nextlevel
                };

            base.LoadContent();
        }
        private void Nextlevel_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 12)
            {
                fieryTale.currentLevel = 5;//starts next level
                fieryTale.gameMoment = 0;//resets the gameMoment count
                fieryTale.soundMoment = 0;//resets soundMoment
                MediaPlayer.Stop();//stops the chill music
                fieryTale.choiceMoment = false;
            }
        }
        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 4 && fieryTale.attackedSomeone == false)
            {
                if (fieryTale.gameMoment == 2 && fieryTale.soundMoment == 0)
                {
                    drip.Play(volume: 0.1f, 0.0f, 0.0f);
                    fieryTale.soundMoment++;
                }
                
                foreach (var button in button)
                    button.Update(gameTime);

                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 4 && fieryTale.attackedSomeone == false)
            {
                fieryTale.spriteBatch.Begin();

                //perm
                fieryTale.spriteBatch.Draw(velvet, new Rectangle(0, 0, 1280, 720), Color.White);
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);

                //events
                if (fieryTale.gameMoment == 0)//Persona reference
                {
                    fieryTale.spriteBatch.DrawString(Names, "I seem to be back in the Velvet Room.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 1)//Igor sort of owns the velvetroom and Lavenza is Ren's attendant
                {
                    fieryTale.spriteBatch.DrawString(Names, "Igor or Lavenza are nowhere to be found however...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 2)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Hey kid, long time no see.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 3)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "It seems you've finished your second day of school in Hell.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 4)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Apart from the occasional hiccup, it's been smooth sailing.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 5)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "The next couple days are quite uneventful.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 6)//Goku throwing shade
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You still wake up too late and gotta hurry to class, apparently you don't know how clocks work.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 7)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Mr Sins lessons are always the same, but they're better than Ms Bitch's.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 8)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You have an occasional chat with your classmates.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 9)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Back in your dormroom, you spend your nights hanging out with Akechi.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 10)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "It's your 5th day of school now, we will continue our story here.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 11)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Good luck, don't do anything I wouldn't do", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 12)
                {
                    foreach (var button in button)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }

                fieryTale.spriteBatch.End();
            }
        }
    }
}

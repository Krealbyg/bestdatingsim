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
    public class GameOver : DrawableGameComponent
    {
        private FieryTale fieryTale;

        //List
        private List<Button> button;

        //Fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //Textures
        private Texture2D goku;
        private Texture2D textbox;
        private Texture2D background;

        //Sounds
        private SoundEffect drip;

        public GameOver(FieryTale fieryTale) : base(fieryTale)//constructor, inherit some stuff from main file (like spritebatch)
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //all the textures, sounds and fonts used here
            goku = fieryTale.Content.Load<Texture2D>("Drip_Goku");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            background = fieryTale.Content.Load<Texture2D>("VelvetRoom");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");
            drip = fieryTale.Content.Load<SoundEffect>("DripSound");

            var endbutton = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)//game exit button
            {
                ButtonPosition = new Vector2(0, 279),
                ButtonText = "End Game",
                PenColour = Color.White,
            };

            endbutton.Click += Endbutton_Click;

            button = new List<Button>()//puts button in list
            {
                endbutton
            };

            base.LoadContent();
        }

        private void Endbutton_Click(object sender, EventArgs e)//game exit button event
        {
            if (fieryTale.gameMoment == 4 && fieryTale.attackedSomeone == true)
            {
                fieryTale.Exit();
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.gameMoment == 1 && fieryTale.soundMoment == 0 && fieryTale.attackedSomeone == true)//plays drip
            {
                drip.Play(volume: 0.1f, 0.0f, 0.0f);//normal loudness
                fieryTale.soundMoment++;//stops from looping
            }
            if (fieryTale.gameMoment == 4 && fieryTale.soundMoment == 1 && fieryTale.attackedSomeone == true)//plays drip extra loud to signify your death
            {
                drip.Play(volume: 1f, 0.0f, 0.0f);//quite loud
                fieryTale.soundMoment++;//same ^
            }

            foreach (var button in button)//updates the button
                button.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.attackedSomeone == true)
            {
                fieryTale.spriteBatch.Begin();

                //Permanent stuff
                fieryTale.spriteBatch.Draw(background, new Rectangle(0, 0, 1280, 720), Color.White);
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);

                //Scenes
                if (fieryTale.gameMoment == 0)
                {
                    fieryTale.spriteBatch.DrawString(Names, "You feel like you've made a grave mistake.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 1)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Ren, I am very disappointed in you.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 2)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You must learn the consequences of your actions.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 3)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You are no longer the main character, just another pawn in the game.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 4)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Game Over", new Vector2(10, 580), Color.White);
                    foreach (var button in button)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }

                fieryTale.spriteBatch.End();
            }
        }
    }
}

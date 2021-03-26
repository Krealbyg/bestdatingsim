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
    public class Level1 : DrawableGameComponent
    {
        private FieryTale fieryTale;

        //lists
        private List<Button> buttons;
        
        //Fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //Textures
        private Texture2D ren;
        private Texture2D goku;
        private Texture2D background;
        private Texture2D textbox;

        //Sounds
        private SoundEffect drip;
        private SoundEffect teleport;
        public Level1(FieryTale fieryTale) : base(fieryTale)//constructor, inherit some stuff from main file (like spritebatch)
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            //textures, sounds and fonts
            ren = fieryTale.Content.Load<Texture2D>("Ren");
            goku = fieryTale.Content.Load<Texture2D>("Drip_Goku");
            background = fieryTale.Content.Load<Texture2D>("Hell");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            drip = fieryTale.Content.Load<SoundEffect>("DripSound");
            teleport = fieryTale.Content.Load<SoundEffect>("Teleportsound");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");

            //buttons
            var button1 = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 324),
                ButtonText = "DRIP",
                PenColour = Color.Red,
            };

            //adds button click events
            button1.Click += Button1_Click;

            //filling lists
            buttons = new List<Button>()
            {
                button1,
            };

            base.LoadContent();

        }

        private void Button1_Click(object sender, EventArgs e)//click event for button1
        {
            if (fieryTale.gameMoment == 7)//only recognises the click during gamemoment 7 otherwise could be clicked at all times
            {
                drip.Play(volume: 0.1f, 0.0f, 0.0f);
                fieryTale.choiceMoment = 0;
                fieryTale.gameMoment++;
            }
        }

        public override void Update(GameTime gameTime)
        {
            //soundeffects
            if (fieryTale.gameMoment == 6 && fieryTale.soundMoment == 0)
            {
                drip.Play(volume: 0.1f, 0.0f, 0.0f);//deafened me on high volume
                fieryTale.soundMoment++;//increased so the sound doesn't loop forever
            }
            if (fieryTale.gameMoment == 9 && fieryTale.soundMoment == 1)
            {
                teleport.Play(volume: 0.15f, 0.0f, 0.0f);//same as ^
                fieryTale.soundMoment++;
            }

            foreach (var button in buttons)//updates all the buttons
                button.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            fieryTale.spriteBatch.Begin();

            //Permanent
            fieryTale.spriteBatch.Draw(background, new Rectangle(0, 0, 1280, 720), Color.White);
            fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);
            //Scenes
            if (fieryTale.gameMoment == 0)
            {
                fieryTale.spriteBatch.DrawString(Names, "You are Ren Amamiya, leader of the Phantom Thieves.", new Vector2(10, 580), Color.White);
            }
            if (fieryTale.gameMoment == 1)
            {
                fieryTale.spriteBatch.DrawString(Names, "While crossing the streets of Shibuya, you were unceremoniously hit by a truck and died.", new Vector2(10, 580), Color.White);
            }
            if (fieryTale.gameMoment == 2)
            {
                fieryTale.spriteBatch.Draw(ren, new Rectangle(1010, 300, 256, 404), Color.White);
                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                fieryTale.spriteBatch.DrawString(Talking, "Where the fuck am I?", new Vector2(10, 580), Color.White);
            }
            if (fieryTale.gameMoment == 3)
            {
                fieryTale.spriteBatch.Draw(goku, new Rectangle(1010, 300, 256, 404), Color.Black);
                fieryTale.spriteBatch.DrawString(Names, "Mysterious voice:", new Vector2(10, 540), Color.White);
                fieryTale.spriteBatch.DrawString(Talking, "You have died. Welcome to Hell.", new Vector2(10, 580), Color.White);
            }
            if (fieryTale.gameMoment == 4)
            {
                fieryTale.spriteBatch.Draw(ren, new Rectangle(1010, 300, 256, 404), Color.White);
                fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                fieryTale.spriteBatch.DrawString(Talking, "Who are you? I will reveal your true form!", new Vector2(10, 580), Color.White);
            }
            if (fieryTale.gameMoment == 5)
            {
                fieryTale.spriteBatch.Draw(goku, new Rectangle(1010, 300, 256, 404), Color.Black);
                fieryTale.spriteBatch.DrawString(Names, "Mysterious voice:", new Vector2(10, 540), Color.White);
                fieryTale.spriteBatch.DrawString(Talking, "There is no need, for I am...", new Vector2(10, 580), Color.White);
            }
            if (fieryTale.gameMoment == 6)
            {
                fieryTale.spriteBatch.Draw(goku, new Vector2(990, 300), Color.White);
                fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                fieryTale.spriteBatch.DrawString(Talking, "Goku", new Vector2(10, 580), Color.White);
            }

            if (fieryTale.gameMoment == 7)
            {
                foreach (var button in buttons)
                    button.Draw(gameTime);
                fieryTale.choiceMoment = 1;
            }
            if (fieryTale.gameMoment == 8)
            {
                fieryTale.spriteBatch.Draw(goku, new Vector2(990, 300), Color.White);
                fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                fieryTale.spriteBatch.DrawString(Talking, "I'll be going now, goodbye", new Vector2(10, 580), Color.White);
            }
            fieryTale.spriteBatch.End();
        }
    }
}

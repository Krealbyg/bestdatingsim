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
        public int windowWidth = 1280, windowHeight = 720;
        private FieryTale fieryTale;
        
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
        public Level1(FieryTale fieryTale) : base(fieryTale)
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
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            if (fieryTale.gameMoment == 6 && fieryTale.soundMoment == 0)
            {
                drip.Play(volume: 0.2f, 0.0f, 0.0f);
                fieryTale.soundMoment = fieryTale.soundMoment + 1;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            fieryTale.spriteBatch.Begin();
            fieryTale.spriteBatch.Draw(background, new Rectangle(0, 0, 1280, 720), Color.White);
            fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);
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
            fieryTale.spriteBatch.End();
        }
    }
}

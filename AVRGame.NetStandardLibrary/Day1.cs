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
    public class Day1 : DrawableGameComponent
    {
        FieryTale fieryTale;

        //Fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //Textures
        private Texture2D ren;
        private Texture2D goku;
        private Texture2D background;
        private Texture2D textbox;
        private Texture2D anna;
        private Texture2D dorm;
        private Texture2D shiki;
        private Texture2D sabel;
        private Texture2D yasutora;

        //Sounds
        private SoundEffect drip;
        private SoundEffect teleport;

        public Day1(FieryTale fieryTale) : base(fieryTale)//constructor
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //you know the drill
            ren = fieryTale.Content.Load<Texture2D>("Ren");
            goku = fieryTale.Content.Load<Texture2D>("Drip_Goku");
            background = fieryTale.Content.Load<Texture2D>("Hell");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            anna = fieryTale.Content.Load<Texture2D>("Anna");
            dorm = fieryTale.Content.Load<Texture2D>("Dorm");
            shiki = fieryTale.Content.Load<Texture2D>("Shiki");
            sabel = fieryTale.Content.Load<Texture2D>("Sabel");
            yasutora = fieryTale.Content.Load<Texture2D>("Yasutora");
            drip = fieryTale.Content.Load<SoundEffect>("DripSound");
            teleport = fieryTale.Content.Load<SoundEffect>("Teleportsound");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 2 && fieryTale.attackedSomeone == false)//only in this level and no gameover
            {
                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 2 && fieryTale.attackedSomeone == false)//only while this level and no gameover
            {
                //backgrounds
                

                //Textbox
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);//720 - 200 = 520, 1280 is screen width, 200 randomly decided

                //Scenes
                fieryTale.spriteBatch.Begin();
                if (fieryTale.gameMoment == 0)
                {
                    fieryTale.spriteBatch.DrawString(Names, "You've woken up for your first day of school... in Hell.", new Vector2(10, 580), Color.White);//positions of text arbitrarily decided until it looked good
                }

                fieryTale.spriteBatch.End();
            }
        }
    }
}

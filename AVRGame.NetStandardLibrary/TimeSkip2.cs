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
    public class TimeSkip2 : DrawableGameComponent
    {
        private FieryTale fieryTale;

        //fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //textures
        private Texture2D goku;
        private Texture2D velvet;
        private Texture2D textbox;

        //sounds
        private SoundEffect drip;

        public TimeSkip2(FieryTale fieryTale) : base(fieryTale)
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //look is this one even read anymore?
            goku = fieryTale.Content.Load<Texture2D>("Drip_Goku");
            velvet = fieryTale.Content.Load<Texture2D>("VelvetRoom");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            drip = fieryTale.Content.Load<SoundEffect>("DripSound");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 7 && fieryTale.attackedSomeone == false)
            {
                
                
                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 7 && fieryTale.attackedSomeone == false)
            {
                fieryTale.spriteBatch.Begin();

                //textbox and background
                fieryTale.spriteBatch.Draw(velvet, new Rectangle(0, 0, 1280, 720), Color.White);
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);

                //scenes
                if (fieryTale.gameMoment == 0)
                {
                    fieryTale.spriteBatch.DrawString(Names, "The Velvet Room, again.", new Vector2(10, 580), Color.White);
                }

                fieryTale.spriteBatch.End();
            }
        }
    }
}

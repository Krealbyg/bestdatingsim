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

        //Fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //Textures
        private Texture2D goku;
        private Texture2D textbox;
        private Texture2D background;

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
            goku = fieryTale.Content.Load<Texture2D>("Drip_Goku");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            background = fieryTale.Content.Load<Texture2D>("VelvetRoom");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.attackedSomeone == true)
            {
                fieryTale.spriteBatch.Begin();

                fieryTale.spriteBatch.Draw(background, new Rectangle(0, 0, 1280, 720), Color.White);



                fieryTale.spriteBatch.End();
            }
        }
    }
}

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
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 4 && fieryTale.attackedSomeone == false)
            {
                
                
                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 4 && fieryTale.attackedSomeone == false)
            {
                fieryTale.spriteBatch.Begin();



                fieryTale.spriteBatch.End();
            }
        }
    }
}

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
    public class Credits : DrawableGameComponent
    {
        private FieryTale fieryTale;

        private List<Button> end;

        //fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //background
        private Texture2D chess;
        private Texture2D textbox;//to darken background


        public Credits(FieryTale fieryTale) : base(fieryTale)
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //here it is, end of the game.
            chess = fieryTale.Content.Load<Texture2D>("Chess");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");

            //end game button
            var endgame = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 279),
                ButtonText = "Thank you for playing"
            };

            endgame.Click += Endgame_Click;

            end = new List<Button>
            {
                endgame
            };

            base.LoadContent();
        }

        private void Endgame_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment > 0)
            {
                fieryTale.Exit();
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 10)
            {
                foreach (var button in end)
                    button.Update(gameTime);

                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 10)
            {
                fieryTale.spriteBatch.Begin();

                //background
                fieryTale.spriteBatch.Draw(chess, new Rectangle(0, 0, 1280, 720), Color.White);
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 0, 1280, 720), Color.Black * 0.4f);

                //scenes
                if (fieryTale.gameMoment == 0)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Credits", new Vector2(10, 30), Color.White);

                    fieryTale.spriteBatch.DrawString(Names, "Director", new Vector2(10, 70), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Liam Temming", new Vector2(10, 100), Color.White);

                    fieryTale.spriteBatch.DrawString(Names, "Programming team", new Vector2(10, 140), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Liam Temming (Lead)", new Vector2(10, 170), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Jordy van Nuijs", new Vector2(10, 190), Color.White);

                    fieryTale.spriteBatch.DrawString(Names, "Writing team", new Vector2(10, 230), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Jordy van Nuijs (Lead, General)", new Vector2(10, 260), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Liam Temming (Lead, Persona specific stuff, Goro x Ren)", new Vector2(10, 280), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Mustafa Karimi", new Vector2(10, 300), Color.White);

                    fieryTale.spriteBatch.DrawString(Names, "Graphics", new Vector2(10, 340), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Mostly stolen from Atlus and random artists.", new Vector2(10, 370), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Edited by Jordy van Nuijs", new Vector2(10, 390), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "And Mustafa Karimi", new Vector2(10, 410), Color.White);

                    fieryTale.spriteBatch.DrawString(Names, "Sounds", new Vector2(10, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Mostly stolen from Atlus", new Vector2(10, 480), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Edited by Liam Temming", new Vector2(10, 500), Color.White);

                    fieryTale.spriteBatch.DrawString(Names, "Playtesting", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Mustafa Karimi (Lead)", new Vector2(10, 570), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Jordy van Nuijs", new Vector2(10, 590), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Liam Temming", new Vector2(10, 610), Color.White);

                    fieryTale.spriteBatch.DrawString(Names, "Special Thanks", new Vector2(10, 650), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Atlus for making Persona 5 Royal", new Vector2(10, 680), Color.White);
                }
                else
                {
                    foreach (var button in end)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                fieryTale.spriteBatch.End();
            }
        }
    }
}

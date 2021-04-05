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
    public class NeutralEnding : DrawableGameComponent
    {
        FieryTale fieryTale;

        private List<Button> epilogue;
        private List<Button> endgame;

        //fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //textures
        private Texture2D rennormal;
        private Texture2D goku;
        private Texture2D textbox;
        private Texture2D velvet;
        private Texture2D city;

        //sounds
        private SoundEffect drip;
        private SoundEffect teleport;
        private Song bones;

        public NeutralEnding(FieryTale fieryTale) : base(fieryTale)
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Honestly, neutral ending isn't too bad.
            rennormal = fieryTale.Content.Load<Texture2D>("RenNormal");
            goku = fieryTale.Content.Load<Texture2D>("Drip_Goku");
            velvet = fieryTale.Content.Load<Texture2D>("VelvetRoom");
            city = fieryTale.Content.Load<Texture2D>("City1");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");
            drip = fieryTale.Content.Load<SoundEffect>("DripSound");
            teleport = fieryTale.Content.Load<SoundEffect>("Teleportsound");
            bones = fieryTale.Content.Load<Song>("Bones");

            //start Epilogue
            var epiloguebutton = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 279),
                ButtonText = "Epilogue"
            };

            //end game button
            var nextlevel = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 279),
                ButtonText = "The End"
            };

            epiloguebutton.Click += Epiloguebutton_Click;

            nextlevel.Click += Nextlevel_Click;

            epilogue = new List<Button>
            {
                epiloguebutton
            };

            endgame = new List<Button>
            {
                nextlevel
            };

            base.LoadContent();
        }

        private void Nextlevel_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 36)
            {
                fieryTale.currentLevel = 10;//starts next level
                fieryTale.gameMoment = 0;//resets the gameMoment count
                fieryTale.soundMoment = 0;//resets soundMoment
                MediaPlayer.Stop();//stops the chill music
                fieryTale.choiceMoment = false;
            }
        }

        private void Epiloguebutton_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 19)
            {
                fieryTale.gameMoment++;
                fieryTale.choiceMoment = false;
                MediaPlayer.Stop();
                MediaPlayer.Play(bones);
                MediaPlayer.Volume = 0.1f;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 9 && fieryTale.ending == 3)
            {
                if (fieryTale.gameMoment == 2 && fieryTale.soundMoment == 0)
                {
                    drip.Play(0.1f, 0.0f, 0.0f);
                    fieryTale.soundMoment++;
                }
                if (fieryTale.gameMoment == 18 && fieryTale.soundMoment == 1)
                {
                    teleport.Play(0.15f, 0.0f, 0.0f);
                    fieryTale.soundMoment++;
                }

                foreach (var button in epilogue)
                    button.Update(gameTime);
                foreach (var button in endgame)
                    button.Update(gameTime);

                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            
            if (fieryTale.currentLevel == 9 && fieryTale.ending == 3)
            {
                fieryTale.spriteBatch.Begin();

                //backgrounds
                if (fieryTale.gameMoment <= 19)
                {
                    fieryTale.spriteBatch.Draw(velvet, new Rectangle(0, 0, 1280, 720), Color.White);
                }
                else
                {
                    fieryTale.spriteBatch.Draw(city, new Rectangle(0, 0, 1280, 720), Color.White);
                }

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
                    fieryTale.spriteBatch.DrawString(Names, "Wonder what's going on this time.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 2)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Hey there kiddo. Here we are again.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 3)//averagely, is that even a real word?
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Seems like you went averagely through your journey here.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 4)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Never really the good guy, but never really the bad guy either.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 5)
                {
                    if (fieryTale.goroRomance == true)
                    {
                        fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "You and Goro fell in-love. Or maybe you already were, but just now acted upon it.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "You and Goro have become very good friends.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 6)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "It's a bit sad for all of this to end here, don't you agree?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 7)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I gue-", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 8)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Well it doesn't matter at this point.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 9)
                {
                    if (fieryTale.annaRomance == true)//stockholm syndrome...
                    {
                        fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "You and Anna love eachother very much and spend everyday together.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                    }
                    else//crazy stalker bitch
                    {
                        fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Anna is still very much in love with you.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                    }
                    
                }
                if (fieryTale.gameMoment == 10)
                {
                    if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Mostly because she is easily jealous and very possessive...", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                    }
                    else//probs not
                    {
                        fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, "Who knows if she'll ever let this go...", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 11)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Oh well, you seem to be able to handle it.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 12)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Your attitude towards the teachers is pretty friendly.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 13)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Well except for Miss Bitch, but whatever.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 14)//this is actually the end. Sequel bait?
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Now, while it may seem your journey ends here, this is far from over.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 15)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Your new life in Hell has just begun.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 16)
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "So go on, get out of here, continue your life. We will not meet again.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 17)//wise words to live by
                {
                    fieryTale.spriteBatch.Draw(goku, new Rectangle(700, -100, 680, 830), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Goodbye Ren. And remember: Don't be a cunt.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 18)
                {
                    fieryTale.spriteBatch.DrawString(Names, "With that, Goku disappears. My new life in Hell, huh? Could be worse.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 19)
                {
                    foreach (var button in epilogue)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 20)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I continue my Highschool journey.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 21)//just adding in little changes based on romance path
                {
                    if (fieryTale.goroRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Goro and I make up for our lost time.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I spent most of my free time together with Anna.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I keep spending a lot of time with Goro.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 22)
                {
                    if (fieryTale.goroRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "We spend all our freetime together and always fall asleep in the same bed.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "It's always a shame when we part ways for the night.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I also still spend time with Anna, not always on my own accord.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 23)
                {
                    fieryTale.spriteBatch.DrawString(Names, "School is still the same as always, uneventful.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 24)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Eventually I graduate and move on to university.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 25)//not always the best idea to choose further education based on your relationships, but whatevs
                {
                    if (fieryTale.goroRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I go to the same one as Goro so that we can be together as much as possible.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I go to the same one as Anna, mostly because she pretty much forced me to.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I go to the same one as Goro so I can have a friendly face around.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 26)
                {
                    if (fieryTale.goroRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "We spend nearly every waking, and also non-waking, moment together.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I don't mind though, I get to spend even more time with Anna now.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Anna eventually showed up as well, no coincidence if I had to guess.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 27)
                {
                    fieryTale.spriteBatch.DrawString(Names, "My university years are pretty calm. I chose an easy study just to get it over with.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 28)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I don't question where the university or city even came from, I think it better not to.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 29)
                {
                    if (fieryTale.goroRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "After university, Goro and I get our own place together.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "After university, Anna and I get our own place together.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "After university, I move into my own place.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 30)
                {
                    if (fieryTale.goroRomance == true)//"no more what if's" is the name of Goro's leitmotiv. Also the song of the trueending epilogue
                    {
                        fieryTale.spriteBatch.DrawString(Names, "We've long stopped thinking about 'what if's' of the past.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "We live quite peacefully together. She's still very protective, but it's kinda endearing.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I still hang out with Goro, but we mostly do our own thing now.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 31)
                {
                    if (fieryTale.goroRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Instead we make as many new adventures together as possible.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I still hang out with Goro from time to time.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else//Morgana is apparently a girl's name? Idk in P5 morgana is a dude
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Eventually I adopt a black cat and name him Morgana.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 32)
                {
                    if (fieryTale.goroRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I sometimes still reminisce about the past and my old friends.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Sometimes I miss living with him.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I still miss my old friends from time to time and wonder how life could've been.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 33)
                {
                    if (fieryTale.goroRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "But I'm happy I get to spend my afterlife with the person I love.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I'm happy I found love in the afterlife.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I sometimes get the sense Anna is still watching me.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 34)
                {
                    if (fieryTale.goroRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "Deep down, I feel that this was meant to be.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I do sometimes miss my old friends, but that's okay.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "A bit sad she still isn't able to let go.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 35)
                {
                    if (fieryTale.goroRomance == true)//little nod to the fact there is a trueending with Goro
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I guess death is pretty good, but I feel this could've been better...", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else if (fieryTale.annaRomance == true)
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I guess death isn't too bad.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                    else
                    {
                        fieryTale.spriteBatch.DrawString(Names, "I guess death is alright.", new Vector2(10, 580), Color.White);
                        fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                    }
                }
                if (fieryTale.gameMoment == 36)//roll credits
                {
                    foreach (var button in endgame)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }

                fieryTale.spriteBatch.End();
            }
        }
    }
}

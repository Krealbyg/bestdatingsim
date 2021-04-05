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
    public class Day0 : DrawableGameComponent
    {
        private FieryTale fieryTale;

        //List
        private List<Button> buttons;//literally just for one button but whatever
        
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

        //Sounds
        private SoundEffect drip;
        private SoundEffect teleport;

        public Day0(FieryTale fieryTale) : base(fieryTale)//constructor
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //loading textures, sounds and fonts
            ren = fieryTale.Content.Load<Texture2D>("Ren");
            goku = fieryTale.Content.Load<Texture2D>("Drip_Goku");
            background = fieryTale.Content.Load<Texture2D>("Hell");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            anna = fieryTale.Content.Load<Texture2D>("Anna");
            dorm = fieryTale.Content.Load<Texture2D>("Dorm");
            drip = fieryTale.Content.Load<SoundEffect>("DripSound");
            teleport = fieryTale.Content.Load<SoundEffect>("Teleportsound");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");

            //button
            var endlevel = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 329),
                ButtonText = "Next day"
            };

            endlevel.Click += Endlevel_Click;

            buttons = new List<Button>//puts the single button in the list
            {
                endlevel
            };

            base.LoadContent();
        }

        private void Endlevel_Click(object sender, EventArgs e)//endlevel button event
        {
            if (fieryTale.gameMoment == 30)
            {
                fieryTale.currentLevel = 2;//starts next level
                fieryTale.gameMoment = 0;//resets the gameMoment count
                fieryTale.soundMoment = 0;//resets soundMoment
                MediaPlayer.Stop();//stops the chill music
                fieryTale.choiceMoment = false;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 1 && fieryTale.attackedSomeone == false)//only when on this level and not gameover
            {
                //soundeffects
                if (fieryTale.gameMoment == 6 && fieryTale.soundMoment == 0)
                {
                    drip.Play(volume: 0.1f, 0.0f, 0.0f);//deafened me on high volume
                    fieryTale.soundMoment++;//increased so the sound doesn't loop forever
                }
                if (fieryTale.gameMoment == 8 && fieryTale.soundMoment == 1)
                {
                    teleport.Play(volume: 0.15f, 0.0f, 0.0f);//same as ^
                    fieryTale.soundMoment++;
                }

                foreach (var button in buttons)//updates the button
                    button.Update(gameTime);

                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 1 && fieryTale.attackedSomeone == false)//only when on this level and not gameover
            {
                fieryTale.spriteBatch.Begin();

                //backgrounds
                if (fieryTale.gameMoment <= 21)//hell background
                {
                    fieryTale.spriteBatch.Draw(background, new Rectangle(0, 0, 1280, 720), Color.White);//screen width and height
                }
                else if (fieryTale.gameMoment > 21)//background change when going into dormroom
                {
                    fieryTale.spriteBatch.Draw(dorm, new Rectangle(0, 0, 1280, 760), Color.White);
                }
                
                //Textbox
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);//720 - 200 = 520, 1280 is screen width, 200 randomly decided

                //Scenes
                if (fieryTale.gameMoment == 0)//Ren was originally only there for the Testlevel, but then forced him to be the main character
                {
                    fieryTale.spriteBatch.DrawString(Names, "You are Ren Amamiya, leader of the Phantom Thieves.", new Vector2(10, 580), Color.White);//positions of text arbitrarily decided until it looked good
                }
                if (fieryTale.gameMoment == 1)
                {
                    fieryTale.spriteBatch.DrawString(Names, "While crossing the streets of Shibuya, you were unceremoniously hit by a truck and died.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 2)
                {
                    fieryTale.spriteBatch.Draw(ren, new Rectangle(1024, 316, 256, 404), Color.White);//position calculated based on size, size based on original image
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Where the fuck am I?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 3)
                {
                    fieryTale.spriteBatch.Draw(goku, new Vector2(990, 305), Color.Black);//original image size fine (340 x 415), some extra space around goku so position couldn't be calculated and was eyeballed
                    fieryTale.spriteBatch.DrawString(Names, "Mysterious voice:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You have died. Welcome to Hell.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 4)//reference to Persona 5
                {
                    fieryTale.spriteBatch.Draw(ren, new Rectangle(1024, 316, 256, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Who are you? I will reveal your true form!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 5)
                {
                    fieryTale.spriteBatch.Draw(goku, new Vector2(990, 300), Color.Black);
                    fieryTale.spriteBatch.DrawString(Names, "Mysterious voice:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "There is no need, for I am...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 6)//Goku was originally also only there for the Testlevel, but Jordy liked my idea and we added him to main game.
                {
                    fieryTale.spriteBatch.Draw(goku, new Vector2(990, 300), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Goku!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 7)
                {
                    fieryTale.spriteBatch.Draw(goku, new Vector2(990, 300), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You will be spending the beginning of your time in hell in Highschool, as a... test...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 8)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Goku seems to notice something and disappears.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 9)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I hear faint footsteps from behind me and turn around.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 10)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);//actually calculated this position based on size, size decided based on original image size
                    fieryTale.spriteBatch.DrawString(Names, "Demon girl:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Hey there! You must be new here.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 11)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Demon girl:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "My name is Anna Nishikinomiya, and I am the student council president of this high school.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 12)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "And who are you?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 13)
                {
                    fieryTale.spriteBatch.Draw(ren, new Rectangle(1024, 316, 256, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "My name is Ren Amamiya.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 14)//beginning of the thristing by Anna.
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Heyyy Ren, well it seems that this is your first day in hell, lemme give you a tour of the area.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 15)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I follow Anna around as she gives me a tour of the area.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 16)
                {
                    fieryTale.spriteBatch.DrawString(Names, "She first shows me all the classrooms.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 17)
                {
                    fieryTale.spriteBatch.DrawString(Names, "She then shows me around the library.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 18)
                {
                    fieryTale.spriteBatch.DrawString(Names, "She shows me around a small area of campus with shops,", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "restaurants, cafe's and other such things.", new Vector2(10, 610), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 640), Color.White);
                }
                if (fieryTale.gameMoment == 19)
                {
                    fieryTale.spriteBatch.DrawString(Names, "She then takes me to the dorms and shows me the dormroom I'll be staying in.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 20)
                {
                    fieryTale.spriteBatch.Draw(anna, new Rectangle(1080, 270, 200, 450), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Anna:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "This is where we part ways for today, see you around!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 21)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I watch Anna leave for her own dormroom.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 22)//background and music change moment, first of many
                {
                    fieryTale.spriteBatch.DrawString(Names, "I enter my dormroom and see it is meticulously furnished, but rather bland.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 23)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I remember I'm supposed to have a roommate but he seems to not be home.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 24)
                {
                    fieryTale.spriteBatch.DrawString(Names, "A wave of exhaustion washes over me.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 25)
                {
                    fieryTale.spriteBatch.Draw(ren, new Rectangle(1024, 316, 256, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Dying and going to Hell is a lot more exhausting than I'd expect, I should get some sleep.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 26)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I find the unoccupied bedroom and remember I have no change of clothes with me.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 27)//little nod to Persona as well, also fire
                {
                    fieryTale.spriteBatch.DrawString(Names, "But just as this thought crosses my mind, my clothes change in a flash of blue fire.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 28)//again, Persona reference. Also foreshadowing.
                {
                    fieryTale.spriteBatch.DrawString(Names, "It seems the rules of the Metaverse apply to Hell,", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "I don't even want to think about the implications of this.", new Vector2(10, 610), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 640), Color.White);
                }
                if (fieryTale.gameMoment == 29)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I crash down on my bed and fall asleep.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 30)//end of Day0, chance to keep listening to the chill music before moving on
                {
                    foreach (var button in buttons)//draws the button
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;//takes away control
                }
                fieryTale.spriteBatch.End();
            }
        }
    }
}

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
    //Goro romance ending is the true ending because Goro is best girl.
    public class TrueEnding : DrawableGameComponent
    {
        FieryTale fieryTale;

        private List<Button> epilogue;

        //fonts
        private SpriteFont Names;
        private SpriteFont Talking;

        //textures
        private Texture2D rennormal;
        private Texture2D joker;
        private Texture2D goku;
        private Texture2D textbox;
        private Texture2D dorm;
        private Texture2D library;
        private Texture2D velvet;
        private Texture2D bedroom;
        private Texture2D jazzclub;

        //Goro expressions
        private Texture2D goroneutral;
        private Texture2D gorosmiling;
        private Texture2D gorococky;
        private Texture2D goroshocked;
        private Texture2D gorosad;
        private Texture2D goroharmed;
        private Texture2D goromharmed;
        private Texture2D goromscowling; 
        private Texture2D goromupset;
        private Texture2D goromsmiling;
        private Texture2D goronaked;

        //sounds
        private SoundEffect drip;
        private SoundEffect kill;
        private SoundEffect loki;
        private SoundEffect arsene;
        private SoundEffect satanael;
        private Song combat;
        private Song sweet;
        private Song jazz;

        public TrueEnding(FieryTale fieryTale) : base(fieryTale)
        {
            this.fieryTale = fieryTale;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Honestly, maybe I am gay.
            rennormal = fieryTale.Content.Load<Texture2D>("RenNormal");
            joker = fieryTale.Content.Load<Texture2D>("Ren");
            goroneutral = fieryTale.Content.Load<Texture2D>("GoroNeutral");
            gorosmiling = fieryTale.Content.Load<Texture2D>("GoroSmiling");
            gorococky = fieryTale.Content.Load<Texture2D>("GoroCocky");
            gorosad = fieryTale.Content.Load<Texture2D>("GoroSad");
            goroshocked = fieryTale.Content.Load<Texture2D>("GoroShocked"); 
            goroharmed = fieryTale.Content.Load<Texture2D>("GoroHarmed");
            goromharmed = fieryTale.Content.Load<Texture2D>("GoroMHarmed");
            goromscowling = fieryTale.Content.Load<Texture2D>("GoroMScowling");
            goromupset = fieryTale.Content.Load<Texture2D>("GoroMUpset");
            goromsmiling = fieryTale.Content.Load<Texture2D>("GoroMSmiling");
            goronaked = fieryTale.Content.Load<Texture2D>("GoroNaked");
            goku = fieryTale.Content.Load<Texture2D>("Drip_Goku");
            dorm = fieryTale.Content.Load<Texture2D>("Dorm");
            library = fieryTale.Content.Load<Texture2D>("Library");
            velvet = fieryTale.Content.Load<Texture2D>("VelvetRoom"); 
            bedroom = fieryTale.Content.Load<Texture2D>("Bedroom");
            jazzclub = fieryTale.Content.Load<Texture2D>("JazzClub");
            textbox = fieryTale.Content.Load<Texture2D>("BlackRectangle");
            drip = fieryTale.Content.Load<SoundEffect>("DripSound");
            kill = fieryTale.Content.Load<SoundEffect>("Kill");
            loki = fieryTale.Content.Load<SoundEffect>("Loki");
            arsene = fieryTale.Content.Load<SoundEffect>("Arsene");
            satanael = fieryTale.Content.Load<SoundEffect>("Satanael");
            Names = fieryTale.Content.Load<SpriteFont>("Names");
            Talking = fieryTale.Content.Load<SpriteFont>("Talking");
            combat = fieryTale.Content.Load<Song>("Combat");
            sweet = fieryTale.Content.Load<Song>("Sweet"); 
            jazz = fieryTale.Content.Load<Song>("Jazz");

            //start Epilogue
            var epiloguebutton = new Button(fieryTale.Content.Load<Texture2D>("WhiteRectangle"), fieryTale.Content.Load<SpriteFont>("Names"), fieryTale)
            {
                ButtonPosition = new Vector2(0, 279),
                ButtonText = "Epilogue"
            };

            epiloguebutton.Click += Epiloguebutton_Click;

            epilogue = new List<Button>
            {
                epiloguebutton
            };

            base.LoadContent();
        }

        //epilogue button
        private void Epiloguebutton_Click(object sender, EventArgs e)
        {
            if (fieryTale.gameMoment == 102)
            {
                fieryTale.gameMoment++;
                fieryTale.choiceMoment = false;
                MediaPlayer.Stop();
                MediaPlayer.Play(jazz);
                MediaPlayer.Volume = 0.1f;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 9 && fieryTale.ending == 1 && fieryTale.goroRomance == true)
            {
                if (fieryTale.gameMoment == 50 && fieryTale.soundMoment == 0)
                {
                    drip.Play(0.1f, 0.0f, 0.0f);
                    fieryTale.soundMoment++;
                }
                if (fieryTale.gameMoment == 56 && fieryTale.soundMoment == 1)
                {
                    kill.Play();
                    fieryTale.soundMoment++;
                }
                if (fieryTale.gameMoment == 57 && fieryTale.soundMoment == 2)
                {
                    loki.Play();
                    fieryTale.soundMoment++;
                }
                if (fieryTale.gameMoment == 61 && fieryTale.soundMoment == 3)
                {
                    arsene.Play();
                    fieryTale.soundMoment++;
                }
                if (fieryTale.gameMoment == 74 && fieryTale.soundMoment == 4)
                {
                    satanael.Play();
                    fieryTale.soundMoment++;
                }

                foreach (var button in epilogue)
                    button.Update(gameTime);

                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (fieryTale.currentLevel == 9 && fieryTale.ending == 1 && fieryTale.goroRomance == true)
            {
                fieryTale.spriteBatch.Begin();

                //backgrounds
                if (fieryTale.gameMoment <= 6)
                {
                    fieryTale.spriteBatch.Draw(dorm, new Rectangle(0, 0, 1280, 760), Color.White);
                }
                else if (fieryTale.gameMoment > 6 && fieryTale.gameMoment <= 26 || fieryTale.gameMoment > 34 && fieryTale.gameMoment <= 92)
                {
                    fieryTale.spriteBatch.Draw(library, new Rectangle(0, 0, 1280, 720), Color.White);
                }
                else if (fieryTale.gameMoment > 26 && fieryTale.gameMoment <= 34)
                {
                    fieryTale.spriteBatch.Draw(velvet, new Rectangle(0, 0, 1280, 720), Color.White);
                }
                else if (fieryTale.gameMoment > 92 && fieryTale.gameMoment <= 102)
                {
                    fieryTale.spriteBatch.Draw(bedroom, new Rectangle(0, 0, 1280, 720), Color.White);
                }
                else
                {
                    fieryTale.spriteBatch.Draw(jazzclub, new Rectangle(0, 0, 1280, 720), Color.White);
                }

                //textbox
                fieryTale.spriteBatch.Draw(textbox, new Rectangle(0, 520, 1280, 200), Color.Black * 0.6f);

                //scenes
                if (fieryTale.gameMoment == 0)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I wake up, Goro's arms are still around me. We have a free day today.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 1)
                {
                    fieryTale.spriteBatch.Draw(goronaked, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Good morning, my love.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 2)
                {
                    fieryTale.spriteBatch.DrawString(Names, "We decide to stay in bed a little longer and cuddle.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 3)
                {
                    fieryTale.spriteBatch.DrawString(Names, "After a while, which is still far too short, we get up.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 4)
                {
                    fieryTale.spriteBatch.DrawString(Names, "We eat breakfast, together.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 5)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Then we take a shower, together.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 6)//look I wouldn't do any studying on a day like this, but we need to move the plot forward
                {
                    fieryTale.spriteBatch.DrawString(Names, "And then we decide to go to the library to study, together.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 7)
                {
                    fieryTale.spriteBatch.DrawString(Names, "As we sit there, Goro suddenly kicks me under the table to get my attention.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 8)
                {
                    fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Psst, look over there. Isn't Mr Care acting sketchy?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 9)//Goro was a detective. He was so good they called him the detective prince. Second detective prince actually, but that's for another time.
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Are your Detective Prince senses tingling, darling?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 10)
                {
                    fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Oh shut it, just look.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 11)//god I hate myself for using the word sus here
                {
                    fieryTale.spriteBatch.DrawString(Names, "I look over to where Goro is looking. He's right, Mr Care is acting kinda sus.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 12)//AMOGUS! I wanna kms
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You're right, he's kinda sussy. We should follow him.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 13)
                {
                    fieryTale.spriteBatch.Draw(gorococky, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I was going to suggest exactly that. Great minds think alike, it seems.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 14)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Our time in the Metaverse has made us experts at stealth.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 15)
                {
                    fieryTale.spriteBatch.DrawString(Names, "We easily shadow Mr Care as he moves through the library.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 16)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Eventually he stops infront of a weird door.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 17)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I've not seen that door before, you?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 18)
                {
                    fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "No, I can't say I have. Let's see what he does now.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 19)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Mr Care does something to open the door.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 20)
                {
                    fieryTale.spriteBatch.DrawString(Names, "We swiftly and quitely follow him through before it closes.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 21)//In the metaverse Ren and the gang can literally fade into the shadows and become undetectable. Actual shadows, not the monsters that are also called Shadows.
                {
                    fieryTale.spriteBatch.DrawString(Names, "He notices something, but we are able to fade into the shadows.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 22)
                {
                    fieryTale.spriteBatch.Draw(gorococky, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Oh how I've missed sneaking around like this.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 23)
                {
                    fieryTale.spriteBatch.DrawString(Names, "We've ended up in a big circular room filled with bookcases and display stands.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 24)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Most display stands are empty. The ones that aren't, house seemingly mundane objects.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 25)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Things like trophies for sporting events.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 26)
                {
                    fieryTale.spriteBatch.DrawString(Names, "We easily sneak around the room until we reach a door on the left side.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 27)
                {
                    fieryTale.spriteBatch.DrawString(Names, "As we enter I'm met with a familiar sight.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 28)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "W-what? We're in the Velvet Room?!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 29)//not actually certain if Goro has seen the Velvet Room, oh well.
                {
                    fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "No, I think this is just a very well-made copy.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 30)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You're probably right. This must be where Goku spoke with me during those dreams.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 31)
                {
                    fieryTale.spriteBatch.Draw(goroshocked, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Where who spoke with you?!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 32)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I explain to Goro everything I know about Goku and this place.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 33)
                {
                    fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Hmm, I see. The plot thickens it seems.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 34)
                {
                    fieryTale.spriteBatch.DrawString(Names, "We decide to leave the fake Velvet Room and continue exploring.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 35)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Back in the main room, we sneak around the outside until we come across another door.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 36)
                {
                    fieryTale.spriteBatch.DrawString(Names, "We enter into a giant room filled with items.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 37)//Goku got the drip
                {
                    fieryTale.spriteBatch.DrawString(Names, "Adorning the room are multiple articles that contain high levels of drip.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 38)//the dragon balls
                {
                    fieryTale.spriteBatch.DrawString(Names, "There are mutliple amber coloured balls with stars inside of them on pedestals.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 39)//the capsule that Goku came to earth in. Havent actually watched the show but Jordy has
                {
                    fieryTale.spriteBatch.DrawString(Names, "There is also a weird capsule like object.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 40)
                {
                    fieryTale.spriteBatch.DrawString(Names, "In the middle of the room, on a beautiful pedestal, there lies a golden drip jacket.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 41)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "W-Wait, is that...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 42)
                {
                    fieryTale.spriteBatch.Draw(goroshocked, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "It's a treasure! We're inside of a palace! But who's?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 43)//Ren Amamiya, ace detective
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "That looks like Goku's jacket. So my best guess is that this is Goku's palace.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 44)
                {
                    fieryTale.spriteBatch.Draw(gorosad, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "So, this isn't actually Hell...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 45)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "No I guess not. This being inside of the Metaverse does explain a lot.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 46)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "But, if this isn't actually Hell...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 47)//"Nose bleeds from epiphanies I took full in the face."
                {
                    fieryTale.spriteBatch.DrawString(Names, "The realisation hits me like a brick.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 48)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I turn to Goro, he has realised it as well.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 49)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Before either of us can speak however, a voice rings out behind us.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 50)
                {
                    fieryTale.spriteBatch.Draw(goku, new Vector2(990, 300), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I'm sorry you had to find out this way, Ren.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 51)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "N-No, don't you dare!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 52)//I added that second line to make it clear that the real Goro would act the same way as this Goro has.
                {
                    fieryTale.spriteBatch.Draw(goku, new Vector2(990, 300), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "The real Goro is dead, Ren. That Goro is just a cognition in my palace.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "He is exactly like the real one, but not actually real.", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 53)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "No...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 54)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I'm in tears. I drop to my knees. Everything is hazy, spinning.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 55)
                {
                    fieryTale.spriteBatch.Draw(goroharmed, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "You...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 56)//Goro changes into his Metaverse outfit
                {
                    fieryTale.spriteBatch.Draw(goromharmed, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "YOU SON OF A BITCH! I WILL KILL YOU!", new Vector2(10, 580), Color.White);
                    if (fieryTale.songPlaying == true)
                    {
                        MediaPlayer.Stop();
                        MediaPlayer.Play(combat);
                        MediaPlayer.Volume = 0.1f;
                        fieryTale.songPlaying = false;
                    }
                }
                if (fieryTale.gameMoment == 57)//Goro's Persona
                {
                    fieryTale.spriteBatch.Draw(goromscowling, new Rectangle(980, 340, 400, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "LOKI!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 58)
                {
                    fieryTale.spriteBatch.DrawString(Names, "With that, Goro engages Goku. I watch on, paralyzed by my emotions.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 59)
                {
                    fieryTale.spriteBatch.DrawString(Names, "They exchange blow by blow, but Goku is clearly stronger.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 60)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Their fight still raging on, I slowly get myself under control.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 61)//while Arsene is technically the weakest Persona when you get him, but he can become quite powerful through some hard work
                {
                    fieryTale.spriteBatch.DrawString(Names, "I rip off my mask and summon Arsene from the sea of my soul.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 62)
                {
                    fieryTale.spriteBatch.Draw(joker, new Rectangle(1024, 316, 256, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Lets do this!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 63)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Goro and I fight side by side against Goku.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 64)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I summon Persona upon Persona, but all of them seem to do nothing.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 65)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Goku is far too powerful.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 66)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I'm hit with a blast of energy and fall to the floor.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 67)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Goro falls down next to me, severely injured.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 68)
                {
                    fieryTale.spriteBatch.Draw(goromupset, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I-I'm sorry, Ren.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 69)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Goddammit, it can't end like this. I won't let it fucking end like this!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 70)
                {
                    fieryTale.spriteBatch.Draw(goromupset, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Y-You can do it...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 71)
                {
                    fieryTale.spriteBatch.Draw(goromsmiling, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I believe in you... I love you, Ren.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 72)//Satanael is actually from the Fool Arcana in-game, but as Ren's ultimate Persona, I'd like to think he'd normally be world.
                {
                    fieryTale.spriteBatch.DrawString(Names, "Empowered by Goro's trust in me, I engage in one final act of rebellion.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "I call upon the World Arcana...", new Vector2(10, 610), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 640), Color.White);
                }
                if (fieryTale.gameMoment == 73)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I break Arsene's chains of captivity (again) and summon forth my ultimate Persona...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 74)
                {
                    fieryTale.spriteBatch.Draw(joker, new Rectangle(1024, 316, 256, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Satanael!", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 75)//satanael has a big-ass gun and literally shoots God in the face.
                {
                    fieryTale.spriteBatch.DrawString(Names, "As I aim my gun at Goku, Satanael does the same. We pull the trigger.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 76)//a bullet made from the 7 deadly sins, can pierce Gods.
                {
                    fieryTale.spriteBatch.DrawString(Names, "Satanael's Sinful Shell pierces Goku, severely wounding him.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 77)
                {
                    fieryTale.spriteBatch.Draw(goku, new Vector2(990, 300), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goku:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Well... Done...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 78)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I did it... We did it!", new Vector2(10, 580), Color.White);
                    if (fieryTale.songPlaying == false)
                    {
                        MediaPlayer.Stop();
                        MediaPlayer.Play(sweet);
                        MediaPlayer.Volume = 0.1f;
                        fieryTale.songPlaying = true;
                    }
                }
                if (fieryTale.gameMoment == 79)
                {
                    fieryTale.spriteBatch.Draw(gorosmiling, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Of course you did, my love. Never a doubt in my mind.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 80)//A treasure is the physical manifestation of a Palace rulers distorted desires. Steal it and the palace collapses
                {
                    fieryTale.spriteBatch.Draw(goroneutral, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Now, take his treasure, like you've done so many times before, and end this.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 81)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "B-But then...", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 82)
                {
                    fieryTale.spriteBatch.Draw(gorosad, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I know. But you heard Goku, I'm not real. You destroyed one fake reality where I was alive,", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "you can do it again. I won't let you live a lie.", new Vector2(10, 600), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 620), Color.White);
                }
                if (fieryTale.gameMoment == 83)
                {
                    fieryTale.spriteBatch.Draw(gorosmiling, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I'm just happy I got to spend this time, no matter how short it was, with you.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, ">", new Vector2(10, 600), Color.White);
                }
                if (fieryTale.gameMoment == 84)
                {
                    fieryTale.spriteBatch.Draw(gorosmiling, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "I love you, Ren. Live your life, for me, please.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 85)
                {
                    fieryTale.spriteBatch.DrawString(Names, "He gives me one last, gentle kiss. As soft as the first.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 86)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I want to stay like this forever, but Goro was always stronger than me.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 87)
                {
                    fieryTale.spriteBatch.DrawString(Names, "He pulls away, gives me one last warm smile.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 88)
                {
                    fieryTale.spriteBatch.Draw(gorosmiling, new Rectangle(1000, 340, 380, 380), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Goro:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Thank you.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 89)//cognitive beings and shadows fade into nothingness when killed.
                {
                    fieryTale.spriteBatch.DrawString(Names, "He fades away, like all cognitions after they're killed.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 90)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Goodbye, Goro. I'll always love you.", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 91)
                {
                    fieryTale.spriteBatch.DrawString(Names, "What happened after is a blur.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 92)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I remember grabbing the treasure and running as the Metaverse collapsed around me.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 93)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Then... I wake up at home, in bed.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 94)
                {
                    fieryTale.spriteBatch.DrawString(Names, "In my hand, Goku's treasure. It's... a card?", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 95)//oh my, what could that be hmmmmmmm
                {
                    fieryTale.spriteBatch.DrawString(Names, "'For defeating me, I give you one final gift.' ~Goku", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 96)
                {
                    fieryTale.spriteBatch.Draw(rennormal, new Rectangle(1000, 316, 380, 404), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "Ren:", new Vector2(10, 540), Color.White);
                    fieryTale.spriteBatch.DrawString(Talking, "Gift? What gift?", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 97)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I hear Morgana call my name, he seems confused.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 98)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I explain to him what happened, sort of, then we head to school.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 99)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I had to move back home to finish Highschool, but I'm not planning on staying.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 100)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Just a little longer, then I'll return to Tokyo, to all my friends.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 101)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Well... almost all of them", new Vector2(10, 580), Color.White);
                }
                if (fieryTale.gameMoment == 102)
                {
                    foreach (var button in epilogue)
                        button.Draw(gameTime);
                    fieryTale.choiceMoment = true;
                }
                if (fieryTale.gameMoment == 103)//big time skip, just because
                {
                    fieryTale.spriteBatch.DrawString(Names, "It's been over a year since Goku's palace.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 104)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I've returned to Tokyo to go to university.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 105)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I'm renting a small, but comfortable, apartment.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 106)//Morgana is a good friend, always coming with Ren
                {
                    fieryTale.spriteBatch.DrawString(Names, "It's only me and Morgana in there, but that's fine.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 107)//simp cat
                {
                    fieryTale.spriteBatch.DrawString(Names, "Today's Valentine's day, Morgana has gone off to try and woo Ann, again.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 108)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I've tried telling him she isn't interested in cats, but he never listens.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 109)//name of the Jazz Club in P5R
                {
                    fieryTale.spriteBatch.DrawString(Names, "I'm sitting in Jazz Jinn, alone.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 110)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I still remember the first time Goro took me here.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 111)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I still remember every moment I spent with Goro.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 112)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I think about them, about him, all the time.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 113)//Goro threw his glove at Ren to challenge him to a duel.
                {
                    fieryTale.spriteBatch.DrawString(Names, "I still have his glove. I carry it with me everywhere. A small memento.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 114)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I also still have Goku's treasure, the card.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 115)
                {
                    fieryTale.spriteBatch.DrawString(Names, "'one final gift.' I still have no idea what that means.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 116)
                {
                    fieryTale.spriteBatch.DrawString(Names, "The live entertainer is here today.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, "The same one that sang the first time Goro took me here.", new Vector2(10, 610), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 640), Color.White);
                }
                if (fieryTale.gameMoment == 117)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I sit there for a while, just zoning out.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 118)
                {
                    fieryTale.spriteBatch.DrawString(Names, "Drinking my drinks, losing myself in the music, fidgeting with Goro's glove.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 119)
                {
                    fieryTale.spriteBatch.DrawString(Names, "I don't know how much time has passed, but something snaps me out of it.", new Vector2(10, 580), Color.White);
                    fieryTale.spriteBatch.DrawString(Names, ">", new Vector2(10, 610), Color.White);
                }
                if (fieryTale.gameMoment == 120)//oh my who could that be hmmmmmm.
                {
                    fieryTale.spriteBatch.DrawString(Names, "A familiar figure sits down infront of me. A familiar voice speaks to me.", new Vector2(10, 580), Color.White);
                }


                fieryTale.spriteBatch.End();
            }
        }
    }
}

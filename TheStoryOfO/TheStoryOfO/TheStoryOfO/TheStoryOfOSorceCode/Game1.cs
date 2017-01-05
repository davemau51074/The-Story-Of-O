using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TheStoryOfO
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player thePlayer;
        Enemy enemyOne;
        Rectangle sourceRectangle;
        Rectangle destinationRectangle;
        Rectangle[] collisionRectangles = new Rectangle[53];
        Texture2D backGround, test;
        SpriteFont spriteFont;
        KeyboardState previousKeyboardState;
        KeyboardState keyboardState;
        int screenWidth;
        int screenHeight;
        int lastX;
        int lastY;
        string message;
        Vector2 messageVector = new Vector2(100, 100);
        Vector2 lastPos = new Vector2(0, 0);
        SoundEffect backgroundSong;
        SoundEffect deathSound;
        SoundEffect jumpSound;
        SoundEffect slowBassSound;
        SoundEffect spareSound;
        SoundEffectInstance mainSong;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;
            thePlayer = new Player();
            sourceRectangle = new Rectangle();
            keyboardState = Keyboard.GetState();
            enemyOne = new Enemy(30 - sourceRectangle.X, 60 - sourceRectangle.Y);
            destinationRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            collisionRectangles[1] = new Rectangle(0, 1079, 167, 212);
            collisionRectangles[2] = new Rectangle (137, 1064, 30, 16);
            collisionRectangles[3] = new Rectangle (263, 1080, 50, 23);
            collisionRectangles[4] = new Rectangle (168, 1080, 96, 48);
            collisionRectangles[5] = new Rectangle (163, 1279,265, 102);
            collisionRectangles[6] = new Rectangle (216, 1179, 210, 70);
            collisionRectangles[7] = new Rectangle (216, 1175 , 207, 66);
            collisionRectangles[8] = new Rectangle (327, 1143, 96, 33);
            collisionRectangles[9] = new Rectangle (407, 832, 18, 248);
            collisionRectangles[10] = new Rectangle (415, 1370, 80, 58);
            collisionRectangles[11] = new Rectangle (481, 1017, 216, 357);
            collisionRectangles[12] = new Rectangle (560, 977, 104, 58);
            collisionRectangles[13] = new Rectangle (607, 943, 57, 35);
            collisionRectangles[14] = new Rectangle (663, 1000, 264, 176);
            collisionRectangles[15] = new Rectangle (703, 942, 65, 82);
            collisionRectangles[16] = new Rectangle (766, 1000,50, 25);
            collisionRectangles[17] = new Rectangle (815, 944, 65, 79);
            collisionRectangles[18] = new Rectangle (878, 984, 62, 33);
            collisionRectangles[19] = new Rectangle (926, 1014, 55, 60);
            collisionRectangles[20] = new Rectangle (976, 1063, 48, 46);
            collisionRectangles[21] = new Rectangle (1023, 1103, 67, 72);
            collisionRectangles[22] = new Rectangle (1087, 1063, 345, 112);
            collisionRectangles[23] = new Rectangle (1136, 1023, 167, 42);
            collisionRectangles[24] = new Rectangle (1190, 984, 115, 40);
            collisionRectangles[25] = new Rectangle (1241, 943, 73, 122);
            collisionRectangles[26] = new Rectangle (1360, 944, 73, 122);
            collisionRectangles[27] = new Rectangle (1503, 944, 80, 231);
            collisionRectangles[28] = new Rectangle (1575, 1080, 91, 94);
            collisionRectangles[29] = new Rectangle (1663, 951, 385, 224);
            collisionRectangles[30] = new Rectangle(365, 1050, 60, 100);
            collisionRectangles[31] = new Rectangle(936, 1408, 1110, 180);
            collisionRectangles[32] = new Rectangle(825, 1432, 122, 57);
            collisionRectangles[33] = new Rectangle(480, 1176, 94, 872);
            collisionRectangles[34] = new Rectangle(576, 1536, 136, 55);
            collisionRectangles[35] = new Rectangle(936, 1409, 88, 367);
            collisionRectangles[36] = new Rectangle(824, 1656, 112, 64);
            collisionRectangles[37] = new Rectangle(576, 1832, 111, 56);
            collisionRectangles[38] = new Rectangle(800, 1977, 441, 47);
            collisionRectangles[39] = new Rectangle(1050, 1929, 191, 49);
            collisionRectangles[40] = new Rectangle(1048, 1929, 191, 49);
            collisionRectangles[41] = new Rectangle(1096, 1879, 144, 57);
            collisionRectangles[42] = new Rectangle(1145, 1815, 120, 68);
            collisionRectangles[43] = new Rectangle(1200, 1760, 40, 80);
            collisionRectangles[44] = new Rectangle(1273, 1697, 103, 22);
            collisionRectangles[45] = new Rectangle(1432, 1696, 88, 33);
            collisionRectangles[46] = new Rectangle(1569, 1728, 47, 320);
            collisionRectangles[47] = new Rectangle(1696, 1737, 49, 311);
            collisionRectangles[48] = new Rectangle(1816, 1744, 56, 304);
            collisionRectangles[49] = new Rectangle(1953, 1752, 95, 256);
            collisionRectangles[50] = new Rectangle(2032,  1300, 16, 895);
            collisionRectangles[51] = new Rectangle(1665, 800, 380, 225);
            collisionRectangles[52] = new Rectangle(2032, 710, 16, 259);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            thePlayer.LoadContent(this.Content, "O");
            enemyOne.LoadContent(this.Content, "A");
            backGround = this.Content.Load<Texture2D>("Level 1");
            sourceRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            test = Content.Load<Texture2D>("test");
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");
            backgroundSong = Content.Load<SoundEffect>("PianoBackGround");
            deathSound = Content.Load<SoundEffect>("DirtySnare");
            jumpSound = Content.Load<SoundEffect>("FastBass");
            mainSong = backgroundSong.CreateInstance();
            mainSong.IsLooped = true;

            // TODO: use this.Content to load your game content here
           mainSong.Play();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState previousKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            bool moveWindow = thePlayer.Update(previousKeyboardState, keyboardState, collisionRectangles, sourceRectangle);

            if(moveWindow == true)
            {
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    sourceRectangle.X -= 5;
                }
                else if (keyboardState.IsKeyDown(Keys.Right))
                {
                    sourceRectangle.X += 5;
                }
                else if (thePlayer.position.Y <= 200)
                {   
                    sourceRectangle.Y -= 5;
                }   
                else if (thePlayer.position.Y >= 400)
                {
                    sourceRectangle.Y += 5;
                }
              
            }
            message = "" + (thePlayer.Position.X + sourceRectangle.X) + " , " + (thePlayer.Position.Y + sourceRectangle.Y);
            CheckCollision();

            if((sourceRectangle.X == lastX && sourceRectangle.Y == lastY) == false)
            {
                for (int count = 0; count < collisionRectangles.Length; count++)
                {
                    collisionRectangles[count].X = collisionRectangles[count].X + lastX - sourceRectangle.X;
                    collisionRectangles[count].Y = collisionRectangles[count].Y + lastY - sourceRectangle.Y;
                }  
            }

            lastX = sourceRectangle.X;
            lastY = sourceRectangle.Y;
            
            enemyOne.position = new Vector2(0 - sourceRectangle.X, 0 - sourceRectangle.Y);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(backGround, destinationRectangle, sourceRectangle, Color.White);
            enemyOne.Draw(spriteBatch);
            thePlayer.Draw(spriteBatch, spriteFont);
            spriteBatch.DrawString(spriteFont, message, messageVector, Color.Blue);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void CheckCollision()
        {
            for (int count = 0; count < collisionRectangles.Length; count++)
            {
                if (collisionRectangles[count].X < thePlayer.Position.X && collisionRectangles[count].X + collisionRectangles[count].Width > thePlayer.Position.X && collisionRectangles[count].Y < thePlayer.Position.Y && collisionRectangles[count].Y + collisionRectangles[count].Height > thePlayer.Position.Y)
                {
                    thePlayer.position.Y = collisionRectangles[count].Y;
                }
            }
        }
    }
}

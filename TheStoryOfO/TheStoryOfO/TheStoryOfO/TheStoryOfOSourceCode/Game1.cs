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
        Rectangle[] collisionRectangles = new Rectangle[15];
        Texture2D backGround;
        int screenWidth;
        int screenHeight;
        float scalingFactor;

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
            enemyOne = new Enemy(300 - sourceRectangle.X, 600 - sourceRectangle.Y);
            destinationRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            collisionRectangles[0] = new Rectangle(0 - sourceRectangle.X, 376 - sourceRectangle.Y, 336, 98);
            collisionRectangles[1] = new Rectangle(367 - sourceRectangle.X, 376 - sourceRectangle.Y, 297, 106);
            collisionRectangles[2] = new Rectangle(497 - sourceRectangle.X, 352 - sourceRectangle.Y, 94, 40);
            collisionRectangles[3] = new Rectangle(528 - sourceRectangle.X, 328 - sourceRectangle.Y, 41, 31);
            collisionRectangles[4] = new Rectangle(664 - sourceRectangle.X, 392 - sourceRectangle.Y, 16, 20);
            collisionRectangles[5] = new Rectangle(680 - sourceRectangle.X, 408 - sourceRectangle.Y, 16, 19);
            collisionRectangles[6] = new Rectangle(695 - sourceRectangle.X, 424 - sourceRectangle.Y, 105, 74);
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
            backGround = this.Content.Load<Texture2D>("Test background");
            sourceRectangle = new Rectangle(0, 0, backGround.Width / 2, backGround.Height / 2);

            // TODO: use this.Content to load your game content here
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
            KeyboardState keyboardState = Keyboard.GetState();

            bool moveWindow = thePlayer.Update(keyboardState, collisionRectangles);
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
                else if (keyboardState.IsKeyDown(Keys.Up))
                {   
                    sourceRectangle.Y -= 5;
                }   
                else if (keyboardState.IsKeyDown(Keys.Down))
                {
                    sourceRectangle.Y += 5;
                }
            }
            for (int count = 0; count < collisionRectangles.Length; count++)
            {
                collisionRectangles[count].X -= sourceRectangle.X;
                collisionRectangles[count].Y -= sourceRectangle.Y;
            }
            
            enemyOne.position = new Vector2(0 - sourceRectangle.X, 0 - sourceRectangle.Y);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(backGround, destinationRectangle, sourceRectangle, Color.White);
            enemyOne.Draw(spriteBatch);
            thePlayer.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void CheckCollision()
        {

        }
    }
}

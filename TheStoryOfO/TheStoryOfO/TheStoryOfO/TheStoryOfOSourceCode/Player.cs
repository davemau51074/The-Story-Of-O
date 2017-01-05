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
    class Player
    {
        Vector2 position;
        Texture2D sprite;

        public Player()
        {
            position = new Vector2(100, 100);
        }

        //Load Content method for the player class
        public void LoadContent(ContentManager theContentManager, string asset)
        {
            sprite = theContentManager.Load<Texture2D>(asset);
        }

        //Update method for the player class
        public bool Update(KeyboardState keyboardState, Rectangle[] rectangles)
        {
            bool returnValue = true;
            if (true)
            {
                if (keyboardState.IsKeyDown(Keys.Left) && position.X > 100)
                {
                    position.X -= 5;
                    returnValue = false;
                }
                if (keyboardState.IsKeyDown(Keys.Right) && position.X < 450)
                {
                    position.X += 5;
                    returnValue = false;
                }
                if (keyboardState.IsKeyDown(Keys.Up) && position.Y > 100)
                {
                    position.Y -= 5;
                    returnValue = false;
                }
                if (keyboardState.IsKeyDown(Keys.Down) && position.Y < 350)
                {
                    position.Y += 5;
                    returnValue = false;
                }
            }
            return returnValue;
        }

        //Draw methopd for the player class
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}

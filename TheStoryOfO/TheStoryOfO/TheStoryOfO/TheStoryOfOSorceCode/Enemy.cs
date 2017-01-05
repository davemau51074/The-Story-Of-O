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
    class Enemy
    {
        //Declare Variables
        public Vector2 position;
        Texture2D sprite;


        //Default Constructor
        public Enemy(int x, int y)
        {
            position = new Vector2(x, y);
        }

        public void LoadContent(ContentManager theContentManager, string asset)
        {
            sprite = theContentManager.Load<Texture2D>(asset);
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(sprite, position, Color.White);
        }
    }
}

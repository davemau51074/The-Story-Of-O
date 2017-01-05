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
        public Vector2 currentPosition;
        public Vector2 startingPosition;
        Texture2D sprite;
        int movementSpeed = 3;
        int direction;
        Random randGen = new Random();


        //Default Constructor
        public Enemy(int x, int y)
        {
            currentPosition = new Vector2(x, y);
        }

        public void Movement(int destinationLeft, int destinationRight)
        {
            //enemies are to patrol a small area
            direction = randGen.Next(0, 2);
            if (direction == 0)
            {
                for (startingPosition.X = currentPosition.X; currentPosition.X >= destinationLeft; currentPosition.X -= movementSpeed)
                {
                    //currentPosition.X -= movementSpeed;
                    //if (currentPosition <= destinationLeft)
                    //{  
                    //    direction == 1;
                    //}
                }
          
                
            }

            else if (direction == 1)
            {
                for (startingPosition.X = currentPosition.X; currentPosition.X <= destinationRight; currentPosition.X += movementSpeed)
                {
                    ////currentPosition.X -= movementSpeed;
                    //if (currentPosition <= destinationLeft)
                    //{
                    //    direction == 0;
                    //}
                }
                //while (currentPosition.X < destinationLeft)
                //{
                //    currentPosition.X += movementSpeed;
                //}
            }
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
            theSpriteBatch.Draw(sprite, currentPosition, Color.White);
        }
    }
}

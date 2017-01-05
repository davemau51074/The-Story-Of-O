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
        int stage = 0;
        bool showWinMessage = false;
        string winMessage = "You Win";
        Vector2 winLocation = new Vector2(600, 300);
        public bool jumping = false;
        public Vector2 position;
        public Vector2 gravity = new Vector2(0, 2);
        public Vector2 left = new Vector2(-5, 0);
        public Vector2 right = new Vector2(5, 0);
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 xeroV = new Vector2(0, 0);
        public Vector2 jump = new Vector2(0, -20);
        Texture2D sprite;
        public bool returnValue = true;
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
        public bool Update(KeyboardState previousKeyboardState, KeyboardState keyboardState, Rectangle[] rectangles, Rectangle sourceRectangle)
        {
            
            bool returnValue = true;
            if(position.X > (1960 - sourceRectangle.X) && position.X < (2015 - sourceRectangle.X))
            {
                showWinMessage = true;
            }
            //if(position.X > (432 -  sourceRectangle.X) && position.X < (472 - sourceRectangle.X))
            //{
            //    jump = new Vector2(0, -80);
            //}
            else
            {
                jump = new Vector2(0, -20);
            }
                if (keyboardState.IsKeyDown(Keys.Left) && position.X > 330)
                {
                   // returnValue = false;
                    velocity = left;
                }
                else if (keyboardState.IsKeyDown(Keys.Right) && position.X < 450)
                {
                    //returnValue = false;
                    velocity = right;
                }
                else
                {
                    velocity = xeroV;
                }
                if (keyboardState.IsKeyDown(Keys.Space) && previousKeyboardState.IsKeyDown(Keys.Space) == false && jumping == false)
                {
                    jumping = true;
                    stage = 1;
                }
                position += velocity;
                switch (stage)
                {
                    case 1:
                        position += (jump);
                        stage = 2;
                        break;
                    case 2:
                        position += (jump + gravity);
                        stage = 3;
                        break;
                    case 3:
                        position += (jump + gravity * 2);
                        stage = 4;
                        break;
                    case 4:
                        position += (jump + (gravity * 3));
                        stage = 5;
                        break;
                    case 5:
                        position += (jump + (gravity * 4));
                        stage = 6;
                        break;
                    case 6:
                        stage = 7;
                        break;
                    case 7:
                        stage = 8;
                        break;
                    case 8:
                        position += (gravity);
                        stage = 9;
                        break;
                    case 9:
                        position += (gravity * 2);
                        stage = 10;
                        break;
                    case 10:
                        position += (gravity * 3);
                        stage = 11;
                        break;
                    case 11:
                        position += (gravity * 4);
                        break;
                    default:
                        position += gravity * 4;
                        break;
                }
            return returnValue;
        }

        //Draw methopd for the player class
        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            spriteBatch.Draw(sprite, position - new Vector2(20, 40), Color.White);
            if(showWinMessage)
            {
                spriteBatch.DrawString(spriteFont, winMessage, winLocation, Color.Black);
                
            }
        }

        public Vector2 Position
        {
            get { return position; }

        }
    }
}


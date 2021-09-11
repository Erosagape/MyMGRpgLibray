using System;
using System.Collections.Generic;
using System.Text;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;
using MGRpgLibrary.TileEngine;
using MGRpgLibrary.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
namespace MGRpgLibrary.WorldClasses
{
    public class World
    {
        Rectangle screenRect;
        public Rectangle ScreenRectangle
        {
            get { return screenRect; }
        }
        ItemManager itemManager = new ItemManager();
        public World(Rectangle screen)
        {
            screenRect = screen;
        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {

        }
    }
}

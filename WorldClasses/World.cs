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
    public class World : DrawableGameComponent
    {
        Rectangle screenRect;
        public Rectangle ScreenRectangle
        {
            get { return screenRect; }
        }
        ItemManager itemManager = new ItemManager();
        readonly List<Level> levels = new List<Level>();
        public List<Level> Levels
        {
            get { return levels; }
        }
        int currentLevel = -1;
        public int CurrentLevel
        {
            get { return currentLevel; }
            set
            {
                if (value < 0 || value >= levels.Count)
                    throw new IndexOutOfRangeException();
                if (levels[value] == null)
                    throw new NullReferenceException();
                currentLevel = value;
            }
        }
        public World(Game game,Rectangle screen) : base(game)
        {
            screenRect = screen;
        }
        public override void Update(GameTime gameTime)
        {

        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        public void DrawLevel(GameTime gameTime,SpriteBatch spriteBatch,Camera camera)
        {
            levels[currentLevel].Draw(gameTime,spriteBatch, camera);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MGRpgLibrary.TileEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MGRpgLibrary.WorldClasses
{
    public class Level
    {
        readonly TileMap map;
        public TileMap Map
        {
            get { return map; }
        }
        public Level(TileMap tileMap)
        {
            map = tileMap;
        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch,Camera camera)
        {
            map.Draw(spriteBatch, camera);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MGRpgLibrary.TileEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MGRpgLibrary.CharacterClasses;
using MGRpgLibrary.ItemClasses;

namespace MGRpgLibrary.WorldClasses
{
    public class Level
    {
        readonly TileMap map;
        public TileMap Map
        {
            get { return map; }
        }
        readonly List<Character> characters;
        public List<Character> Characters => characters;
        readonly List<ItemSprite> chests;
        public List<ItemSprite> Chests => chests;
        public Level(TileMap tileMap)
        {
            map = tileMap;
            characters = new List<Character>();
            chests = new List<ItemSprite>();
        }
        public void Update(GameTime gameTime)
        {
            foreach (Character character in characters)
                character.Update(gameTime);
            foreach (ItemSprite chest in chests)
                chest.Update(gameTime);
        }
        public void Draw(GameTime gameTime,SpriteBatch spriteBatch,Camera camera)
        {
            map.Draw(spriteBatch, camera);
            foreach (Character character in characters)
                character.Draw(gameTime, spriteBatch);
            foreach (ItemSprite chest in chests)
                chest.Draw(gameTime, spriteBatch);
        }
    }
}

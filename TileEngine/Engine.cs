using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
namespace MGRpgLibrary.TileEngine
{
    public class Engine
    {
        static int tileWidth;
        public static int TileWidth
        {
            get { return tileWidth; }
        }
        static int tileHeight;
        public static int TileHeight
        {
            get { return tileHeight; }
        }
        public Engine(int tileWidth,int tileHeight)
        {
            Engine.tileWidth = tileWidth;
            Engine.tileHeight = tileHeight;
        }
        public static Point VectorToCell(Vector2 position)
        {
            if (tileWidth == 0)
                tileWidth = 1;
            if (tileHeight == 0)
                tileHeight = 1;
            return new Point((int)position.X / tileWidth, (int)position.Y / tileHeight);
        }
    }
}

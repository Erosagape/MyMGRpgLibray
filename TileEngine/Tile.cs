using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.TileEngine
{
    public class Tile
    {
        int tileIndex;
        public int TileIndex
        {
            get { return tileIndex; }
            private set { tileIndex = value; }
        }
        int tileset;
        public int TileSet
        {
            get { return tileset; }
            private set { tileset = value; }
        }
        public Tile(int tileidx,int tileset)
        {
            this.tileIndex = tileidx;
            this.tileset = tileset;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MGRpgLibrary.TileEngine
{
    public class TileSet
    {
        Texture2D image;
        public Texture2D Texture
        {
            get { return image; }
            private set { image = value; }
        }
        int tileWidthInPixels;
        public int TileWidth
        {
            get { return tileWidthInPixels; }
            private set { tileWidthInPixels = value; }
        }
        int tileHeightInPixels;
        public int TileHeight
        {
            get { return tileHeightInPixels; }
            private set { tileHeightInPixels = value; }
        }
        int tilesWide;
        public int TilesWide
        {
            get { return tilesWide; }
            private set { tilesWide = value; }
        }
        int tilesHigh;
        public int TilesHigh
        {
            get { return tilesHigh; }
            private set { tilesHigh = value; }
        }
        Rectangle[] sourceRectangles;
        public Rectangle[] SourceRectangle
        {
            get { return (Rectangle[])sourceRectangles.Clone(); }
        }
        public TileSet(
            Texture2D img,
            int tilesW,
            int tilesH,
            int tileW,
            int tileH
            )
        {
            Texture = img;
            TileWidth = tileW;
            TileHeight = tileH;
            tilesWide = tilesW;
            tilesHigh = tilesH;

            int tiles = tilesWide * tilesHigh;

            sourceRectangles = new Rectangle[tiles];
            int tile = 0;
            for(int y = 0; y < tilesHigh; y++)
            {
                for(int x=0;x< tilesWide; x++)
                {
                    sourceRectangles[tile] = new Rectangle(
                        x*TileWidth,
                        y*TileHeight,
                        TileWidth,
                        TileHeight
                        );
                    tile++;
                }
            }

        }
    }
}

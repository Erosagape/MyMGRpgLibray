﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MGRpgLibrary.TileEngine
{
    public class TileMap
    {
        List<TileSet> tilesets;
        List<MapLayer> mapLayers;
        static int mapWidth;
        public static int WidthInPixels
        {
            get { return mapWidth * Engine.TileWidth; }
        }
        public static int HeightInPixels
        {
            get { return mapHeight * Engine.TileHeight; }
        }
        static int mapHeight;
        public TileMap(List<TileSet> tilesets,List<MapLayer> layers)
        {
            this.tilesets = tilesets;
            this.mapLayers = layers;
            mapWidth = mapLayers[0].Width;
            mapHeight = mapLayers[0].Height;
            for(int i = 1; i < layers.Count; i++)
            {
                if (mapWidth != mapLayers[i].Width || mapHeight != mapLayers[i].Height)
                    throw new Exception("Map layer size exception");
            }
        }
        public TileMap(TileSet tileset,MapLayer layer)
        {
            tilesets = new List<TileSet>();
            tilesets.Add(tileset);
            mapLayers = new List<MapLayer>();
            mapLayers.Add(layer);
            mapWidth = mapLayers[0].Width;
            mapHeight = mapLayers[0].Height;

        }
        public void Draw(SpriteBatch spriteBatch,Camera camera)
        {
            Rectangle destination = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);
            Tile tile;
            foreach(MapLayer layer in mapLayers)
            {
                for(int y=0;y< layer.Height; y++)
                {
                    destination.Y = y * Engine.TileHeight- (int)camera.Position.Y;
                    for(int x = 0; x < layer.Width; x++)
                    {
                        tile = layer.GetTile(x, y);
                        if(tile.TileIndex==-1||tile.TileSet==-1)
                            continue;
                        destination.X = x * Engine.TileWidth - (int)camera.Position.X;
                        spriteBatch.Draw(
                            tilesets[tile.TileSet].Texture,
                            destination,
                            tilesets[tile.TileSet].SourceRectangle[tile.TileIndex],
                            Color.White
                            );
                    }
                }
            }
        }
        public void AddLayer(MapLayer layer)
        {
            if (layer.Width != mapWidth && layer.Height != mapHeight)
                throw new Exception("Map Layer Size Exception");
            mapLayers.Add(layer);
        }
    }
}
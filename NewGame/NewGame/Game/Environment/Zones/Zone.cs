using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewGame.Game.Environment.Tiles;

namespace NewGame.Game.Environment.Zones
{
    abstract class Zone
    {
        protected int region;
        protected int zoneNumber;
        protected int width;
        protected int height;
        protected int levels;
        protected int pixelWidth;
        protected int pixelHeight;

        protected List<Tile[,]> tileMap;

        public int getRegion()
        {
            return region;
        }

        public int getZoneNumber()
        {
            return zoneNumber;
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public int getLevels()
        {
            return levels;
        }

        public int getPixelWidth()
        {
            return pixelWidth;
        }

        public int getPixelHeight()
        {
            return pixelHeight;
        }

        public List<Tile[,]> getTileMap()
        {
            return tileMap;
        }

        public Tile getTile(int x, int y, int level)
        {
            return tileMap[level][x, y];
        }


        protected void fillMap()
        {
            for (int i = 0; i < levels; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    for (int k = 0; k < height; k++)
                    {
                        tileMap[i][j, k] = new FreeTile(false, false);
                    }
                }
            }
        }

        protected void createFreeTileRectangle(int x, int y, int width, int height, int level, bool push, bool locked)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    tileMap[level][i, j] = new FreeTile(push, locked);
                }
            }
        }

        protected void createGapTileRectangle(int x, int y, int width, int height, int level)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    tileMap[level][i, j] = new GapTile();
                }
            }
        }

        protected void createSolidTileRectangle(int x, int y, int width, int height, int level)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    tileMap[level][i, j] = new SolidTile();
                }
            }
        }

        protected void createEdgeTileRectangle(int x, int y, int width, int height, int level, int orientation)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    tileMap[level][i, j] = new EdgeTile(orientation);
                }
            }
        }

        protected void createSquareCornerTileRectangle(int x, int y, int width, int height, int level, int orientation)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    tileMap[level][i, j] = new SquareCornerTile(orientation);
                }
            }
        }

        protected void createAngularCornerTileRectangle(int x, int y, int width, int height, int level, int orientation)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    tileMap[level][i, j] = new AngularCornerTile(orientation);
                }
            }
        }

        protected void createStairTileRectangle(int x, int y, int width, int height, int level, int orientation)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    tileMap[level][i, j] = new StairTile(orientation);
                }
            }
        }

        protected void createSlideTileRectangle(int x, int y, int width, int height, int level, int orientation)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    tileMap[level][i, j] = new SlideTile(orientation);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewGame.Game.Environment.Tiles;

namespace NewGame.Game.Environment.Zones.RobotTown
{
    class RobotTown1 : Zone
    {

        public RobotTown1(int width, int height, int levels)
        {
            region = 0;
            zoneNumber = 0;

            this.width = width;
            this.height = height;

            pixelWidth = width * 30;
            pixelHeight = height * 30;

            tileMap = new List<Tile[,]>();
            fillMap();
        }
    }
}

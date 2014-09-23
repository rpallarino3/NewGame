using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewGame.Game.Environment.Tiles
{
    class SolidTile : Tile
    {

        public SolidTile()
        {
            type = 2;
        }

        public override bool checkAvailability(int x, int y, int approachDirection)
        {
            return false;
        }
    }
}

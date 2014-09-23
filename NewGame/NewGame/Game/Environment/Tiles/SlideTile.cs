using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewGame.Game.Environment.Tiles
{
    class SlideTile : Tile
    {
        private int orientation;

        public SlideTile(int orientation)
        {
            type = 7;
            this.orientation = orientation;
        }

        public override bool checkAvailability(int x, int y, int approachDirection)
        {
            if (approachDirection == orientation)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getOrientation()
        {
            return orientation;
        }
    }
}

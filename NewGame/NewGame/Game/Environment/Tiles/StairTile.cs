using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewGame.Game.Environment.Tiles
{
    class StairTile : Tile
    {
        private int orientation;

        public StairTile(int orientation)
        {
            type = 6;
            this.orientation = orientation;
        }

        public override bool checkAvailability(int x, int y, int approachDirection)
        {
            if (approachDirection == 0 || approachDirection == 1)
            {
                if (orientation == 0 || orientation == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (approachDirection == 2 || approachDirection == 3)
            {
                if (orientation == 2 || orientation == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

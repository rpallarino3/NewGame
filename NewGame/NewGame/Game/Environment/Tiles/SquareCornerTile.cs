using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewGame.Game.Environment.Tiles
{
    class SquareCornerTile : Tile
    {

        private int orientation;

        public SquareCornerTile(int orientation)
        {
            type = 4;
            this.orientation = orientation;
        }

        public override bool checkAvailability(int x, int y, int approachDirection)
        {
            if (orientation == 0)
            {
                if (x < 10 && y < 10)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (orientation == 1)
            {
                if (x >= 20 && y >= 20)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (orientation == 2)
            {
                if (x >= 20 && y < 10)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (orientation == 3)
            {
                if (x < 10 && y >= 20)
                {
                    return false;
                }
                else
                {
                    return true;
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

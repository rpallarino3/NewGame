using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewGame.Game.Environment.Tiles
{
    class AngularCornerTile : Tile
    {

        private int orientation;

        public AngularCornerTile(int orientation)
        {
            type = 5;
            this.orientation = orientation;
        }

        public override bool checkAvailability(int x, int y, int approachDirection)
        {
            if (orientation == 0)
            {
                if (x > 29 - y)
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
                if (x <= 29 - y)
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
                if (y < x)
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
                if (x < y)
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

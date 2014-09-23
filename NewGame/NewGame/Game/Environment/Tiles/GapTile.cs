using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewGame.Game.Environment.Tiles
{
    class GapTile : Tile
    {

        private bool filled;

        public GapTile()
        {
            type = 1;
        }

        public override bool checkAvailability(int x, int y, int approachDirection)
        {
            return filled;
        }

        public bool isFilled()
        {
            return filled;
        }

        public void fill()
        {
            filled = true;
        }

        public void free()
        {
            filled = false;
        }
    }
}

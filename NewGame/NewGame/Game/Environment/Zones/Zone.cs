using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewGame.Game.Environment.Zones
{
    abstract class Zone
    {
        protected int region;
        protected int zoneNumber;


        public int getRegion()
        {
            return region;
        }

        public int getZoneNumber()
        {
            return zoneNumber;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewGame.Game.Environment.Zones;

namespace NewGame.Game.Environment
{
    abstract class ZoneFactory
    {

        protected List<Zone> zones;

        public List<Zone> getZones()
        {
            return zones;
        }

        public Zone getZone(int zoneNumber)
        {
            return zones[zoneNumber];
        }

        public abstract void createZones();
        public abstract void deconstructZones();
    }
}

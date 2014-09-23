using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewGame.Game.Environment.ZoneFactories;

namespace NewGame.Game.Environment
{
    class RegionFactory
    {
        private List<ZoneFactory> zoneFactories;

        public RegionFactory()
        {
            zoneFactories = new List<ZoneFactory>();

            zoneFactories.Add(new RobotTownZoneFactory());
        }

        public ZoneFactory getZoneFactory(int region)
        {
            return zoneFactories[region];
        }
    }
}

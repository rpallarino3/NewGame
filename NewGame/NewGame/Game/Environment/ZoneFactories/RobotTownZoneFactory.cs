using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewGame.Game.Environment.Zones;
using NewGame.Game.Environment.Zones.RobotTown;

namespace NewGame.Game.Environment.ZoneFactories
{
    class RobotTownZoneFactory : ZoneFactory
    {

        public RobotTownZoneFactory()
        {
            zones = new List<Zone>();
        }


        public override void createZones()
        {
            zones.Add(new RobotTown1(50, 50, 2));
        }

        public override void deconstructZones()
        {
        }
    }
}

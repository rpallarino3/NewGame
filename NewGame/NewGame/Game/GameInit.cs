using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewGame.Game.Environment;
using NewGame.Game.Environment.Zones;

namespace NewGame.Game
{
    class GameInit
    {
        private GameState gameState;
        private Player player;
        private RegionFactory regionFactory;        

        public GameInit()
        {
            gameState = new GameState();
            player = new Player();
            regionFactory = new RegionFactory();
        }

        public GameState getGameState()
        {
            return gameState;
        }

        public Player getPlayer()
        {
            return player;
        }

        public RegionFactory getRegionFactory()
        {
            return regionFactory;
        }

        public Zone getCurrentZone()
        {
            return regionFactory.getZoneFactory(player.getCurrentRegion()).getZone(player.getCurrentZone());
        }
    }
}

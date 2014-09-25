using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewGame.Game
{
    class GameInit
    {
        private GameState gameState;
        private Player player;

        public GameInit()
        {
            gameState = new GameState();
            player = new Player();
        }

        public GameState getGameState()
        {
            return gameState;
        }

        public Player getPlayer()
        {
            return player;
        }
    }
}

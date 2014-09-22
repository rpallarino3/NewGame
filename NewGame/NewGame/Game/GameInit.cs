using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewGame.Game
{
    class GameInit
    {
        private GameState gameState;

        public GameInit()
        {
            gameState = new GameState();
        }

        public GameState getGameState()
        {
            return gameState;
        }
    }
}

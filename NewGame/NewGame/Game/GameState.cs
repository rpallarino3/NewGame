using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewGame.Game
{
    class GameState
    {
        private readonly int START = 0;
        private readonly int GAME = 1;

        private int state;

        public GameState()
        {
            state = START;
        }

        public int getState()
        {
            return state;
        }

        public void setStartState()
        {
            state = START;
        }

        public void setGameState()
        {
            state = GAME;
        }
    }
}

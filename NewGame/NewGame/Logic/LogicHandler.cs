using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewGame.Game;
using NewGame.Input;
using NewGame.ContentHandlers;

using Microsoft.Xna.Framework;

namespace NewGame.Logic
{
    class LogicHandler
    {

        private PlayerLogicHandler playerLogicHandler;
        private MovementHandler movementHandler;
        private Color drawColor;


        public LogicHandler()
        {
            movementHandler = new MovementHandler();
            playerLogicHandler = new PlayerLogicHandler();
            drawColor = Color.White;
        }

        public void updateLogic(GameInit gameInit, KeyHandler keyHandler, ContentHandler content)
        {
            if (gameInit.getGameState().getState() == 0)
            {
            }
            else if (gameInit.getGameState().getState() == 1)
            {
                updateFreeRoamLogic(gameInit, keyHandler, content);
            }
        }

        private void updateFreeRoamLogic(GameInit gameInit, KeyHandler keyHandler, ContentHandler content)
        {
            playerLogicHandler.updateLogic(gameInit, keyHandler, content);
        }

        public Color getDrawColor()
        {
            return drawColor;
        }
    }
}

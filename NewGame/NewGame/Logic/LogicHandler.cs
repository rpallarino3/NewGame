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
        private Color drawColor;

        public LogicHandler()
        {
            drawColor = Color.White;
        }

        public void updateLogic(GameInit gameInit, KeyHandler keyHandler, ContentHandler content)
        {
        }

        public Color getDrawColor()
        {
            return drawColor;
        }
    }
}

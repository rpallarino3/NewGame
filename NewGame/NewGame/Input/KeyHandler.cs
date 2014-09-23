using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace NewGame.Input
{
    class KeyHandler
    {
        private Keybinds keybinds;
        private KeyboardState previousState;

        private int upTime;
        private int downTime;
        private int rightTime;
        private int leftTime;

        public KeyHandler()
        {
            keybinds = new Keybinds();
        }

        public void updateKeys(KeyboardState keyState)
        {
            previousState = keyState;
            checkMoveKeys(keyState);
        }

        private void checkMoveKeys(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(keybinds.getKeybinds()["MOVEUP"]))
            {
                upTime++;
            }
            else
            {
                upTime = 0;
            }

            if (keyState.IsKeyDown(keybinds.getKeybinds()["MOVEDOWN"]))
            {
                downTime++;
            }
            else
            {
                downTime = 0;
            }

            if (keyState.IsKeyDown(keybinds.getKeybinds()["MOVERIGHT"]))
            {
                rightTime++;
            }
            else
            {
                rightTime = 0;
            }

            if (keyState.IsKeyDown(keybinds.getKeybinds()["MOVELEFT"]))
            {
                leftTime++;
            }
            else
            {
                leftTime = 0;
            }
        }


        public int getUpTime()
        {
            return upTime;
        }

        public int getDownTime()
        {
            return downTime;
        }

        public int getRightTime()
        {
            return rightTime;
        }

        public int getLeftTime()
        {
            return leftTime;
        }
    }
}

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

        public KeyHandler()
        {
        }

        public void updateKeys(KeyboardState keyState)
        {
            previousState = keyState;
        }
    }
}

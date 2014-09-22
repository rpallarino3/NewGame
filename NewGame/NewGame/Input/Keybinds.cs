using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace NewGame.Input
{
    class Keybinds
    {
        private Dictionary<string, Keys> keybinds;

        public Keybinds()
        {
            keybinds = new Dictionary<string, Keys>();
            fillBaseKeys();
        }

        private void fillBaseKeys()
        {
            keybinds.Add("MOVEUP", Keys.Up);
            keybinds.Add("MOVEDOWN", Keys.Down);
            keybinds.Add("MOVERIGHT", Keys.Right);
            keybinds.Add("MOVELEFT", Keys.Left);

            keybinds.Add("ACTION", Keys.Z);
            keybinds.Add("BACK", Keys.X);

            keybinds.Add("LEFTBUMP", Keys.A);
            keybinds.Add("RIGHTBUMP", Keys.S);

            keybinds.Add("MENU1", Keys.C);
            keybinds.Add("MENU2", Keys.D);
        }

        public void changeKey(string code, Keys newKey)
        {
            keybinds[code] = newKey;
        }

        public Dictionary<string, Keys> getKeybinds()
        {
            return keybinds;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;

namespace NewGame.ContentHandlers
{
    abstract class ZoneContentHandler
    {
        protected ContentManager content;

        public abstract void loadContent();

    }
}

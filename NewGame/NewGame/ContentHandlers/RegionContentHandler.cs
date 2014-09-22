using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;

using NewGame.ContentHandlers.ZoneContentHandlers;

namespace NewGame.ContentHandlers
{
    class RegionContentHandler
    {

        private ContentManager content;

        private List<ZoneContentHandler> zoneContentHandlers;

        public RegionContentHandler(ContentManager content)
        {
            this.content = content;
            zoneContentHandlers = new List<ZoneContentHandler>();
            zoneContentHandlers.Add(new RobotTownContentHandler(content));
        }

        public void loadContent(int region)
        {
            zoneContentHandlers[region].loadContent();
        }

        public void unloadContent()
        {
            content.Unload();
        }
    }
}

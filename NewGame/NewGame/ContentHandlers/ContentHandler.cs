using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace NewGame.ContentHandlers
{
    class ContentHandler
    {
        private RegionContentHandler regionContentHandler;
        private ContentManager zoneContent;


        public ContentHandler(ContentManager zoneContent)
        {
            this.zoneContent = zoneContent;
            regionContentHandler = new RegionContentHandler(zoneContent);
        }

        public RegionContentHandler getRegionContentHandler()
        {
            return regionContentHandler;
        }
    }
}

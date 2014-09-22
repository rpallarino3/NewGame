using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace NewGame.ContentHandlers.ZoneContentHandlers
{
    class RobotTownContentHandler : ZoneContentHandler
    {
        private List<List<Texture2D>> zoneImages;

        public RobotTownContentHandler(ContentManager content)
        {
            this.content = content;
            zoneImages = new List<List<Texture2D>>();
        }

        public override void loadContent()
        {

        }

        public List<Texture2D> getZoneImages(int zone)
        {
            return zoneImages[zone];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewGame.Game.Animations.Atlases
{
    class HumanoidCharacterAtlas : Atlas
    {

        public HumanoidCharacterAtlas()
        {
            animationLengths = new List<int>();
            cancellable = new List<bool>();

            spriteSize = new Microsoft.Xna.Framework.Vector2(30, 45);
            sectionSize = new Microsoft.Xna.Framework.Vector2(40, 50);

            fillAnimations();
        }

        private void fillAnimations()
        {
            animationLengths.Add(10);
            cancellable.Add(true);
        }
    }
}

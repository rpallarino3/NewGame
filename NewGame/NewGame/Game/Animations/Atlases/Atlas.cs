using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace NewGame.Game.Animations.Atlases
{
    abstract class Atlas
    {

        protected Vector2 spriteSize;
        protected Vector2 sectionSize;
        protected List<int> animationLengths;
        protected List<bool> cancellable;

        public Vector2 getSpriteSize()
        {
            return spriteSize;
        }

        public Vector2 getSectionSize()
        {
            return sectionSize;
        }

        public List<int> getAnimationLengths()
        {
            return animationLengths;
        }

        public int getAnimationLength(int row)
        {
            return animationLengths[row];
        }

        public List<bool> getCancellable()
        {
            return cancellable;
        }

        public bool isCancellable(int row)
        {
            return cancellable[row];
        }
    }
}

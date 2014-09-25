using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewGame.Game.Animations.Atlases;

namespace NewGame.Game.Animations.States
{
    abstract class AnimationState
    {
        protected int id;
        protected int currentRow;
        protected int currentColumn;
        protected bool animationFinished;
        protected Atlas atlas;

        public abstract void advanceAnimation();
        public abstract void setNewAnimation(int newRow);

        public int getID()
        {
            return id;
        }

        public int getCurrentRow()
        {
            return currentRow;
        }

        public int getCurrentColumn()
        {
            return currentColumn;
        }

        public bool isAnimationFinished()
        {
            return animationFinished;
        }

        public Atlas getAtlas()
        {
            return atlas;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewGame.Game.Animations.Atlases;

namespace NewGame.Game.Animations.States
{
    class CharacterAnimationState : AnimationState
    {

        public CharacterAnimationState(int id, Atlas atlas)
        {
            this.id = id;
            this.atlas = atlas;
        }

        public override void advanceAnimation()
        {
            if (animationFinished)
            {
                currentColumn = 0;
            }
            else
            {
                currentColumn++;
            }

            if (currentColumn == atlas.getAnimationLength(currentRow) - 1)
            {
                animationFinished = true;
            }
        }

        public override void setNewAnimation(int newRow)
        {
            currentRow = newRow;
            currentColumn = 0;
            animationFinished = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using NewGame.Game.Animations.States;
using NewGame.Game.Animations.Atlases;

namespace NewGame.Game
{
    class Player
    {

        private Vector2 location;
        private int facingDirection;
        private int level;
        private int currentZone;
        private int currentRegion;
        private AnimationState animationState;
        private Vector2 walkingSize;
        private Vector2 drawingSize;

        public Player()
        {
            animationState = new CharacterAnimationState(0, new HumanoidCharacterAtlas());
            walkingSize = new Vector2(30, 30);
            drawingSize = new Vector2(30, 45);
        }

        public Vector2 getWalkingSize()
        {
            return walkingSize;
        }

        public Vector2 getDrawingSize()
        {
            return drawingSize;
        }

        public AnimationState getAnimationState()
        {
            return animationState;
        }

        public Vector2 getLocation()
        {
            return location;
        }

        public int getFacingDirection()
        {
            return facingDirection;
        }

        public int getLevel()
        {
            return level;
        }

        public int getCurrentZone()
        {
            return currentZone;
        }

        public int getCurrentRegion()
        {
            return currentRegion;
        }

        public void setLocation(Vector2 location)
        {
            this.location = location;
        }

        public void setFacingDirection(int direction)
        {
            facingDirection = direction;
        }

        public void setLevel(int level)
        {
            this.level = level;
        }

        public void setCurrentZone(int zone)
        {
            currentZone = zone;
        }

        public void setCurrentRegion(int region)
        {
            currentRegion = region;
        }

        public void moveUp(int distance)
        {
            location += new Vector2(0, -distance);
        }

        public void moveDown(int distance)
        {
            location += new Vector2(0, distance);
        }

        public void moveRight(int distance)
        {
            location += new Vector2(distance, 0);
        }

        public void moveLeft(int distance)
        {
            location += new Vector2(-distance, 0);
        }

        public void upOneLevel()
        {
            level++;
        }

        public void downOneLevel()
        {
            level--;
        }
    }
}

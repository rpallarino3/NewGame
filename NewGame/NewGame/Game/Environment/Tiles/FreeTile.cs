using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewGame.Game.Environment.ManipulatableObjects;

namespace NewGame.Game.Environment.Tiles
{
    class FreeTile : Tile
    {

        private bool filled;
        private ManipulatableObject containedObject;
        private bool lockPushedObject;
        private bool freeForPush;

        public FreeTile(bool push, bool locked)
        {
            type = 0;
            freeForPush = push;
            lockPushedObject = locked;
        }

        public override bool checkAvailability(int x, int y, int approachDirection)
        {
            return !filled;
        }

        public bool isFilled()
        {
            return filled;
        }

        public void fill(ManipulatableObject obj)
        {
            containedObject = obj;
            filled = true;
        }

        public void free()
        {
            filled = false;
        }

        public bool doesLockPushedObject()
        {
            return lockPushedObject;
        }

        public bool isFreeForPush()
        {
            return freeForPush;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace NewGame.Game.Environment.Tiles
{
    abstract class Tile
    {

        protected int type;
        protected bool transition;
        protected int destination;
        protected int regionDestination;
        protected Vector2 destinationTile;

        public abstract bool checkAvailability(int x, int y, int approachDirection);

        public void addTransition(int destination, int regionDestination, Vector2 destinationTile)
        {
            transition = true;

            this.destination = destination;
            this.regionDestination = regionDestination;
            this.destinationTile = destinationTile;
        }

        public bool isTransition()
        {
            return transition;
        }

        public int getTransitionDestination()
        {
            return destination;
        }

        public int getRegionDestination()
        {
            return regionDestination;
        }

        public Vector2 getDestinationTile()
        {
            return destinationTile;
        }

        public int getType()
        {
            return type;
        }
    }
}

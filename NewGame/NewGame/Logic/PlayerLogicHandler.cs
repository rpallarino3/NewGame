using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewGame.Game;
using NewGame.Input;
using NewGame.ContentHandlers;
using NewGame.Game.Environment.Tiles;

using Microsoft.Xna.Framework;

namespace NewGame.Logic
{
    class PlayerLogicHandler
    {
        private readonly int BUMP_LEFT = 20;
        private readonly int BUMP_RIGHT = 10;

        private readonly int STAND = 0;
        private readonly int WALK = 1;
        private readonly int PUSH = 2;
        private readonly int OTHER = 3;

        private readonly int BLOCKED_THRESHOLD = 5;
        private readonly int MOVE_THRESHOLD = 2;
        private readonly int MAX_MOVE = 4;

        private int currentState = 0;
        private int previousState = 0;

        private int blockedCounter = 0;

        private bool moveUp;
        private bool moveDown;
        private bool moveRight;
        private bool moveLeft;

        private int upDistance;
        private int downDistance;
        private int rightDistance;
        private int leftDistance;

        private int duration;

        private bool actionPerformed;

        public PlayerLogicHandler()
        {
        }

        public void updateLogic(GameInit gameInit, KeyHandler keyHandler, ContentHandler content)
        {
            actionPerformed = false;

            moveUp = false;
            moveDown = false;
            moveRight = false;
            moveLeft = false;

            upDistance = 0;
            downDistance = 0;
            rightDistance = 0;
            leftDistance = 0;

            duration = 0;

            if (gameInit.getPlayer().getAnimationState().isAnimationCancellable())
            {
                if (keyHandler.isActionReady())
                {
                }

                if (!actionPerformed)
                {
                    int direction = getFacingDirection(keyHandler);

                    if (direction != -1 && duration > MOVE_THRESHOLD)
                    {
                        currentState = WALK;

                        if (direction == 0)
                        {
                            if (!moveDown)
                            {
                                checkMove(0, gameInit);
                            }

                            if (moveRight)
                            {
                                if (!moveLeft)
                                {
                                    lateralMove(2, gameInit);
                                }
                            }

                            if (moveLeft)
                            {
                                if (!moveRight)
                                {
                                    lateralMove(3, gameInit);
                                }
                            }

                            if (upDistance == 0)
                            {
                                blockedCounter++;
                            }
                            else
                            {
                                blockedCounter = 0;
                            }
                        }
                        else if (direction == 1)
                        {
                            if (!moveUp)
                            {
                                checkMove(1, gameInit);
                            }

                            if (moveRight)
                            {
                                if (!moveLeft)
                                {
                                    lateralMove(2, gameInit);
                                }
                            }

                            if (moveLeft)
                            {
                                if (!moveRight)
                                {
                                    lateralMove(3, gameInit);
                                }
                            }

                            if (downDistance == 0)
                            {
                                blockedCounter++;
                            }
                            else
                            {
                                blockedCounter = 0;
                            }
                        }
                        else if (direction == 2)
                        {
                            if (!moveLeft)
                            {
                                checkMove(2, gameInit);
                            }

                            if (moveUp)
                            {
                                if (!moveDown)
                                {
                                    lateralMove(0, gameInit);
                                }
                            }

                            if (moveDown)
                            {
                                if (!moveUp)
                                {
                                    lateralMove(1, gameInit);
                                }
                            }

                            if (rightDistance == 0)
                            {
                                blockedCounter++;
                            }
                            else
                            {
                                blockedCounter = 0;
                            }
                        }
                        else if (direction == 3)
                        {
                            if (!moveRight)
                            {
                                checkMove(3, gameInit);
                            }

                            if (moveUp)
                            {
                                if (!moveDown)
                                {
                                    lateralMove(0, gameInit);
                                }
                            }

                            if (moveDown)
                            {
                                if (!moveUp)
                                {
                                    lateralMove(1, gameInit);
                                }
                            }

                            if (leftDistance == 0)
                            {
                                blockedCounter++;
                            }
                            else
                            {
                                blockedCounter = 0;
                            }
                        }

                        if (blockedCounter > BLOCKED_THRESHOLD)
                        {

                        }
                    }
                    else
                    {
                        currentState = STAND;
                        gameInit.getPlayer().setFacingDirection(direction);
                    }

                    // do animation stuff
                }

                previousState = currentState;
            }
        }

        // check for npcs somewhere before move
        private void checkMove(int direction, GameInit gameInit)
        {
            if (direction == 0)
            {
                Vector2 start = gameInit.getPlayer().getLocation() + new Vector2(0, -2);
                int level = gameInit.getPlayer().getLevel();

                if (start.Y >= 0)
                {
                    int leftBump = 0;
                    int rightBump = 0;
                    int centerBump = 0;
                    int hits = 0;

                    for (int i = 0; i < gameInit.getPlayer().getWalkingSize().X; i++)
                    {
                        Tile tile = gameInit.getCurrentZone().getTile(((int)start.X + i) / 30, (int)start.Y / 30, level);

                        if (!tile.checkAvailability(((int)start.X + i) % 30, (int)start.Y % 30, level))
                        {
                            hits++;

                            if (i < BUMP_RIGHT)
                            {
                                rightBump++;
                            }
                            else if (i >= BUMP_LEFT)
                            {
                                leftBump++;
                            }
                            else
                            {
                                centerBump++;
                            }
                        }
                    }
                    if (hits != 0)
                    {
                        if (centerBump == 0)
                        {
                            if (leftBump > 0)
                            {
                                movePlayerLeft(2, gameInit);
                            }
                            else if (rightBump > 0)
                            {
                                movePlayerRight(2, gameInit);
                            }
                        }
                    }
                    else
                    {
                        start += new Vector2(0, -2);

                        if (start.Y < 0)
                        {
                            movePlayerUp(2, gameInit);
                        }
                        else
                        {
                            for (int i = 0; i < gameInit.getPlayer().getWalkingSize().X; i++)
                            {
                                Tile tile = gameInit.getCurrentZone().getTile(((int)start.X + i) / 30, (int)start.Y / 30, level);

                                if (!tile.checkAvailability(((int)start.X + i) % 30, (int)start.Y % 30, level))
                                {
                                    hits++;
                                    movePlayerUp(2, gameInit);
                                }
                            }

                            if (hits == 0)
                            {
                                movePlayerUp(4, gameInit);
                            }
                        }
                    }
                }
            }
            else if (direction == 1)
            {
                Vector2 start = gameInit.getPlayer().getLocation() + new Vector2(0, 2 - 1 + gameInit.getPlayer().getWalkingSize().Y);
                int level = gameInit.getPlayer().getLevel();

                if (start.Y < gameInit.getCurrentZone().getPixelHeight())
                {
                    int leftBump = 0;
                    int rightBump = 0;
                    int centerBump = 0;
                    int hits = 0;

                    for (int i = 0; i < gameInit.getPlayer().getWalkingSize().X; i++)
                    {
                        Tile tile = gameInit.getCurrentZone().getTile(((int)start.X + i) / 30, (int)start.Y / 30, level);

                        if (!tile.checkAvailability(((int)start.X + i) % 30, (int)start.Y % 30, level))
                        {
                            hits++;

                            if (i < BUMP_RIGHT)
                            {
                                rightBump++;
                            }
                            else if (i >= BUMP_LEFT)
                            {
                                leftBump++;
                            }
                            else
                            {
                                centerBump++;
                            }
                        }
                    }
                    if (hits != 0)
                    {
                        if (centerBump == 0)
                        {
                            if (leftBump > 0)
                            {
                                movePlayerLeft(2, gameInit);
                            }
                            else if (rightBump > 0)
                            {
                                movePlayerRight(2, gameInit);
                            }
                        }
                    }
                    else
                    {
                        start += new Vector2(0, 2);

                        if (start.Y >= gameInit.getCurrentZone().getPixelHeight())
                        {
                            movePlayerDown(2, gameInit);
                        }
                        else
                        {
                            for (int i = 0; i < gameInit.getPlayer().getWalkingSize().X; i++)
                            {
                                Tile tile = gameInit.getCurrentZone().getTile(((int)start.X + i) / 30, (int)start.Y / 30, level);

                                if (!tile.checkAvailability(((int)start.X + i) % 30, (int)start.Y % 30, level))
                                {
                                    hits++;
                                    movePlayerDown(2, gameInit);
                                }
                            }

                            if (hits == 0)
                            {
                                movePlayerDown(4, gameInit);
                            }
                        }
                    }
                }
            }
            else if (direction == 2)
            {
                Vector2 start = gameInit.getPlayer().getLocation() + new Vector2(2 - 1 + gameInit.getPlayer().getWalkingSize().X, 0);
                int level = gameInit.getPlayer().getLevel();

                if (start.X < gameInit.getCurrentZone().getPixelWidth())
                {
                    int rightBump = 0;
                    int leftBump = 0;
                    int centerBump = 0;
                    int hits = 0;

                    for (int i = 0; i < gameInit.getPlayer().getWalkingSize().Y; i++)
                    {
                        Tile tile = gameInit.getCurrentZone().getTile(((int)start.X) / 30, ((int)start.Y + i) / 30, level);

                        if (!tile.checkAvailability(((int)start.X) % 30, ((int)start.Y + i) % 30, level))
                        {
                            hits++;

                            if (i < BUMP_RIGHT)
                            {
                                rightBump++;
                            }
                            else if (i >= BUMP_LEFT)
                            {
                                leftBump++;
                            }
                            else
                            {
                                centerBump++;
                            }
                        }
                    }
                    if (hits != 0)
                    {
                        if (centerBump == 0)
                        {
                            if (leftBump > 0)
                            {
                                movePlayerDown(2, gameInit);
                            }
                            else if (rightBump > 0)
                            {
                                movePlayerUp(2, gameInit);
                            }
                        }
                    }
                    else
                    {
                        start += new Vector2(2, 0);

                        if (start.X >= gameInit.getCurrentZone().getPixelWidth())
                        {
                            movePlayerRight(2, gameInit);
                        }
                        else
                        {
                            for (int i = 0; i < gameInit.getPlayer().getWalkingSize().Y; i++)
                            {
                                Tile tile = gameInit.getCurrentZone().getTile(((int)start.X) / 30, ((int)start.Y + i) / 30, level);

                                if (!tile.checkAvailability(((int)start.X) % 30, ((int)start.Y + i) % 30, level))
                                {
                                    hits++;
                                    movePlayerRight(2, gameInit);
                                }
                            }

                            if (hits == 0)
                            {
                                movePlayerRight(4, gameInit);
                            }
                        }
                    }
                }
            }
            else if (direction == 3)
            {
                Vector2 start = gameInit.getPlayer().getLocation() + new Vector2(-2, 0);
                int level = gameInit.getPlayer().getLevel();

                if (start.X >= 0)
                {
                    int rightBump = 0;
                    int leftBump = 0;
                    int centerBump = 0;
                    int hits = 0;

                    for (int i = 0; i < gameInit.getPlayer().getWalkingSize().Y; i++)
                    {
                        Tile tile = gameInit.getCurrentZone().getTile(((int)start.X) / 30, ((int)start.Y + i) / 30, level);

                        if (!tile.checkAvailability(((int)start.X) % 30, ((int)start.Y + i) % 30, level))
                        {
                            hits++;

                            if (i < BUMP_RIGHT)
                            {
                                rightBump++;
                            }
                            else if (i >= BUMP_LEFT)
                            {
                                leftBump++;
                            }
                            else
                            {
                                centerBump++;
                            }
                        }
                    }
                    if (hits != 0)
                    {
                        if (centerBump == 0)
                        {
                            if (leftBump > 0)
                            {
                                movePlayerDown(2, gameInit);
                            }
                            else if (rightBump > 0)
                            {
                                movePlayerUp(2, gameInit);
                            }
                        }
                    }
                    else
                    {
                        start += new Vector2(-2, 0);

                        if (start.X < 0)
                        {
                            movePlayerLeft(2, gameInit);
                        }
                        else
                        {
                            for (int i = 0; i < gameInit.getPlayer().getWalkingSize().Y; i++)
                            {
                                Tile tile = gameInit.getCurrentZone().getTile(((int)start.X) / 30, ((int)start.Y + i) / 30, level);

                                if (!tile.checkAvailability(((int)start.X) % 30, ((int)start.Y + i) % 30, level))
                                {
                                    hits++;
                                    movePlayerLeft(2, gameInit);
                                }
                            }

                            if (hits == 0)
                            {
                                movePlayerLeft(4, gameInit);
                            }
                        }
                    }
                }
            }
        }

        private void lateralMove(int direction, GameInit gameInit)
        {
            if (direction == 0)
            {
                Vector2 start = gameInit.getPlayer().getLocation() + new Vector2(0, -2);
                int level = gameInit.getPlayer().getLevel();

                if (start.Y >= 0)
                {
                    int hits = 0;

                    for (int i = 0; i < gameInit.getPlayer().getWalkingSize().X; i++)
                    {
                        Tile tile = gameInit.getCurrentZone().getTile(((int)start.X + i) / 30, (int)start.Y / 30, level);

                        if (!tile.checkAvailability(((int)start.X + i) % 30, (int)start.Y % 30, level))
                        {
                            hits++;
                        }
                    }

                    if (hits == 0)
                    {
                        start += new Vector2(0, -2);

                        if (start.Y < 0)
                        {
                            movePlayerUp(2, gameInit);
                        }
                        else
                        {
                            for (int i = 0; i < gameInit.getPlayer().getWalkingSize().X; i++)
                            {
                                Tile tile = gameInit.getCurrentZone().getTile(((int)start.X + i) / 30, (int)start.Y / 30, level);

                                if (!tile.checkAvailability(((int)start.X + i) % 30, (int)start.Y % 30, level))
                                {
                                    hits++;
                                    movePlayerUp(2, gameInit);
                                }
                            }

                            if (hits == 0)
                            {
                                movePlayerUp(4, gameInit);
                            }
                        }
                    }
                }
            }
            else if (direction == 1)
            {
                Vector2 start = gameInit.getPlayer().getLocation() + new Vector2(0, 2 + gameInit.getPlayer().getWalkingSize().Y - 1);
                int level = gameInit.getPlayer().getLevel();

                if (start.Y < gameInit.getCurrentZone().getPixelHeight())
                {
                    int hits = 0;

                    for (int i = 0; i < gameInit.getPlayer().getWalkingSize().X; i++)
                    {
                        Tile tile = gameInit.getCurrentZone().getTile(((int)start.X + i) / 30, (int)start.Y / 30, level);

                        if (!tile.checkAvailability(((int)start.X + i) % 30, (int)start.Y % 30, level))
                        {
                            hits++;
                        }
                    }

                    if (hits == 0)
                    {
                        start += new Vector2(0, 2);

                        if (start.Y >= gameInit.getCurrentZone().getPixelHeight())
                        {
                            movePlayerDown(2, gameInit);
                        }
                        else
                        {
                            for (int i = 0; i < gameInit.getPlayer().getWalkingSize().X; i++)
                            {
                                Tile tile = gameInit.getCurrentZone().getTile(((int)start.X + i) / 30, (int)start.Y / 30, level);

                                if (!tile.checkAvailability(((int)start.X + i) % 30, (int)start.Y % 30, level))
                                {
                                    hits++;
                                    movePlayerDown(2, gameInit);
                                }
                            }

                            if (hits == 0)
                            {
                                movePlayerDown(4, gameInit);
                            }
                        }
                    }
                }
            }
            else if (direction == 2)
            {
                Vector2 start = gameInit.getPlayer().getLocation() + new Vector2(2 + gameInit.getPlayer().getWalkingSize().X - 1, 0);
                int level = gameInit.getPlayer().getLevel();

                if (start.X < gameInit.getCurrentZone().getPixelWidth())
                {
                    int hits = 0;

                    for (int i = 0; i < gameInit.getPlayer().getWalkingSize().Y; i++)
                    {
                        Tile tile = gameInit.getCurrentZone().getTile((int)start.X / 30, ((int)start.Y + i) / 30, level);

                        if (!tile.checkAvailability(((int)start.X) % 30, ((int)start.Y + i) % 30, level))
                        {
                            hits++;
                        }
                    }

                    if (hits == 0)
                    {
                        start += new Vector2(2, 0);

                        if (start.X >= gameInit.getCurrentZone().getPixelWidth())
                        {
                            movePlayerRight(2, gameInit);
                        }
                        else
                        {
                            for (int i = 0; i < gameInit.getPlayer().getWalkingSize().Y; i++)
                            {
                                Tile tile = gameInit.getCurrentZone().getTile(((int)start.X) / 30, ((int)start.Y  + i)/ 30, level);

                                if (!tile.checkAvailability(((int)start.X) % 30, ((int)start.Y + i) % 30, level))
                                {
                                    hits++;
                                    movePlayerRight(2, gameInit);
                                }
                            }

                            if (hits == 0)
                            {
                                movePlayerRight(4, gameInit);
                            }
                        }
                    }
                }
            }
            else if (direction == 3)
            {
                Vector2 start = gameInit.getPlayer().getLocation() + new Vector2(-2, 0);
                int level = gameInit.getPlayer().getLevel();

                if (start.X >= 0)
                {
                    int hits = 0;

                    for (int i = 0; i < gameInit.getPlayer().getWalkingSize().Y; i++)
                    {
                        Tile tile = gameInit.getCurrentZone().getTile((int)start.X / 30, ((int)start.Y + i) / 30, level);

                        if (!tile.checkAvailability(((int)start.X) % 30, ((int)start.Y + i) % 30, level))
                        {
                            hits++;
                        }
                    }

                    if (hits == 0)
                    {
                        start += new Vector2(-2, 0);

                        if (start.X < 0)
                        {
                            movePlayerLeft(2, gameInit);
                        }
                        else
                        {
                            for (int i = 0; i < gameInit.getPlayer().getWalkingSize().Y; i++)
                            {
                                Tile tile = gameInit.getCurrentZone().getTile(((int)start.X) / 30, ((int)start.Y + i) / 30, level);

                                if (!tile.checkAvailability(((int)start.X) % 30, ((int)start.Y + i) % 30, level))
                                {
                                    hits++;
                                    movePlayerLeft(2, gameInit);
                                }
                            }

                            if (hits == 0)
                            {
                                movePlayerLeft(4, gameInit);
                            }
                        }
                    }
                }
            }
        }

        private void movePlayerUp(int distance, GameInit gameInit)
        {
            if (upDistance < MAX_MOVE)
            {
                if (upDistance + distance >= MAX_MOVE)
                {
                    gameInit.getPlayer().moveUp(MAX_MOVE - upDistance);
                }
                else
                {
                    gameInit.getPlayer().moveUp(distance);
                    upDistance += distance;
                }
            }
        }

        private void movePlayerDown(int distance, GameInit gameInit)
        {
            if (downDistance < MAX_MOVE)
            {
                if (downDistance + distance >= MAX_MOVE)
                {
                    gameInit.getPlayer().moveDown(MAX_MOVE - downDistance);
                }
                else
                {
                    gameInit.getPlayer().moveDown(distance);
                    downDistance += distance;
                }
            }
        }

        private void movePlayerRight(int distance, GameInit gameInit)
        {
            if (rightDistance < MAX_MOVE)
            {
                if (rightDistance + distance >= MAX_MOVE)
                {
                    gameInit.getPlayer().moveRight(MAX_MOVE - rightDistance);
                }
                else
                {
                    gameInit.getPlayer().moveRight(distance);
                    rightDistance += distance;
                }
            }
        }

        private void movePlayerLeft(int distance, GameInit gameInit)
        {
            if (leftDistance < MAX_MOVE)
            {
                if (leftDistance + distance >= MAX_MOVE)
                {
                    gameInit.getPlayer().moveLeft(MAX_MOVE - leftDistance);
                }
                else
                {
                    gameInit.getPlayer().moveLeft(distance);
                    leftDistance += distance;
                }
            }
        }

        private int getFacingDirection(KeyHandler keyHandler)
        {
            int direction = -1;

            int upTime = keyHandler.getUpTime();
            int downTime = keyHandler.getDownTime();
            int rightTime = keyHandler.getRightTime();
            int leftTime = keyHandler.getLeftTime();

            if (upTime > 0)
            {
                moveUp = true;
                direction = 0;
                duration = upTime;
            }

            if (downTime > 0)
            {
                moveDown = true;

                if (downTime > duration)
                {
                    direction = 1;
                    duration = downTime;
                }
            }

            if (rightTime > 0)
            {
                moveRight = true;

                if (rightTime > duration)
                {
                    direction = 2;
                    duration = rightTime;
                }
            }

            if (leftTime > 0)
            {
                moveLeft = true;

                if (leftTime > duration)
                {
                    direction = 3;
                    duration = leftTime;
                }
            }

            return direction;
        }
    }
}

using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria.NPC
{
    enum DirectionType
    {
        Left,
        Right,
        Up,
        Down
    }
    abstract class Entity : Transformable, Drawable
    {
        public bool isDestroyed = false;

        protected RectangleShape rect;
        protected Vector2f velocity;
        protected Vector2f movement;
        protected World world;
        protected bool isFly = true;
        protected bool isRectVisible = true;
        protected bool isGhost = false;

        public Entity(World world)
        {
            this.world = world;
        }

        public virtual void Update()
        {
            UpdatePhysics();
        }

        // UpdatePhysics
        public void UpdatePhysics()
        {
            if (!isGhost)
            {
                //innertion
                velocity.X *= 0.99f;
                //gravity
                velocity.Y += 0.25f;

                var offset = velocity + movement;
                float dist = MathHelper.GetDistance(offset);

                int countStep = 1;
                float stepSize = (float)Tile.TILE_SIZE / 2;
                if (dist > stepSize)
                    countStep = (int)(dist / stepSize);


                Vector2f nextpos = Position + offset;
                Vector2f stepPos = Position - rect.Origin;
                FloatRect stepRect = new FloatRect(stepPos, rect.Size);
                Vector2f stepVec = (nextpos - Position) / countStep;

                for (int step = 0; step < countStep; step++)
                {
                    bool isBreakStep = false;

                    stepPos += stepVec;
                    stepRect = new FloatRect(stepPos, rect.Size);

                    int i = (int)((stepPos.X + rect.Size.X / 2) / Tile.TILE_SIZE);
                    int j = (int)((stepPos.Y + rect.Size.Y) / Tile.TILE_SIZE);
                    Tile tile = world.GetTile(i, j);

                    if (tile != null)
                    {

                        FloatRect tileRect = new FloatRect(tile.Position, new Vector2f(Tile.TILE_SIZE, Tile.TILE_SIZE));

                        if (updateCollision(stepRect, tileRect, DirectionType.Down, ref stepPos))
                        {
                            velocity.Y = 0;
                            isFly = false;
                            isBreakStep = true;
                        }
                        else
                            isFly = true;
                    }
                    else
                        isFly = true;

                    if (updateWallColision(i, j, -1, ref stepPos, stepRect) || updateWallColision(i, j, 1, ref stepPos, stepRect))
                    {
                        OnWallCollided();
                        isBreakStep = true;
                    }
                    if (isBreakStep)
                        break;
                }
                Position = stepPos + rect.Origin;
            }
            else
            Position += velocity + movement;
        }

        //UpdatePhysicWall collision
        bool updateWallColision(int i, int j, int iOffset, ref Vector2f stepPos, FloatRect stepRect)
        {
            var dirType = iOffset > 0 ? DirectionType.Right : DirectionType.Left;

            Tile[] walls = new Tile[]
            {
                world.GetTile(i + iOffset, j -1),
                world.GetTile(i + iOffset, j -2),
                world.GetTile(i + iOffset, j -3),
            };

            bool isWallCollided = false;
            foreach (Tile t in walls)
            {
                if (t == null)
                    continue;

                FloatRect tileRect = new FloatRect(t.Position, new Vector2f(Tile.TILE_SIZE, Tile.TILE_SIZE));

                if (updateCollision(stepRect, tileRect, dirType, ref stepPos))
                    isWallCollided = true;
            }

            return isWallCollided;
        }

        bool updateCollision(FloatRect rectNPC, FloatRect rectTile, DirectionType direction, ref Vector2f pos)
        {
            if (rectNPC.Intersects(rectTile))
            {
                switch (direction)
                {
                    case DirectionType.Up: pos = new Vector2f(pos.X, rectTile.Top + rectTile.Height - 1); break;
                    case DirectionType.Down: pos = new Vector2f(pos.X, rectTile.Top - rectNPC.Height + 1); break;
                    case DirectionType.Left: pos = new Vector2f(rectTile.Left + rectTile.Width - 1, pos.Y); break;
                    case DirectionType.Right: pos = new Vector2f(rectTile.Left - rectNPC.Width + 1, pos.Y); break;
                }
                return true;
            }
            return false;
        }


        public abstract void OnWallCollided();
        public abstract void Draw(RenderTarget target, RenderStates states);
    }
}

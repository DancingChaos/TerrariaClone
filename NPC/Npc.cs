using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria.NPC
{
    abstract class Npc : Transformable, Drawable
    {
        public Vector2f StartPosition;
        protected RectangleShape rect;
        protected Vector2f velocity;
        protected Vector2f movement;
        protected World world;
        protected bool isFly = true;
        protected bool isRectVisible = true;
      
        public int Direction
        {
            set
            {
                int dir = value >= 0 ? 1 : -1;
                Scale = new Vector2f(dir, 1);
            }
            get
            {
                int dir = Scale.X >= 0 ? 1 : -1;
                return dir;
            }

        }
         
        //constuctor
        public Npc(World world)
        {
            this.world = world;
        }

        // возраждение существа
        public void Spawn()
        {
            Position = StartPosition;
            velocity = new Vector2f();
        }

        //Update
        public void Update()
        {
            UpdateNpc();
            UpdatePhysics();

            Position += movement + velocity;


            //если обьект упал за мир
            if (Position.Y > main.win.Size.Y)
                OnKill();
        }

        //draw
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            
            if(isRectVisible)
            target.Draw(rect, states);

            DrawNPC(target, states);
        }

        // UpdatePhysics
        public void UpdatePhysics()
        {
            bool isFall = true;
            //innertion
            velocity.X *= 0.99f;
            //gravity
            velocity.Y += 0.25f;

            Vector2f nextpos = Position + velocity - rect.Origin;
            FloatRect playerSprite = new FloatRect(nextpos, rect.Size);

            int pX = (int)((Position.X - rect.Origin.X + rect.Size.X / 2) / Tile.TILE_SIZE);
            int pY = (int)((Position.Y + rect.Size.Y) / Tile.TILE_SIZE);
            Tile tile = world.GetTile(pX, pY);

            if (tile != null)
            {

                FloatRect tileRect = new FloatRect(tile.Position, new Vector2f(Tile.TILE_SIZE, Tile.TILE_SIZE));

                isFall = !playerSprite.Intersects(tileRect);
                isFly = isFall;
            }
            if (!isFall)
            {
                velocity.Y = 0;
            }

            UpdatePhysicWall(playerSprite, pX, pY);

        }

        //UpdatePhysicWall collision
        private void UpdatePhysicWall(FloatRect playerSprite, int pX, int pY)
        {
            Tile[] walls = new Tile[]
            {
                world.GetTile(pX-1,pY-1),
                world.GetTile(pX-1,pY-2),
                world.GetTile(pX-1,pY-3),
                world.GetTile(pX+1,pY-1),
                world.GetTile(pX+1,pY-2),
                world.GetTile(pX+1,pY-3)
            };
            foreach (Tile tile in walls)
            {
                if (tile == null)
                    continue;
                FloatRect tileRect = new FloatRect(tile.Position, new Vector2f(Tile.TILE_SIZE, Tile.TILE_SIZE));

                if (playerSprite.Intersects(tileRect))
                {
                    Vector2f offset = new Vector2f(playerSprite.Left - tileRect.Left, 0);
                    offset.X /= Math.Abs(offset.X);

                    float speed = Math.Abs(movement.X);
                    //npc collision
                    if (offset.X > 0)
                    {
                        Position = new Vector2f((tileRect.Left + tileRect.Width) + playerSprite.Width / 2, Position.Y);
                        movement.X = 0;
                    }
                    else if (offset.X < 0)
                    {
                        Position = new Vector2f(tileRect.Left - playerSprite.Width/2, Position.Y);
                        movement.X = 0;
                    }
                    OnWallCollided();
                }
            }
        }



        public abstract void OnKill();
        public abstract void OnWallCollided();
        public abstract void UpdateNpc();
        public abstract void DrawNPC(RenderTarget target, RenderStates states);
    }
}

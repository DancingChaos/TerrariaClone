
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria
{
    class Player : Transformable , Drawable
    {
        public const float PLAYER_SPEED = 3f;
        public const float PLAYER_SPEED_ACCELERATION = 0.2f;

        public Vector2f StartPosition; 

        RectangleShape Sprite;
        RectangleShape SpriteDirection;
        Vector2f Velocity;
        Vector2f Movement;
        World world;
                                                                       
        public int Direction                                           
        {                                                              
            set                                                        
            {                                                          
                int dir = value >= 0 ? 1 : -1;                         
                Scale = new Vector2f(dir, 1);                                                                              
            }                                                          
            get                                                        
            {                                                          
                int dir = Scale.X >= 0 ? 1:-1;                         
                return dir;
            }

        }
        public Player(World world)
        {
            Sprite = new RectangleShape(new SFML.System.Vector2f(Tile.TILE_SIZE * 1.5f , Tile.TILE_SIZE * 2.8f));
            Sprite.Origin = new SFML.System.Vector2f(Sprite.Size.X / 2, 0);

            SpriteDirection = new RectangleShape(new SFML.System.Vector2f(50, 3));
            SpriteDirection.FillColor = Color.Red;
            SpriteDirection.Position = new SFML.System.Vector2f(0, Sprite.Size.Y / 2 - 1);

            this.world = world;
        }
        public void Update()
        {
            UpdatePhysics();
            UpdateMovement();
            Position += Movement + Velocity;

            if (Position.Y >  main.win.Size.Y)
                Spawn();
        }
        private void UpdateMovement()
        {
            bool isLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
            bool isRight = Keyboard.IsKeyPressed(Keyboard.Key.D);
            bool isMove = isLeft || isRight;

            if (isMove)
            {
                if (isLeft)
                {
                    Movement.X -= PLAYER_SPEED_ACCELERATION;
                    Direction = -1;
                }
                if (isRight)
                {
                    Movement.X += PLAYER_SPEED_ACCELERATION;
                    Direction = 1;
                }

                if(Movement.X > PLAYER_SPEED)
                {
                    Movement.X = PLAYER_SPEED;
                }
                else if (Movement.X < -PLAYER_SPEED)
                {
                    Movement.X = -PLAYER_SPEED;
                }
            }
            else
            {
                Movement = new Vector2f();
            }

        }

        public void UpdatePhysics()
        {
            bool isFall = true;

            Velocity += new Vector2f(0, 0.15f);

            int pX = (int)((Position.X - Sprite.Origin.X + Sprite.Size.X / 2) / Tile.TILE_SIZE);
            int pY = (int)((Position.Y + Sprite.Size.Y) / Tile.TILE_SIZE);
            Tile tile = world.GetTile(pX , pY);

            if (tile != null)
            {
                Vector2f nextpos = Position + Velocity - Sprite.Origin;
                FloatRect playerSprite = new FloatRect(nextpos, Sprite.Size);
                FloatRect tileRect = new FloatRect(tile.Position, new Vector2f(Tile.TILE_SIZE, Tile.TILE_SIZE));

                isFall = !playerSprite.Intersects(tileRect);
            }
            if (!isFall)
            {
                Velocity.Y = 0;
            }
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(Sprite, states);
            target.Draw(SpriteDirection, states); 
        }

        public void Spawn()
        {
            Position = StartPosition;

            Velocity = new Vector2f();
        }
    }
}

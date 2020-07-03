
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.NPC;

namespace Terraria
{
    class Player : Npc
    {
        public const float PLAYER_SPEED = 3f;
        public const float PLAYER_SPEED_ACCELERATION = 0.2f;
        
        RectangleShape SpriteDirection;
        
        public Player(World world) :base(world)
        {
       
            rect = new RectangleShape(new SFML.System.Vector2f(Tile.TILE_SIZE * 1.5f, Tile.TILE_SIZE * 2.8f));
            rect.Origin = new SFML.System.Vector2f(rect.Size.X / 2, 0);

            SpriteDirection = new RectangleShape(new SFML.System.Vector2f(50, 3));
            SpriteDirection.FillColor = Color.Red;
            SpriteDirection.Position = new SFML.System.Vector2f(0, rect.Size.Y / 2 - 1);

        }

        public override void OnKill()
        {
            Spawn();
        }

        public override void OnWallCollided()
        {
        }

        public override void UpdateNpc()
        {
            UpdateMovement();
        }

        public override void DrawNPC(RenderTarget target, RenderStates states)
        {
                target.Draw(SpriteDirection, states);
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
                    if (movement.X > 0)
                        movement.X = 0; 

                    movement.X -= PLAYER_SPEED_ACCELERATION;
                    Direction = -1;
                }
                if (isRight)
                {
                    if (movement.X < 0)
                        movement.X = 0;

                    movement.X += PLAYER_SPEED_ACCELERATION;
                    Direction = 1;
                }

                if (movement.X > PLAYER_SPEED)
                {
                    movement.X = PLAYER_SPEED;
                }
                else if (movement.X < -PLAYER_SPEED)
                {
                    movement.X = -PLAYER_SPEED;
                }
            }
            else
            {
                movement = new Vector2f();
            }
        }     
    }
}

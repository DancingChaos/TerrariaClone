using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using System.Drawing;
namespace Terraria.NPC
{
    class NpcSlime : Npc
    {
        const float TIME_WAIT_JUMP = 1f;
        SpriteSheet spriteSheet;
        float waitTimer = 0f;

        public NpcSlime(World world) : base(world)
        {
            spriteSheet = new SpriteSheet(1, 2, 0, (int)Content.texNpcSlime.Size.X, (int)Content.texNpcSlime.Size.Y);

            rect = new RectangleShape(new Vector2f(spriteSheet.SubWight / 1.5f, spriteSheet.SubHeight / 1.5f));
            rect.Origin = new Vector2f(rect.Size.X / 2, 0);
            rect.FillColor = Color.Blue;

            rect.Texture = Content.texNpcSlime;
            rect.TextureRect = spriteSheet.GetTextureRect(0, 0);
        }


        public override void OnKill()
        {
            Spawn();
        }

        public override void OnWallCollided()
        {
            Direction *= -1;
            velocity = new Vector2f(-velocity.X * 0.8f, velocity.Y);
        }

        public override void UpdateNpc()
        {
            if (!isFly)
            {
                if (waitTimer >= TIME_WAIT_JUMP)
                {
                    velocity = new Vector2f(Direction * main.rand.Next(1, 10), -main.rand.Next(6, 9));
                    waitTimer = 0f;
                }
                else
                {
                    waitTimer += 0.05f;
                    velocity.X = 0f;
                }
                rect.TextureRect = spriteSheet.GetTextureRect(0, 0);
            }
            else
            {
                rect.TextureRect = spriteSheet.GetTextureRect(0,1);
            }
        }

        public override void DrawNPC(RenderTarget target, RenderStates states)
        {
        }
    }
}

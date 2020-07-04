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

        int minSlimeColor = 230;
        int maxSlimeColor = 30;
        int slimeVisible = 220;

        public NpcSlime(World world) : base(world)
        {
            spriteSheet = new SpriteSheet(1, 2, 0, (int)Content.texNpcSlime.Size.X, (int)Content.texNpcSlime.Size.Y);

            rect = new RectangleShape(new Vector2f(spriteSheet.SubWight / 1.5f, spriteSheet.SubHeight / 1.5f));
            rect.Origin = new Vector2f(rect.Size.X / 2, 0);
            rect.FillColor = GetRandomSlimeColor();

            rect.Texture = Content.texNpcSlime;
            rect.TextureRect = spriteSheet.GetTextureRect(0, 0);
        }

        //random sexy color
        public Color GetRandomSlimeColor()
        {
            int rMin = 0, gMin = 0, bMin = 0;
            int rMax = 255, gMax = 255, bMax = 255;

            switch (main.rand.Next(1, 8))
            {
                case 1: //all
                    rMin = minSlimeColor;
                    gMin = minSlimeColor;
                    bMin = minSlimeColor;
                    break;
                case 2: //red&green
                    rMin = minSlimeColor;
                    gMin = minSlimeColor;
                    bMax = maxSlimeColor;//
                    break;
                case 3: //red&blue
                    rMin = minSlimeColor;
                    gMax = maxSlimeColor;//
                    bMin = minSlimeColor;
                    break;
                case 4: //red
                    rMin = minSlimeColor;
                    gMax = maxSlimeColor;//
                    bMax = maxSlimeColor;//
                    break;
                case 5: //green&blue
                    rMax = maxSlimeColor;//
                    gMin = minSlimeColor;
                    bMin = minSlimeColor;
                    break;
                case 6://green
                    rMax = maxSlimeColor;//
                    gMin = minSlimeColor;
                    bMax = maxSlimeColor;//
                    break;
                case 7://blue
                    rMax = maxSlimeColor;//
                    gMax = maxSlimeColor;//
                    bMin = minSlimeColor;
                    break;
            }
            return new Color(Convert.ToByte(main.rand.Next(rMin, rMax)), Convert.ToByte(main.rand.Next(gMin, gMax)), Convert.ToByte(main.rand.Next(bMin, bMax)), Convert.ToByte(slimeVisible));
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
                rect.TextureRect = spriteSheet.GetTextureRect(0, 1);
            }
        }

        public override void DrawNPC(RenderTarget target, RenderStates states)
        {
        }
    }
}

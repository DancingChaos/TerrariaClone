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

        public NpcSlime(World world) : base(world)
        {
            rect = new RectangleShape(new Vector2f(Tile.TILE_SIZE * 1.5f, Tile.TILE_SIZE * 1f));
            rect.Origin = new Vector2f(rect.Size.X / 2, 0);
            Random r = new Random();
            rect.FillColor = Color.Blue;

        }


        public override void OnKill()
        {
            Spawn();
        }

        public override void OnWallCollided()
        {
            Direction *= -1;
            velocity = new Vector2f(-velocity.X, velocity.Y);
        }

        public override void UpdateNpc()
        {
            if(!isFly)
            {
                velocity = new Vector2f(Direction * main.rand.Next(1,10), -main.rand.Next(6, 9));
            }
        }

        public override void DrawNPC(RenderTarget target, RenderStates states)
        {
        }
    }
}

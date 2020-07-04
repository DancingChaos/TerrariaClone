using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria.NPC
{
    class NpcFastSlime : NpcSlime
    {
        public NpcFastSlime(World world) : base(world)
        {
            rect.FillColor = Color.White;
        }
        
        public override Vector2f GetJumpVelocity()
        {
            return new Vector2f(Direction * main.rand.Next(30, 40), -main.rand.Next(6, 9));
        }
    }
}

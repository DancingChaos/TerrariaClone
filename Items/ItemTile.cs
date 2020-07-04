using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria.Items
{
    class ItemTile : Item
    {
        public ItemTile(World world, Tile tile) : base(world, tile.SpriteSheet, 9, 3)
        {

        }

        public override void OnWallCollided()
        {

        }
    }
}

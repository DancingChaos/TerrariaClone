using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria.Items
{
    class ItemTile : Item
    {
        public ItemTile(World world, InfoItem infoItem) : base(world, infoItem)
        {
        }

        public override void OnWallCollided()
        {

        }
    }
}

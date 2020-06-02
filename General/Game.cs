using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria
{
    class Game
    {
        World world;

        public Game()
        {
            world = new World();
            world.GenerateWorld();
        }

        public void Update()
        {

        }
        public void Draw()
        {
            main.win.Draw(world);
        }

    }
}

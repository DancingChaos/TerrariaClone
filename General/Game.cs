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
        Player player;

        public Game()
        {
            world = new World();
            world.GenerateWorld();

            player = new Player(world);
            player.StartPosition = new SFML.System.Vector2f(300, 150);
            player.Spawn();
        }

        public void Update()
        {
            player.Update();
        }
        public void Draw()
        {
            main.win.Draw(world);
            main.win.Draw(player);
        }

    }
}

using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.NPC;

namespace Terraria
{
    class Game
    {
        World world;
        Player player;
        NpcSlime slime;

        //slimes
        List<NpcSlime> slimes = new List<NpcSlime>();

        public Game()
        {
            //gen new world
            world = new World();
            world.GenerateWorld();

            //Spawn player
            player = new Player(world);
            player.StartPosition = new SFML.System.Vector2f(300, 150);
            player.Spawn();

            //Spawn slime
            slime = new NpcSlime(world);
            slime.StartPosition = new SFML.System.Vector2f(500, 150);
            slime.Spawn();

            //slimes 
            for (int i = 0; i < 50; i++)
            {
                var s = new NpcSlime(world);
                s.StartPosition = new Vector2f(main.rand.Next(150, 600), 150);
                s.Direction = main.rand.Next(0, 2) == 0 ? 1 : -1;
                s.Spawn();
                slimes.Add(s);
            }

        }

        public void Update()
        {
            player.Update();
            slime.Update();
            //slimes 
            foreach (var s in slimes)
                s.Update();
        }
        public void Draw()
        {
            main.win.Draw(world);
            main.win.Draw(player);
            main.win.Draw(slime);
            //slimes 
            foreach (var s in slimes)
                main.win.Draw(s);
        }

    }
}

﻿using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.NPC;
using Terraria.UI;

namespace Terraria
{
    class Game
    {
        World world;
        public Player Player {get; private set;}
        NpcSlime slime;
        NpcFastSlime fastSlime;

        //slimes
        List<NpcSlime> slimes = new List<NpcSlime>();

        public Game()
        {
            //gen new world
            world = new World();
            world.GenerateWorld(555);

            //Spawn player
            Player = new Player(world);
            Player.StartPosition = new SFML.System.Vector2f(300, 150);
            Player.Spawn();

            //Spawn slime
            slime = new NpcSlime(world);
            slime.StartPosition = new SFML.System.Vector2f(500, 150);
            slime.Spawn();

            //Spawn fast slime
            fastSlime = new NpcFastSlime(world);
            fastSlime.StartPosition = new SFML.System.Vector2f(350, 130);
            fastSlime.Spawn();

            //slimes 
            for (int i = 0; i < 10; i++)
            {
                var s = new NpcSlime(world);
                s.StartPosition = new Vector2f(World.rand.Next(150, 600), 150);
                s.Direction = World.rand.Next(0, 2) == 0 ? 1 : -1;
                s.Spawn();
                slimes.Add(s);
            }

            //ad new UI window
            Player.Inventory = new UIInventory();
             UIManager.AddControl(Player.Inventory);



        }

        public void Update()
        {
            world.Update();
            Player.Update();
            slime.Update();
            fastSlime.Update();
            //slimes 
            foreach (var s in slimes)
                s.Update();

            //update UI
            UIManager.UpdateOver();
            UIManager.Update();
        }
        public void Draw()
        {
            main.Window.Draw(world);
            main.Window.Draw(Player);
            main.Window.Draw(slime);
            main.Window.Draw(fastSlime);
            //slimes 
            foreach (var s in slimes)
                main.Window.Draw(s);

            //draw UI
            UIManager.Draw();
        }

    }
}

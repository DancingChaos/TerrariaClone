using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Terraria
{
    class main
    {
        public static RenderWindow Window { private set; get; }
        public static Game game { private set; get; }
        public static float Delta { private set; get; }

        static void Main(string[] args)
        {
            Window = new RenderWindow(new SFML.Window.VideoMode(800, 700), "Terraria");
            Window.SetVerticalSyncEnabled(true);

            Window.Closed += Terraria.Window.Win_Closed;
            Window.Resized += Terraria.Window.Win_Resized;

            Content.Load();
            
            game = new Game();
            Clock clock = new Clock();

            while (Window.IsOpen)
            {
                Delta = clock.Restart().AsSeconds();

                Window.DispatchEvents();

                game.Update();

                Window.Clear(Color.Black);

                game.Draw();

                Window.Display();
            }
        }

    }
}

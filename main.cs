using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
namespace Terraria
{
    class main
    {
        static RenderWindow window;

        public static RenderWindow win { get { return window; } } 
        public static Game game { private get; set; }

        static void Main(string[] args)
        {
            window = new RenderWindow(new SFML.Window.VideoMode(800, 700), "Terraria");
            window.SetVerticalSyncEnabled(true);

            window.Closed += Window.Win_Closed;
            window.Resized += Window.Win_Resized;

            Content.Load();

            game = new Game(); 

            while (window.IsOpen)
            {
                window.DispatchEvents();

                game.Update();

                window.Clear(Color.Black);

                game.Draw();

                window.Display();
            }
        }

    }
}

using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Terraria
{
    class Window
    {
        public static void Win_Closed(object sender, EventArgs e)
        {
            RenderWindow win = sender as RenderWindow;
            win.Close();
        }

        public static void Win_Resized(object sender, SizeEventArgs e)
        {
            RenderWindow win = sender as RenderWindow;
            win.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));

        }
    }
}

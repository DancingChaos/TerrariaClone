using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria
{
    class Content
    {
        private const string path_to_res = "..\\Resources\\Textures\\";

        public static Texture ground;
        public static Texture grass;

        public static void Load()
        {
            ground = new Texture(path_to_res + "Ground_Texture.png");
            grass = new Texture(path_to_res + "Grass_Texture.png");
        }
    }
}

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
        private const string path_to_res = "..\\Resources\\Textures\\"; // exile to res
        private const string path_to_npc = "\\npc\\";                   // exile to npc
        private const string path_to_player = "\\player\\";             // exile to player

        //MAP
        public static Texture ground; //ground
        public static Texture grass;  //grass

        //NPC
        public static Texture texNpcSlime;  //slime
       
        //PLAYER
        public static Texture texPlayerHair;  
        public static Texture texPlayerHands;  
        public static Texture texPlayerHead;  
        public static Texture texPlayerLegs;  
        public static Texture texPlayerShirt;  
        public static Texture texPlayerShoes;  
        public static Texture texPlayerUndershirt;  

        public static void Load()
        {
            //MAP
            ground = new Texture(path_to_res + "Ground_Texture.png");           //ground
            grass = new Texture(path_to_res + "Grass_Texture.png");             //grass

            //NPC
            texNpcSlime = new Texture(path_to_res + path_to_npc + "slime.png"); //slime

            //PLAYER
            texPlayerHair = new Texture(path_to_res + path_to_player + "Hair.png");
            texPlayerHands = new Texture(path_to_res + path_to_player + "Hands.png");
            texPlayerHead = new Texture(path_to_res + path_to_player + "Head.png");
            texPlayerLegs = new Texture(path_to_res + path_to_player + "Legs.png");
            texPlayerShirt = new Texture(path_to_res + path_to_player + "Shirt.png");
            texPlayerShoes = new Texture(path_to_res + path_to_player + "Shoes.png");
            texPlayerUndershirt = new Texture(path_to_res + path_to_player + "Undershirt.png");
        }
    }
}

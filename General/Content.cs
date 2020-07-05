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
        private const string path_to_ui = "\\ui\\";                     // exile to ui
        public static readonly string FONT_DIR = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "\\";

        //MAP
        public static SpriteSheet ssGround; //ground
        public static SpriteSheet ssGrass;  //grass

        //NPC
        public static SpriteSheet ssNpcSlime;  //slime

        //PLAYER
        public static SpriteSheet ssPlayerHair;
        public static SpriteSheet ssPlayerHands;
        public static SpriteSheet ssPlayerHead;
        public static SpriteSheet ssPlayerLegs;
        public static SpriteSheet ssPlayerShirt;
        public static SpriteSheet ssPlayerShoes;
        public static SpriteSheet ssPlayerUndershirt;

        //UI
        public static Texture texUIInventoryBack;       //inventory back

        public static Font font;       // Шрифт

        public static void Load()
        {
            //MAP
            ssGround = new SpriteSheet(Tile.TILE_SIZE, Tile.TILE_SIZE, false, 1, new Texture(path_to_res + "Ground_Texture.png"));           //ground
            ssGrass = new SpriteSheet(Tile.TILE_SIZE, Tile.TILE_SIZE, false, 1, new Texture(path_to_res + "Grass_Texture.png"));             //grass

            //NPC
            ssNpcSlime = new SpriteSheet(1, 2, true, 0, new Texture(path_to_res + path_to_npc + "slime.png")); //slime

            //PLAYER
            ssPlayerHair =       new SpriteSheet(1, 14, true, 0, new Texture(path_to_res + path_to_player + "Hair.png"));
            ssPlayerHands =      new SpriteSheet(1, 20, true, 0, new Texture(path_to_res + path_to_player + "Hands.png"));
            ssPlayerHead =       new SpriteSheet(1, 20, true, 0, new Texture(path_to_res + path_to_player + "Head.png"));
            ssPlayerLegs =       new SpriteSheet(1, 20, true, 0, new Texture(path_to_res + path_to_player + "Legs.png"));
            ssPlayerShirt =      new SpriteSheet(1, 20, true, 0, new Texture(path_to_res + path_to_player + "Shirt.png"));
            ssPlayerShoes =      new SpriteSheet(1, 20, true, 0, new Texture(path_to_res + path_to_player + "Shoes.png"));
            ssPlayerUndershirt = new SpriteSheet(1, 20, true, 0, new Texture(path_to_res + path_to_player + "Undershirt.png"));

            //UI
            texUIInventoryBack = new Texture(path_to_res + path_to_ui + "Inventory_Back.png");
            
            // Шрифт
            font = new Font(FONT_DIR + "Arial.ttf");
        }
    }
}

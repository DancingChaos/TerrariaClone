using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria
{
    class World : Transformable, Drawable
    {
        //chunk quantity
        public const int WORLD_WIGHT = 300;
        public const int WORLD_HEIGHT = 100;


        public static Random rand { private set; get; }

        Tile[,] tiles;

        //constr
        public World()
        {
            tiles = new Tile[WORLD_WIGHT, WORLD_HEIGHT];
        }

        //world generation
        public void GenerateWorld(int seed = -1)
        {
            rand = seed >= 0 ? new Random(seed) : new Random((int)DateTime.Now.Ticks);

            int groundLevelMax = rand.Next(10, 20);
            int groundLevelMin = groundLevelMax + rand.Next(10, 20);

            //gen ground level
            int[] arr = new int[WORLD_WIGHT];
            for (int i = 0; i < WORLD_WIGHT; i++)
            {
                int dir = rand.Next(0, 2) == 1 ? 1 : -1;

                if (i > 0)
                {
                    if (arr[i - 1] + dir < groundLevelMax || arr[i - 1] + dir > groundLevelMin)
                        dir -= dir;

                    arr[i] = arr[i - 1] + dir;
                }
                else
                    arr[i] = groundLevelMin;
            }

            //сглаживание
            for (int i = 1; i < WORLD_WIGHT -1; i++)
            {
                float sum = arr[i];
                int count = 1;
                for (int k = 0; k <= 5; k++)
                {
                    int i1 = i - k;
                    int i2 = i + k;


                    if(i1 > 0 )
                    {
                        sum += arr[i1];
                        count++;
                    }


                    if(i2 < WORLD_WIGHT )
                    {
                        sum += arr[i2];
                        count++;
                    }
                }

                arr[i] = (int)(sum / count);
            }


            for (int i = 0; i < WORLD_WIGHT; i++)
            {
                SetTile(TileType.GRASS, i, arr[i]);
                for (int j = arr[i]+1; j < WORLD_HEIGHT; j++)
                    SetTile(TileType.GROUND, i, j);
                
            }
        }

        //set tile
        public void SetTile(TileType type, int i, int j)
        {

            Tile upTileNeighbor = GetTile(i, j - 1); //up
            Tile downTileNeighbor = GetTile(i, j + 1); //down
            Tile leftTileNeighbor = GetTile(i - 1, j); //left
            Tile rightTileNeighbor = GetTile(i + 1, j); //right

            if (type != TileType.NONE)
            {
                var tile = new Tile(type, upTileNeighbor, downTileNeighbor, leftTileNeighbor, rightTileNeighbor);
                tile.Position = new Vector2f(i * Tile.TILE_SIZE, j * Tile.TILE_SIZE) + Position;
                tiles[i, j] = tile;
            }
            else
            {
                tiles[i, j] = null;

                if (upTileNeighbor != null)
                    upTileNeighbor.DownTile = null;
                if (downTileNeighbor != null)
                    downTileNeighbor.UpTile = null;
                if (leftTileNeighbor != null)
                    leftTileNeighbor.RightTile = null;
                if (rightTileNeighbor != null)
                    rightTileNeighbor.LeftTile = null;
            }
        }

        //get tile by world pos
        public Tile GetTileByWorldPos(float x, float y)
        {
            int i = (int)(x / Tile.TILE_SIZE);
            int j = (int)(y / Tile.TILE_SIZE);
            return GetTile(i, j);
        }
        public Tile GetTileByWorldPos(Vector2f pos)
        {
            return GetTileByWorldPos(pos.X, pos.Y);
        }
        public Tile GetTileByWorldPos(Vector2i pos)
        {
            return GetTileByWorldPos(pos.X, pos.Y);
        }

        //get tile
        public Tile GetTile(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < WORLD_WIGHT && j < WORLD_HEIGHT)
                return tiles[i, j];
            else
                return null;
        }


        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int i = 0; i < main.Window.Size.X / Tile.TILE_SIZE + 1; i++)
            {
                for (int j = 0; j < main.Window.Size.Y / Tile.TILE_SIZE + 1; j++)
                {
                    if (tiles[i, j] != null)
                        target.Draw(tiles[i, j]);
                }
            }
        }
    }
}

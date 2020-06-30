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
        public const int WORLD_SIZE = 5;

        Chunk[][] chunks;

        public World()
        {
            chunks = new Chunk[WORLD_SIZE][];

            for (int i = 0; i < WORLD_SIZE; i++)
                chunks[i] = new Chunk[WORLD_SIZE];
        }
        public void GenerateWorld()
        {
            for (int x = 3; x <= 46; x++)
                for (int y = 17; y <= 17; y++)
                    SetTile(TileType.GRASS, x, y);

            for (int x = 3; x <= 46; x++)
                for (int y = 18; y < 32; y++)
                    SetTile(TileType.GROUND, x, y);

            for (int x = 3; x <= 4; x++) 
                for (int y = 1; y < 17; y++)
                    SetTile(TileType.GROUND, x, y);

            for (int x = 45; x <= 46; x++)
                for (int y = 1; y < 17; y++)
                    SetTile(TileType.GROUND, x, y);
        }

        public void SetTile(TileType type, int x, int y)
        {
            Chunk chunk = GetChunk(x , y);
            var tilePos = GetTilePosFromChunk(x, y);

            Tile upTileNeighbor = GetTile(x, y - 1);
            Tile downTileNeighbor = GetTile(x, y + 1);
            Tile leftTileNeighbor = GetTile(x - 1, y);
            Tile rightTileNeighbor = GetTile(x + 1, y);

            chunk.SetTile(type, tilePos.X, tilePos.Y , upTileNeighbor , downTileNeighbor, leftTileNeighbor, rightTileNeighbor);
        }
        public Tile GetTile(int x, int y)
        {
            Chunk chunk = GetChunk(x, y);
            if (chunk == null)
                return null;

            var tilePos = GetTilePosFromChunk(x, y);

            return chunk.GetTile(tilePos.X, tilePos.Y);
        }

        public Chunk GetChunk(int x , int y)
        {
            int X = x / Chunk.CHUNK_SIZE;
            int Y = y / Chunk.CHUNK_SIZE;

            if(X >= WORLD_SIZE || Y >= WORLD_SIZE)
            {
                return null; 
            }

            if (chunks[X][Y] == null)
                chunks[X][Y] = new Chunk(new Vector2i(X,Y));

            return chunks[X][Y];
        }
        public Vector2i GetTilePosFromChunk(int x , int y)
        {
            int X = x / Chunk.CHUNK_SIZE;
            int Y = y / Chunk.CHUNK_SIZE;

            return new Vector2i(x - X * Chunk.CHUNK_SIZE, y - Y * Chunk.CHUNK_SIZE);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int x = 0; x < WORLD_SIZE; x++)
            {
                for (int y = 0; y < WORLD_SIZE; y++)
                {
                    if (chunks[x][y] == null) continue;

                    target.Draw(chunks[x][y]);
                }
            }
        }
    }
}

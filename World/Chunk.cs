using SFML.Graphics;
using SFML.System;

namespace Terraria
{
    class Chunk : Transformable, Drawable
    {
        public const int CHUNK_SIZE = 50;

        Tile[][] tiles;
        Vector2i chunkPos;

        public Chunk(Vector2i chunkPos)
        {
            this.chunkPos = chunkPos;
            Position = new Vector2f(chunkPos.X * CHUNK_SIZE * Tile.TILE_SIZE, chunkPos.Y * CHUNK_SIZE * Tile.TILE_SIZE);
            tiles = new Tile[CHUNK_SIZE][];

            for (int i = 0; i < CHUNK_SIZE; i++)
                tiles[i] = new Tile[CHUNK_SIZE];

        }

        public void SetTile(TileType type, int i, int j, Tile upTileNeighbor, Tile downTileNeighbor, Tile leftTileNeighbor, Tile rightTileNeighbor)
        {
            if (type != TileType.NONE)
            {
                tiles[i][j] = new Tile(type, upTileNeighbor, downTileNeighbor, leftTileNeighbor, rightTileNeighbor);
                tiles[i][j].Position = new Vector2f(i * Tile.TILE_SIZE, j * Tile.TILE_SIZE) + Position;
            }
            else
            {
                tiles[i][j] = null;

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
        public Tile GetTile(int x, int y)
        {
            if (x < 0 || y < 0 || x >= CHUNK_SIZE || y >= CHUNK_SIZE)
                return null;

            return tiles[x][y];
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int x = 0; x < CHUNK_SIZE; x++)
            {
                for (int y = 0; y < CHUNK_SIZE; y++)
                {
                    if (tiles[x][y] == null) continue;

                    target.Draw(tiles[x][y]);
                }
            }
        }
    }
}

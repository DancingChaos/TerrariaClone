using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria
{
    enum TileType
    {
        Void,
        Ground,
        Grass
    }
    class Tile : Transformable, Drawable
    {
        public const int TILE_SIZE = 16;

        TileType type = TileType.Ground;
        RectangleShape rectangleShape;

        Tile upTileNeighbor = null;
        Tile downTileNeighbor = null;
        Tile leftTileNeighbor = null;
        Tile rightTileNeighbor = null;

        public Tile(TileType type, Tile upTileNeighbor, Tile downTileNeighbor, Tile leftTileNeighbor, Tile rightTileNeighbor)
        {
            this.type = type;

            if(upTileNeighbor != null)
            {
                this.upTileNeighbor = upTileNeighbor;
                this.upTileNeighbor.downTileNeighbor = this;
            }
            if (downTileNeighbor != null)
            {
                this.downTileNeighbor = downTileNeighbor;
                this.downTileNeighbor.upTileNeighbor = this;
            }
            if (leftTileNeighbor != null)
            {
                this.leftTileNeighbor = leftTileNeighbor;
                this.leftTileNeighbor.rightTileNeighbor = this;
            }
            if (rightTileNeighbor != null)
            {
                this.rightTileNeighbor = rightTileNeighbor;
                this.rightTileNeighbor.leftTileNeighbor = this;
            }

            rectangleShape = new RectangleShape(new Vector2f(TILE_SIZE,TILE_SIZE));

            switch (type)
            {
                case TileType.Void:
                    break;
                case TileType.Ground:
                    rectangleShape.Texture = Content.ground;
                    break;
                case TileType.Grass:
                    rectangleShape.Texture = Content.grass;         
                    break;
                default:
                    break;
            }

            rectangleShape.TextureRect = GetTextureRect(1,1);
        }

        public void UpdateView()
        {

        }

        public IntRect GetTextureRect(int i , int j)
        {
            int x = i * TILE_SIZE + i * 2;
            int y = j * TILE_SIZE + j * 2;
         
            return new IntRect(x, y, TILE_SIZE, TILE_SIZE);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(rectangleShape, states);
        }
    }
}

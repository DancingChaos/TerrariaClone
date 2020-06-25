using SFML.Graphics;
using SFML.System;

namespace Terraria
{
    /// <summary>
    /// Счетчик существующих на данный момент плиток
    /// </summary>
    enum TileType
    {
        NONE,     
        GROUND,  
        GRASS   
    }

    class Tile : Transformable, Drawable
    {
       public const int TILE_SIZE = 16;

        TileType type = TileType.GROUND;

        RectangleShape rectShape;

        //Соседи
        Tile upTileNeighbor = null;
        Tile downTileNeighbor = null;
        Tile leftTileNeighbor = null;
        Tile rightTileNeighbor = null;

        public Tile UpTile
        {
            get
            {
                return upTileNeighbor;
            }

            set
            {
                upTileNeighbor = value;
                UpdateView();
            }
        }
        public Tile DownTile
        {
            get
            {
                return downTileNeighbor;
            }

            set
            {
                downTileNeighbor = value;
                UpdateView();
            }
        }
        public Tile LeftTile
        {
            get
            {
                return leftTileNeighbor;
            }

            set
            {
                leftTileNeighbor = value;
                UpdateView();
            }
        }
        public Tile RightTile
        {
            get
            {
                return rightTileNeighbor;
            }

            set
            {
                rightTileNeighbor = value;
                UpdateView();
            }
        }

        public Tile(TileType type, Tile upTile, Tile downTile, Tile leftTile, Tile rightTile)
        {
            this.type = type;

            // Присваиваем соседей, а соседям эту плитку
            if (upTile != null)
            {
                this.upTileNeighbor = upTile;
                this.upTileNeighbor.DownTile = this;    // Для верхнего соседа эта плитка будет нижним соседом
            }
            if (downTile != null)
            {
                this.downTileNeighbor = downTile;
                this.downTileNeighbor.UpTile = this;    // Для нижнего соседа эта плитка будет верхним соседом
            }
            if (leftTile != null)
            {
                this.leftTileNeighbor = leftTile;
                this.leftTileNeighbor.RightTile = this;    // Для левого соседа эта плитка будет правым соседом
            }
            if (rightTile != null)
            {
                this.rightTileNeighbor = rightTile;
                this.rightTileNeighbor.LeftTile = this;    // Для правого соседа эта плитка будет левым соседом
            }

            rectShape = new RectangleShape(new Vector2f(TILE_SIZE, TILE_SIZE));

            switch (type)
            {
                case TileType.GROUND:
                    rectShape.Texture = Content.ground;//блок с землей
                    break;
                case TileType.GRASS:
                    rectShape.Texture = Content.grass;//блок с травой
                    break;
            }
            UpdateView();
        }
        public void UpdateView()
        {
            //есть все соседи
            if (UpTile != null && DownTile != null && LeftTile != null && RightTile != null)
            {
                int i = main.rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(1 + i, 1);
            }

            //нет соседей
            else if (UpTile == null && DownTile == null && LeftTile == null && RightTile == null)
            {
                int i = main.rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(9 + i, 3);
            }//----------------------------------------------------------------------
            //нет соседа сверху
            else if (UpTile == null && DownTile != null && LeftTile != null && RightTile != null)
            {
                int i = main.rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(1 + i, 0);
            }
            //нет соседа снизу
            else if (UpTile != null && DownTile == null && LeftTile != null && RightTile != null)
            {
                int i = main.rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(1 + i, 2);
            }
            //нет соседа слева
            else if (UpTile != null && DownTile != null && LeftTile == null && RightTile != null)
            {
                int i = main.rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(0, i);
            }
            //нет соседа справа
            else if (UpTile != null && DownTile != null && LeftTile != null && RightTile == null)
            {
                int i = main.rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(4, i);
            }//----------------------------------------------------------------------
            //нет соседа сверху слева
            else if (UpTile == null && DownTile != null && LeftTile == null && RightTile != null)
            {
                int i = main.rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(0 + i * 2, 3);
            }
            //нет соседа сверху справа
            else if (UpTile == null && DownTile != null && LeftTile != null && RightTile == null)
            {
                int i = main.rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(1 + i * 2, 3);
            }
            //нет соседа слева снизу
            else if (UpTile != null && DownTile == null && LeftTile == null && RightTile != null)
            {
                int i = main.rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(0 + i * 2, 4);
            }
            //нет соседа справа снизу
            else if (UpTile != null && DownTile == null && LeftTile != null && RightTile == null)
            {
                int i = main.rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(1 + i * 2, 4);
            }
        }
        public IntRect GetTextureRect(int i, int j)
        {
            int x = i * TILE_SIZE + i * 2;
            int y = j * TILE_SIZE + j * 2;
            return new IntRect(x, y, TILE_SIZE, TILE_SIZE);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(rectShape, states);
        }
    }
}
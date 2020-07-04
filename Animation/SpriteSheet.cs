using SFML.Graphics;
using System;

namespace Terraria
{
    class SpriteSheet
    {
        public int SubWight { get; private set; }
        public int SubHeight { get; private set; }
        public int SubCountX { get; private set; }
        public int SubCountY { get; private set; }

        public Texture Texture;

        int borderSize; //короче манал переводить, это отступ между фрагментами текстуры

        /// <summary>
        /// //constructor
        /// </summary>
        /// <param name="a">количество фрагметов по Х</param>
        /// <param name="b">та же херня по Y</param>
        /// <param name="abIsCount">количество фрагментов по X & Y</param>
        /// <param name="borderSize">отступ между фрагментами текстуры</param>
        /// <param name="texW">высота текстуры</param>
        /// <param name="texH">ширина текстуры</param>
        public SpriteSheet(int a, int b, bool abIsCount, int borderSize, Texture texture, bool isSmooth = true)
        {
            Texture = texture;
            texture.Smooth = isSmooth;

            if (borderSize > 0)
            {
                this.borderSize = borderSize + 1;
            }
            else
            {
                this.borderSize = 0;
            }

            if (abIsCount)
            {
                SubWight = (int)Math.Ceiling((float)texture.Size.X / a);
                SubHeight = (int)Math.Ceiling((float)texture.Size.Y / b);
                SubCountX = a;
                SubCountY = b;
            }
            else
            {
                SubWight = a;
                SubHeight = b;
                SubCountX = (int)Math.Ceiling((float)texture.Size.X / a);
                SubCountY = (int)Math.Ceiling((float)texture.Size.Y / b);
            }
        }

        //clear texture memory
        public void Dispose()
        {
            Texture.Dispose();
            Texture = null;
        }

        //get texture
        public IntRect GetTextureRect(int i, int j)
        {
            int x = i * SubWight + i * borderSize;
            int y = j * SubHeight + j * borderSize;
            return new IntRect(x, y, SubWight, SubHeight);
        }
    }
}

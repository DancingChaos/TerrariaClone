using SFML.Graphics;
using System;

namespace Terraria
{
    class SpriteSheet
    {
        public int SubWight { get { return subW; } }
        public int SubHeight { get { return subH; } }

        int subW, subH; //texture size
        int borderSize; //короче манал переводить, это отступ между фрагментами текстуры

        /// <summary>
        /// //constructor
        /// </summary>
        /// <param name="a">количество фрагметов по Х</param>
        /// <param name="b">та же херня по Y</param>
        /// <param name="borderSize">отступ между фрагментами текстуры</param>
        /// <param name="texW">высота текстуры</param>
        /// <param name="texH">ширина текстуры</param>
        public SpriteSheet(int a, int b, int borderSize, int texW = 0, int texH = 0)
        {

            if (borderSize > 0)
            {
                this.borderSize = borderSize + 1;
            }
            else
            {
                this.borderSize = 0;
            }

            if (texW != 0 && texH != 0)
            {
                subW = (int)Math.Ceiling((float)texW / a);
                subH = (int)Math.Ceiling((float)texH / b);
            }
            else
            {
                subW = a;
                subH = b;
            }
        }

        //get texture
        public IntRect GetTextureRect(int i, int j)
        {
            int x = i * subW + i * borderSize;
            int y = j * subH + j * borderSize;
            return new IntRect(x, y, subW, subH);
        }
    }
}

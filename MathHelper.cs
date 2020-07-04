using SFML.System;
using System;

namespace Terraria
{
    class MathHelper
    {
        //get distance between 2 points
        public static float GetDistance(Vector2f v1, Vector2f v2)
        {
            float x = v2.X - v1.X;
            float y = v2.Y - v1.Y;
            return (float)Math.Sqrt(x * x + y * y); //piphagor epta
        }

        //get distance
        public static float GetDistance(float x1, float y1, float x2, float y2)
        {
            float x = x2 - x1;
            float y = y2 - y1;
            return (float)Math.Sqrt(x * x + y * y); //piphagor epta
        }

        //get vector lenght
        public static float GetDistance(Vector2f vec)
        {
            return (float)Math.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
        }

        //vector normalizer
        public static Vector2f Normalize(Vector2f vec)
        {
            float len = GetDistance(vec);
            vec.X /= len;
            vec.Y /= len;
            return vec;
        }
    }
}

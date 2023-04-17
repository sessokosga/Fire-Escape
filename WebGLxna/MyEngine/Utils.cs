using System;
using Microsoft.Xna.Framework;

namespace MyEngine
{
    public class Utils
    {
        static Random RandomGen = new Random();

        public static void setRandomSeed(int pSeed)
        {
            RandomGen = new Random(pSeed);
        }

        public static int GetInt(int pMin, int pMax)
        {
            return RandomGen.Next(pMin, pMax + 1);
        }

        public static bool isColliding(Vector2 pos1, Vector2 size1, Vector2 pos2, Vector2 size2)
        {
            return pos1.X < pos2.X + size2.X && pos2.X < pos1.X + size1.X && pos1.Y < pos2.Y + size2.Y && pos2.Y < pos1.Y + size1.Y;
        }

    }
}
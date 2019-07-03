using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidSlideDown
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class PyramidSlideDown
    {
        public static int LongestSlideDown(int[][] pyramid)
        {
            for (int i = pyramid.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = 0; j < pyramid[i].Length; j++)
                {
                    int left = pyramid[i + 1][j];
                    int right = pyramid[i + 1][j+1];
                    pyramid[i][j] += (left > right) ? left : right;
                }
            }

            return pyramid[0][0];
        }
    }
}

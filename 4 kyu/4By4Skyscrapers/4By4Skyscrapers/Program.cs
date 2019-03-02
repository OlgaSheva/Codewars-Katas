using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4By4Skyscrapers
{
    class Program
    {
        static void Main(string[] args)
        {
            var clues = new[]{ 2, 2, 1, 3,
                           2, 2, 3, 1,
                           1, 2, 2, 3,
                           3, 2, 1, 3};

            var expected = new[]{ new []{1, 3, 4, 2},
                               new []{4, 2, 1, 3},
                               new []{3, 4, 2, 1},
                               new []{2, 1, 3, 4 }};

            Skyscrapers skyscrapers = new Skyscrapers()
            var actual = skyscrapers.SolvePuzzle(clues);


        }
    }

    public class Skyscrapers
    {
        public static int[][] SolvePuzzle(int[] clues)
        {
            var actual = new int[3, 3];      

            
            foreach (int index in clues)
            {
                if (index == 4)
                {
                    switch (index)
                    {
                        case 0:
                        case 15:
                            actual[0, 0] = 4;
                            break;
                        case 1:
                            actual[0, 1] = 4;
                            break;
                        case 2:
                            actual[0, 2] = 4;
                            break;
                        case 3:
                        case 4:
                            actual[0, 3] = 4;
                            break;
                        case 5:
                            actual[1, 3] = 4;
                            break;
                        case 6:
                            actual[2, 3] = 4;
                            break;
                        case 7:
                        case 8:
                            actual[3, 3] = 4;
                            break;
                        case 9:
                            actual[3, 2] = 4;
                            break;
                        case 10:
                            actual[3, 1] = 4;
                            break;
                        case 11:
                        case 12:
                            actual[3, 0] = 4;
                            break;
                        case 13:
                            actual[2, 0] = 4;
                            break;
                        case 14:
                            actual[1, 0] = 4;
                            break;

                    }
                }

            return null;
        }
    }

}

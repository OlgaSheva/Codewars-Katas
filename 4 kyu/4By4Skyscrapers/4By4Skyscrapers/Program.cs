using System;
using System.Collections.Generic;

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
            var actual = new List<int>[3, 3];

            // in all squares build 1, 2, 3 and 4 skyscraper
            // then we will destroy unnecessary
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    actual[i, j] = new List<int>() { 1, 2, 3, 4 };

            // build skyscrapers 4
            foreach (int index in clues)
            {
                if (index == 1)
                {
                    switch (index)
                    {
                        case 0:
                        case 15:
                            actual[0, 0].Remove(1);
                            actual[0, 0].Remove(2);
                            actual[0, 0].Remove(3);
                            break;
                        case 1:
                            actual[0, 1].Remove(1);
                            actual[0, 1].Remove(2);
                            actual[0, 1].Remove(3);
                            break;
                        case 2:
                            actual[0, 2].Remove(1);
                            actual[0, 2].Remove(2);
                            actual[0, 2].Remove(3);
                            break;
                        case 3:
                        case 4:
                            actual[0, 3].Remove(1);
                            actual[0, 3].Remove(2);
                            actual[0, 3].Remove(3);
                            break;
                        case 5:
                            actual[1, 3].Remove(1);
                            actual[1, 3].Remove(2);
                            actual[1, 3].Remove(3);
                            break;
                        case 6:
                            actual[2, 3].Remove(1);
                            actual[2, 3].Remove(2);
                            actual[2, 3].Remove(3);
                            break;
                        case 7:
                        case 8:
                            actual[3, 3].Remove(1);
                            actual[3, 3].Remove(2);
                            actual[3, 3].Remove(3);
                            break;
                        case 9:
                            actual[3, 2].Remove(1);
                            actual[3, 2].Remove(2);
                            actual[3, 2].Remove(3);
                            break;
                        case 10:
                            actual[3, 1].Remove(1);
                            actual[3, 1].Remove(2);
                            actual[3, 1].Remove(3);
                            break;
                        case 11:
                        case 12:
                            actual[3, 0].Remove(1);
                            actual[3, 0].Remove(2);
                            actual[3, 0].Remove(3);
                            break;
                        case 13:
                            actual[2, 0].Remove(1);
                            actual[2, 0].Remove(2);
                            actual[2, 0].Remove(3);
                            break;
                        case 14:
                            actual[1, 0].Remove(1);
                            actual[1, 0].Remove(2);
                            actual[1, 0].Remove(3);
                            break;
                    }
                }

                



                return null;
            }

            void RemuveRepeatedInRowsAndColumnsSkyscrapers(List<int> list)
            {
                // destroy skyscrapers repeated in a row or column
                for (int sky = 0; sky < 4; sky++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (actual[i, j].Count == 1 && actual[i, j].Equals(sky))
                            {
                                for (int r = 0; r < 4; r++)
                                    if (r != i) actual[i, j].Remove(sky);
                                for (int c = 0; c < 4; c++)
                                    if (c != j) actual[i, j].Remove(sky);
                            }
                        }
                    }
                }
            }
        }
    }
    
}

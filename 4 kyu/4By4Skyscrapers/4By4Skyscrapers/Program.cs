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
            BuildSkyscapers4(actual, clues);

            RemoveRepeatedInRowsAndColumnsSkyscrapers(actual);


            
        }

        public static void BuildSkyscapers4(List<int>[,] actual, int[] clues)
        {
            foreach (int index in clues)
            {
                if (index == 1)
                {
                    switch (index)
                    {
                        case 0:
                        case 15:
                            actual[0, 0].RemoveRange(0, 2);
                            break;
                        case 1:
                            actual[0, 1].RemoveRange(0, 2);
                            break;
                        case 2:
                            actual[0, 2].RemoveRange(0, 2);
                            break;
                        case 3:
                        case 4:
                            actual[0, 3].RemoveRange(0, 2);
                            break;
                        case 5:
                            actual[1, 3].RemoveRange(0, 2);
                            break;
                        case 6:
                            actual[2, 3].RemoveRange(0, 2);
                            break;
                        case 7:
                        case 8:
                            actual[3, 3].RemoveRange(0, 2);
                            break;
                        case 9:
                            actual[3, 2].RemoveRange(0, 2);
                            break;
                        case 10:
                            actual[3, 1].RemoveRange(0, 2);
                            break;
                        case 11:
                        case 12:
                            actual[3, 0].RemoveRange(0, 2);
                            break;
                        case 13:
                            actual[2, 0].RemoveRange(0, 2);
                            break;
                        case 14:
                            actual[1, 0].RemoveRange(0, 2);
                            break;
                    }
                }
            }
        }

        public static void RemoveRepeatedInRowsAndColumnsSkyscrapers(List<int>[,] list)
        {
            for (int sky = 0; sky < 4; sky++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (list[i, j].Count == 1 && list[i, j].Equals(sky))
                        {
                            for (int r = 0; r < 4; r++)
                                if (r != i) list[i, j].Remove(sky);
                            for (int c = 0; c < 4; c++)
                                if (c != j) list[i, j].Remove(sky);
                        }
                    }
                }
            }
            return list;
        }
    }
    
}

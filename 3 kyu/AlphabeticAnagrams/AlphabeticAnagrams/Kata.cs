using System;
using System.Linq;

//https://www.codewars.com/kata/53e57dada0cb0400ba000688

namespace AlphabeticAnagrams
{
    public class Kata
    {
        public static long ListPosition(string value)
        {
            var sortSymbols = value.ToCharArray();
            Array.Sort(sortSymbols);

            var symbols = value.ToCharArray();

            if (Enumerable.SequenceEqual(symbols, sortSymbols)) return 1;            

            long indexNumber = 1;

            string word = value;

            for (int i = 0; i < value.Length - 1; i++)
            {
                if (i != 0)
                {
                    word = word.Remove(0, 1);
                }

                var distinctSymbols = word.Distinct().ToArray(); // get distinct symbols from the word
                Array.Sort(distinctSymbols);

                for (int j = 0; j < distinctSymbols.Length; j++)
                {
                    if (symbols[i] == distinctSymbols[j])
                    {
                        break;
                    }

                    int index = word.IndexOf(distinctSymbols[j]);
                    string s = word.Remove(index, 1);
                    indexNumber += CountTheNumberOfPossiblePermutationsOfTheElements(s);
                }
            }

            return indexNumber;
        }

        private static long CountTheNumberOfPossiblePermutationsOfTheElements(string word)
        {
            var symbols = word.GroupBy(s => s).Select(g => new { Count = g.Count(), Str = g.Key }).ToList();
            long divider = 1;
            foreach (var item in symbols)
            {
                divider *= Factorial(item.Count);
            }

            return Factorial(word.Length) / divider;
        }

        private static long Factorial(int f)
        {
            if (f == 0)
                return 1;
            else
                return f * Factorial(f - 1);
        }
    }
}

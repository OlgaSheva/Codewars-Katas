using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheOddInt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.find_it(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 })); // 5
        }
    }

    class Kata
    {
        public static int find_it(int[] seq)
        {
            var count = 0;
            for (var i = 0; i < seq.Length; i++)
            {
                for (var j = 0; j < seq.Length; j++)
                    if (seq[j] == seq[i])
                        count++;
                if (count % 2 == 1)
                    return seq[i];
            }
            return 0;
        }

    }
}

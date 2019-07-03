using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumsOfParts
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new int[] { 0, 1, 3, 6, 10 };
            var r = new int[] { 20, 20, 19, 16, 10, 0 };

            Console.WriteLine(r.Equals(SumParts.PartsSums(l)));
        }
    }

    class SumParts
    {
        public static int[] PartsSums(int[] ls)
        {
            //var list = new List<int>(ls);
            var result = new int[ls.Length + 1];
            int sum = 0;

            for (int i = ls.Length - 1; i >= 0; i--)
            {
                sum += ls[i];
                result[i] = sum;
            }

            return result;
        }
    }
}

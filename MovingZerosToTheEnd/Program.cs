using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingZerosToTheEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 };
            Kata.MoveZeroes(array);

            foreach (int i in array)
                Console.WriteLine(i);

            Console.ReadKey();
        }
    }

    public class Kata
    {
        public static int[] MoveZeroes(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] == 0)
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = 0;
                    }
                }
            }

            return arr;
        }
    }
}

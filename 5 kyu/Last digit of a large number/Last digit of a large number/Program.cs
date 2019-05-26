using System;
using System.Numerics;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { int.MaxValue, int.MaxValue };
            Console.WriteLine(Calculator.LastDigit(array));
            Console.ReadKey();
        }
    }

    public static class Calculator
    {
        public static int LastDigit(int[] array)
        {
            if (array.Length == 0)
                return 1;
            foreach (var item in array)
            {
                if (item < 0) return 0;
            }

            for (int key = array.Length - 1; key > 0; key--)
            {
                if (array[key] == 0)
                {
                    array[key - 1] = 1;
                    var array0 = new int[key];
                    for (int i = 0; i < key; i++)
                        array0[i] = array[i];
                    array = array0;
                    continue;
                }
                else if (array[key] == 1)
                {
                    var array1 = new int[key];
                    for (int i = 0; i < key; i++)
                        array1[i] = array[i];
                    array = array1;
                    continue;
                }

                if (array[key - 1] % 10 == 2 || array[key - 1] % 10 == 3
                    || array[key - 1] % 10 == 7 || array[key - 1] % 10 == 8)
                {
                    switch (array[key] % 4)
                    {
                        case 0:
                            array[key - 1] = Pow(array[key - 1], 4);
                            break;
                        case 1:
                            array[key - 1] = Pow(array[key - 1], 5);
                            break;
                        case 2:
                            array[key - 1] = Pow(array[key - 1], 6);
                            break;
                        case 3:
                            array[key - 1] = Pow(array[key - 1], 7);
                            break;
                    }
                }
                else if (array[key - 1] % 10 == 4 || array[key - 1] % 10 == 9 || array[key - 1] % 10 == 1)
                {
                    switch (array[key] % 2)
                    {
                        case 0:
                            array[key - 1] = Pow(array[key - 1], 2);
                            break;
                        case 1:
                            array[key - 1] = Pow(array[key - 1], 3);
                            break;
                    }
                }
                else if (array[key - 1] % 10 == 5)
                {
                    array[key - 1] = 25;
                }
                else if (array[key - 1] % 10 == 6)
                {
                    array[key - 1] = 36;
                }
                else if (array[key - 1] % 10 == 0)
                {

                    array[key - 1] *= array[key - 1];

                }
                var array2 = new int[key];
                for (int i = 0; i < key; i++)
                    array2[i] = array[i];
                array = array2;
            }
            return array[0] % 10;
        }

        public static int Pow(int a, int b)
        {
            var result = GetDigs(a);
            for (int i = 1; i < b; i++)
                result = GetDigs(result * a);
            return result;
        }

        public static int GetDigs(int a) {
            if (a > 1000)
                return a % 1000;
            return a;
        }
    }
}

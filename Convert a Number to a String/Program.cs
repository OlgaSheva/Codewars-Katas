using System;

namespace Convert_a_Number_to_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1 + 2;
            string s = Kata.NumberToString(i);
            Console.WriteLine(s);

            string str = "I love arrays they are my favorite";
            Console.WriteLine(Solution.StringToArray(str));

            string[] s1 = {"1", "2", "3"};
            double[] s2 = stringArrayMethods.ToDoubleArray(s1);
            Console.WriteLine(s2);

            Console.ReadKey();
        }
    }

    public class Kata
    {
        public static string NumberToString(int num)
        {
            // code here
            return Convert.ToString(num);

        }
    }

    public class Solution
    {
        public static string[] StringToArray(string str)
        {
            string[] s = str.Split(" ");
            return s;
        }
    }

    public class stringArrayMethods
    {
        public static double[] ToDoubleArray(string[] stringArray)
        {
            double[] dArray = new double[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                dArray[i] = Convert.ToDouble(stringArray[i]);
            }
            return dArray;
        }
    }
}

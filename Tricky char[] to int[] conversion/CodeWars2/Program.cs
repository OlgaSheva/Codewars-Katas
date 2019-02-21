using System;
using System.Linq;

//In this Kata you need to complete Convert method, which makes conversion from array of chars to array of integers.But it is a bit tricky conversion. Your task (step by step):

//1) Convert all chars to integers (if char is not a digit, then you should replace it with index of that element in array)

//char[]
//array = new char[] {'2','5','a','7','b','a'}
//// becomes
//int[] {2,5,2,7,4,5}
////If it`s still unclear for you, watch indexes carefully: array[2]=='a', array[4]=='b', array[5]=='a'
//2) If 'passOddIndexes' flag was set*, then you should remove all values with odd indexes

//int[] array = new int[] { 3, 4, 5, 6 }
////if (passOddIndexes == true) {...}
////removed array[1], array[3]  
//int[] {3,5}
//*if flag wasn't set, you don't need to remove any values

//3) return an array sorted in descending order

//int[] array = new int[] { 2, 1, 5 }
////sorted in descending order
//int[] {5,2,1}
//if input array is null or array contains no elements, then return null

namespace CodeWars2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] array = new char[] {  };
            int[] array1 = Kata.Convert(array, true);
            foreach (int a in array1)
            {
                Console.Write(a + " ");
            }
            Console.ReadKey();
        }
    }

    public static class BytesExtensions
    {
        public static bool IsEmpty(this byte[] source, byte value = 0xFF)
        {
            return source == null || source.All(x => x == value);
        }
    }

    public class Kata
    {
        public static int[] Convert(char[] input, bool passOddIndexes)
        {
            if ((input == null) || (input.Length == 0))
                return null;
            
                string[] arrays = new string[input.Length];
                int[] array = new int[input.Length];
                int[] array1;

                // char to int
                for (int i = 0; i < input.Length; i++)
                {
                    arrays[i] = input[i].ToString();
                    try
                    {
                        array[i] = System.Convert.ToInt32(arrays[i]);
                    }
                    catch
                    {
                        array[i] = i;
                    }
                }


                // remove all values with odd indexes
                if (passOddIndexes == true)
                {
                    if (array.Length % 2 == 0)
                        array1 = new int[array.Length / 2];
                    else
                        array1 = new int[array.Length / 2 + 1];

                    int k = 0;
                    for (int i = 0; i < array.Length; i = i + 2)
                    {
                        array1[k] = array[i];
                        k++;
                    }

                    array = array1;
                }

                // sort
                Array.Sort(array);
                Array.Reverse(array);

                return array;
        }
    }
}

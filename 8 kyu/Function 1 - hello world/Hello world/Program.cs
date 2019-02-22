using System;

namespace Hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.greet());

            Console.ReadKey();
        }
    }

    public static class Kata
    {
        // Write a public static method "greet" that returns "hello world!"
        public static string greet()
        {
            return "hello world!";
        }
    }
}

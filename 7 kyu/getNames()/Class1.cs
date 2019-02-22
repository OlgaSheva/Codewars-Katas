using System;
using System.Linq;

namespace getNames__
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] data = new Person[]
            {
              new Person("Joe", 20),
              new Person("Bill", 30),
              new Person("Kate", 23)
            };
            
            string[] names = Kata.GetNames(data);

            for (int i = 0; i < data.Length; i++)
                Console.WriteLine(data[i].Name);

            Console.ReadKey();
        }
    }

    public class Kata
    {
        public static string[] GetNames(Person[] data)
        {
            string[] names = new string[data.Length];
            for (int i = 0; i < data.Length; i++)
                names[i] = data[i].Name;
            return names;
        }
    }

    public class Person
    {
        public int Age;
        public string Name;

        public Person(string name = "John", int age = 21)
        {
            Age = age;
            Name = name;
        }
    }

}

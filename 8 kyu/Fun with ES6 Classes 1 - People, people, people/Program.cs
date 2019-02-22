using System;

namespace Fun_with_ES6_Classes_1___People__people__people
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Person(string firstName = "John", string lastName = "Doe", int age = 0, string gender = "Male")
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Gender = gender;
        }

        public string SayFullName()
        {
            string fullname = FirstName + " " + LastName;
            return fullname;
        }

        public static string GreetExtraTerrestrials(string raceName)
        {
            return "Welcome to Planet Earth " + raceName;
        }
    }
}

using System;

namespace Fun_with_ES6_Classes_2___Animals_and_Inheritance
{
    public class Shark : Animal
    {
        private static string species = "shark";
        private static int legs = 0;
        public Shark(string name, int age, string status) : base(name, age, legs, species, status) { }
    }

    public class Cat : Animal
    {
        private static string species = "cat";
        private static int legs = 4;
        public Cat(string name, int age, string status) : base(name, age, legs, species, status) { }

        public override string Introduce()
        {
            return $"Hello, my name is {this.Name} and I am {this.Age} years old.  Meow meow!";
        }
    }

    public class Dog : Animal
    {
        private static string species = "dog";
        private static int legs = 4;
        private string Master;
        public Dog(string name, int age, string status, string master) : base(name, age, legs, species, status)
        {
            this.Master = master;
        }

        public string GreetMaster()
        {
            return $"Hello {this.Master}";
        }
    }
}

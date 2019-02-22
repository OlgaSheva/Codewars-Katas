using System;

namespace Fun_with_ES6_Classes_2___Animals_and_Inheritance
{
    public class Animal
    {
        public int Age;
        public int Legs;
        public string Name;
        public string Species;
        public string Status;

        public Animal(string name, int age, int legs, string species, string status)
        {
            this.Name = name;
            this.Age = age;
            this.Legs = legs;
            this.Species = species;
            this.Status = status;
        }

        public virtual string Introduce()
        {
            return $"Hello, my name is {this.Name} and I am {this.Age} years old.";
        }
    }
}

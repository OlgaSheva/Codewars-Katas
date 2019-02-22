using System;

namespace Basic_subclasses___Adam_and_Eve
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class God
    {
        public static Human[] Create()
        {
            Man man = new Man();
            Woman woman = new Woman();

            Human[] human = { man, woman };
            return human;
        }        
    }

    public class Human { }

    public class Man : Human { }

    public class Woman : Human { }
}

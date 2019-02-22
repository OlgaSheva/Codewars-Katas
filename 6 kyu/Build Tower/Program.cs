using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Tower
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tower = Kata.TowerBuilder(3);

           foreach (string s in tower)
            {
                Console.WriteLine(s);
            }
        }
    }

    public class Kata
    {
        public static string[] TowerBuilder(int nFloors)
        {
            char[] floor = new char[nFloors * 2 - 1];
            string[] tower = new string[nFloors];

            for (int i = 0; i < nFloors; i++)
            {
                for (int j = 0; j < floor.Length; j++)
                {
                    if (j < floor.Length - i - nFloors || j > floor.Length + i - nFloors)
                        floor[j] = ' ';
                    else
                        floor[j] = '*';
                }
                tower[i] = new string(floor);
            }

            return tower;
        }
    }
}

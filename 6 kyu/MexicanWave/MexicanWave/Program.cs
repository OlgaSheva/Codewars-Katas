using System;
using System.Collections.Generic;

namespace MexicanWave
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> result = new Kata().wave(" gap ");

            foreach(var r in result)
            {
                Console.WriteLine(r);
            }

            Console.ReadKey();
        }
    }

    public class Kata
    {
        public List<string> wave(string str)
        {
            var ch = str.ToCharArray();
            char[] chlist = new char[str.Length];
            var list = new List<string>();

            for (var i = 0; i < ch.Length; i++)
            {
                if (ch[i] == ' ')
                    continue;
                for (var j = 0; j < ch.Length; j++)
                {
                    if (i == j)
                        chlist[j] = Char.ToUpper(ch[i]);                    
                    else
                        chlist[j] = ch[j];
                }

                list.Add(new string(chlist));
            }

            return list;
        }
    }
}

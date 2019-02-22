using System;
using System.Collections.Generic;

namespace String_basics
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "  uidin name whitespace, uidONE, uidtwo, #uidswagger, uid12 345,    uidABC ";
            string[] sArray = Kata.GetUserIds(s);

            foreach (string str in sArray)
                Console.WriteLine(str);
            Console.ReadKey();
        }
    }

    public class Kata
    {
        public static string[] GetUserIds(string s)
        {
            string[] sElements = s.Split(',');

            for (int j = 0; j < sElements.Length; j++)
            {
                // delete spaces
                sElements[j].Trim();

                char[] id = sElements[j].ToCharArray();
                
                // delete sharps
                if (sElements[j].Contains("#"))
                {
                    List<char> idWithoutSharp = new List<char>();
                    for (int i = 0; i < id.Length; i++)
                        if (id[i] != '#')
                            idWithoutSharp.Add(id[i]);
                    id = idWithoutSharp.ToArray();
                }

                // delete 'uid'
                char[] idWithoutUid = new char[id.Length - 3];
                for (int i = 0; i < id.Length - 3; i++)
                    idWithoutUid[i] = id[i + 3];

                sElements[j] = (new string(idWithoutUid)).ToLower();       
            }
            return sElements;
        }
    }
}

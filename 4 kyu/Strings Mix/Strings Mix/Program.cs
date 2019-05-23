using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strings_Mix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Mixing.Mix("Are they here", "yes, they are here"));
            Console.WriteLine("2:eeeee/2:yy/=:hh/=:rr");
            Console.WriteLine();

            Console.WriteLine(Mixing.Mix(" In many languages", " there's a pair of functions"));
            Console.WriteLine("1:aaa/1:nnn/1:gg/2:ee/2:ff/2:ii/2:oo/2:rr/2:ss/2:tt");
            Console.WriteLine();

            Console.WriteLine(Mixing.Mix("Lords of the Fallen", "gamekult"));
            Console.WriteLine("1:ee/1:ll/1:oo");
            Console.WriteLine();

            Console.WriteLine(Mixing.Mix("A generation must confront the looming ", "codewarrs"));
            Console.WriteLine("1:nnnnn/1:ooooo/1:tttt/1:eee/1:gg/1:ii/1:mm/=:rr");
            Console.WriteLine();

            Console.WriteLine(Mixing.Mix("looping is fun but dangerous", "less dangerous than coding"));
            Console.WriteLine("1:ooo/1:uuu/2:sss/=:nnn/1:ii/2:aa/2:dd/2:ee/=:gg");
            Console.ReadKey();
        }
    }

    public class Mixing
    {
        public static string Mix(string s1, string s2)
        {
            if (s1 == null || s2 == null)
                throw new ArgumentNullException();
            if (s1.Equals(s2))
                return "";

            s1 = s1.Replace(" ", String.Empty);
            s2 = s2.Replace(" ", String.Empty);

            var d1 = CountTheFrequency(s1).ToDictionary(pair => pair.Key, pair => pair.Value);
            var d2 = CountTheFrequency(s2).ToDictionary(pair => pair.Key, pair => pair.Value);
            var d1copy = d1.ToDictionary(entry => entry.Key, entry => entry.Value);
            var d2copy = d2.ToDictionary(entry => entry.Key, entry => entry.Value);

            int val = d1.First().Value > d2.First().Value ? d1.First().Value : d2.First().Value;
            var result = new HashSet<char>[val - 1, 3];
            for (int i = result.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = result.GetLength(1) - 1; j >= 0; j--)
                {
                    result[i, j] = new HashSet<char>();
                }
            }

            int v = val;
            while (v != 1)
            {
                foreach (var i in d1)
                {
                    foreach (var j in d2)
                    {
                        if (i.Value < v && j.Value < v)
                            break;
                        // Matching characters.
                        if ((j.Key == i.Key) && (j.Value == v || i.Value == v))
                        {
                            if (i.Equals(j) && i.Value != 1)
                                result[v - 2, 2].Add(i.Key);
                            else if (i.Key == j.Key && i.Value > j.Value && i.Value <= v && j.Value <= v)
                                result[v - 2, 0].Add(i.Key);
                            else if (i.Key == j.Key && i.Value < j.Value && i.Value <= v && j.Value <= v)
                                result[v - 2, 1].Add(i.Key);
                            d1copy.Remove(i.Key);
                            d2copy.Remove(j.Key);
                            break;
                        }
                    }
                }
                v--;
            }
            
            v = val;
            while (v != 1)
            {
                foreach (var item in d1copy)
                    if (item.Value == v)
                        result[v - 2, 0].Add(item.Key);
                v--;
            }

            v = val;
            while (v != 1)
            {
                foreach (var item in d2copy)
                    if (item.Value == v)
                        result[v - 2, 1].Add(item.Key);
                v--;
            }
            
            var sresult = new StringBuilder();
            for (int i = result.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    var resultitem = result[i, j].ToList();
                    resultitem.Sort();
                    foreach (var item in resultitem)
                    {
                        switch (j)
                        {
                            case 0:
                                sresult.Append('1');
                                break;
                            case 1:
                                sresult.Append('2');
                                break;
                            case 2:
                                sresult.Append('=');
                                break;
                        }
                        sresult.Append(":"+ new string(item, i+2) + "/");
                    }                    
                }
            }
            string strresult = sresult.ToString().Remove(sresult.Length - 1);
            return strresult;
        }

        public static IOrderedEnumerable<KeyValuePair<char, int>> CountTheFrequency(string s)
        {
            var n = s.ToCharArray();
            var dictionary = new SortedDictionary<char, int>();

            foreach (var item in n)
            {
                // only lowercase
                if (Char.IsLower(item))
                {
                    if (dictionary != null && dictionary.ContainsKey(item))
                        dictionary[item] += 1;
                    else
                        dictionary.Add(item, 1);
                }
            }

            var ordered = dictionary.OrderByDescending(x => x.Value);
            return ordered;
        }
    }
}

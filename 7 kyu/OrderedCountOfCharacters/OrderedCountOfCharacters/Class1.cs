using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderedCountOfCharacters
{
    public class Kata
    {
        public static List<Tuple<char, int>> OrderedCount(string input)
        {
            var charInput = input.ToCharArray();
            var output = new List<Tuple<char, int>>();

            var mapCharInput = new HashSet<char>();
            foreach(var c in charInput)
                mapCharInput.Add(c);

            int count;
            foreach (var m in mapCharInput)
            {
                count = 0;
                foreach (var c in charInput)
                {
                    if (m == c)
                        count++;
                }
                output.Add(new Tuple<char, int>(m, count));
            }

            return output;
        }
    }
}

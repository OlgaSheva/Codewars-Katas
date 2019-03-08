using System;
using System.Text;

namespace Mumbling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Accumul.Accum("ZpglnRxqenU")); // "Z-Pp-Ggg-Llll-Nnnnn-Rrrrrr-Xxxxxxx-Qqqqqqqq-Eeeeeeeee-Nnnnnnnnnn-Uuuuuuuuuuu");
        }
    }

    public class Accumul
    {
        public static String Accum(string s)
        {
            var sArray = s.ToCharArray();
            var sBuilder = new StringBuilder();

            for (var i = 0; i < s.Length; i++)
            {
                if (i == 0)
                    sBuilder.Append(Char.ToUpper(sArray[i]));  
                else
                {
                    sBuilder.Append('-');
                    sBuilder.Append(Char.ToUpper(sArray[i]));
                    sBuilder.Append(Char.ToLower(sArray[i]), i);
                }
            }

            return sBuilder.ToString();
        }
    }
}

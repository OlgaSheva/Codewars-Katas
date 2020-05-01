using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Decode_the_Morse_code__advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DecodeMorse(DecodeBits("1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011")));
            Console.WriteLine(DecodeMorse(DecodeBits("111000000111")));
            Console.WriteLine(DecodeMorse(DecodeBits("110011")));
            Console.WriteLine(DecodeMorse(DecodeBits("01110")));
            Console.ReadKey();
        }

        public static string DecodeBits(string bits)
        {
            bits = bits.Trim('0');

            var m = new Regex(@"([0|1])\1*").Matches(bits);
            var strm = new Match[m.Count];
            m.CopyTo(strm, 0);
            int n = strm.OrderBy(x => x.Value.Length).First().Value.Length;

            var morse = bits
                    .Replace(new string('0', 7*n), "   ")
                    .Replace(new string('0', 3*n), " ")
                    .Replace(new string('1', 3*n), "-")
                    .Replace(new string('1', n), ".")
                    .Replace(new string('0', n), String.Empty);
            if (morse == "-") return ".";
            return morse;
        }

        public static string DecodeMorse(string morseCode)
        {
            var chars = morseCode
                        .Trim()
                        .Replace("   ", " W ")
                        .Split(' ')
                        .Select(word => word == "W" ? " " : MorseCode.Get(word));
            return string.Join("", chars);
        }
    }

    public static class MorseCode
    {
        private static readonly Dictionary<char, string> morseAlphabet = new Dictionary<char, string>()
                                   {
                                       {'a', ".-"},
                                       {'b', "-..."},
                                       {'c', "-.-."},
                                       {'d', "-.."},
                                       {'e', "."},
                                       {'f', "..-."},
                                       {'g', "--."},
                                       {'h', "...."},
                                       {'i', ".."},
                                       {'j', ".---"},
                                       {'k', "-.-"},
                                       {'l', ".-.."},
                                       {'m', "--"},
                                       {'n', "-."},
                                       {'o', "---"},
                                       {'p', ".--."},
                                       {'q', "--.-"},
                                       {'r', ".-."},
                                       {'s', "..."},
                                       {'t', "-"},
                                       {'u', "..-"},
                                       {'v', "...-"},
                                       {'w', ".--"},
                                       {'x', "-..-"},
                                       {'y', "-.--"},
                                       {'z', "--.."},
                                       {'0', "-----"},
                                       {'1', ".----"},
                                       {'2', "..---"},
                                       {'3', "...--"},
                                       {'4', "....-"},
                                       {'5', "....."},
                                       {'6', "-...."},
                                       {'7', "--..."},
                                       {'8', "---.."},
                                       {'9', "----."}
                                   };

        public static string Get(string s)
        {
            return morseAlphabet.FirstOrDefault(x => x.Value == s).Key.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = ".... . -.--   .--- ..- -.. .";
            string expected = "HEY JUDE";

            string actual = Decode(input);
            Console.WriteLine(input);
            Console.WriteLine(actual);
            Console.WriteLine(actual.ToUpper() == expected);
            Console.ReadKey();
        }

        public static string Decode(string morseCode)
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

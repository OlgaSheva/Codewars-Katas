using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.ReadKey();
        }

        public static string Decode(string morseCode)
        {
            morseCode.Trim();
            var oneSymbol = new StringBuilder();
            var result = new StringBuilder();
            int spaceCount = 0;

            foreach (var symbol in morseCode)
            {
                if (symbol != ' ')
                {
                    oneSymbol.Append(symbol);
                    spaceCount = 0;
                }
                else
                {
                    AddSymbol(oneSymbol, result);

                    spaceCount++;
                    if (spaceCount == 3)
                    {
                        result.Append(' ');
                        spaceCount = 0;
                    }
                }
            }

            AddSymbol(oneSymbol, result);

            return result.ToString().Trim();
        }

        private static void AddSymbol(StringBuilder oneSymbol, StringBuilder result)
        {
            if (oneSymbol.Length > 0)
            {
                result.Append(MorseCode.Get(oneSymbol.ToString()));
                oneSymbol.Clear();
            }
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

        public static char Get(string s)
        {
            return morseAlphabet.FirstOrDefault(x => x.Value == s).Key;
        }
    }
}

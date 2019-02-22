using System;

//Input: String containing different "words" separated by spaces

//1. More than one word? Reverse each word and combine first with second, third with fourth and so on...
//   (odd number of words => last one stays alone, but has to be reversed too)
//2. Start it again as long as there's only one word without spaces
//3. Return your result...
//Some easy examples:

//Input:  "abc def"
//Output: "cbafed"


namespace ReversingAndCombiningText
{
    class Program
    {
        public static void Main(string[] args)
        {
            Kata kata = new Kata();
            string output = kata.reverseAndCombineText("cbafed");
            Console.WriteLine(output);
            Console.ReadKey();              // 43hgff434cbafed343ire_55321
        }
    }

    public class Kata
    {
        static void reverse(char[] symbols)
        {
            for (int i = 0; i < symbols.Length / 2; i++)
            {
                char temp = symbols[i];
                symbols[i] = symbols[symbols.Length - 1 - i];
                symbols[symbols.Length - 1 - i] = temp;
            }
        }

        public string reverseAndCombineTwoWords(string[] words, int i)
        {
            char[] symbols1 = words[i].ToCharArray();
            reverse(symbols1);
            char[] symbols2 = words[i+1].ToCharArray();
            reverse(symbols2);

            return new string(symbols1) + new string(symbols2);
        }

        public string reverseAndCombineOneWord(string[] words, int i)
        {
            char[] symbols1 = words[i].ToCharArray();
            reverse(symbols1);

            return new string(symbols1);
        }

        public string reverseAndCombineText(string text)
        {
            string[] words;
            do {
                words = text.Split(" ");
                if (words.Length == 1)
                    return text;
                string newText = null;
                int j = 0;
                for (int i = 0; i < words.Length; i = i + 2)
                {
                    if (i < words.Length - 2)
                        newText += reverseAndCombineTwoWords(words, i) + " ";
                    else if (i == words.Length - 1)
                        newText += reverseAndCombineOneWord(words, i);
                    else
                        newText += reverseAndCombineTwoWords(words, i);
                }
                text = newText;
            } while (words.Length > 2);
            return text;
        }
    }
}


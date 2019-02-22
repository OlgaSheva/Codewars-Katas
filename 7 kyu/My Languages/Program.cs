using System;
using System.Collections.Generic;

//Given a dictionary/hash/object of languages and your respective test results, return the list of languages where your test score is at least 60, in descending order of the results.

//Note: There will be no duplicate values.

//Examples
//new Dictionary<string, int> {{"Java", 10}, {"Ruby", 80}, {"Python", 65}} => {"Ruby", "Python"}
//new Dictionary<string, int> {{"Hindi", 60}, {"Greek", 71}, {"Dutch", 93}} => {"Dutch", "Greek", "Hindi"}
//new Dictionary<string, int> {{"C++", 50}, {"ASM", 10}, {"Haskell", 20}} => {}

namespace My_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int> { { "Java", 10 }, { "Ruby", 80 }, { "Python", 65 } };

            IEnumerable<string> result = new List<string>();
            result = Kata.MyLanguages(dictionary);


            Console.WriteLine(result);
        }
    }

    public static class Kata
    {
        public static IEnumerable<string> MyLanguages(Dictionary<string, int> results)
        {
            var listResults = new List<KeyValuePair<string, int>>();
            foreach (var r in results)
                if (r.Value >= 60)
                    listResults.Add(r);

            listResults.Sort((a, b) => b.Value.CompareTo(a.Value));

            List<string> resultsKeysThatsValuesMoreThan60 = new List<string>();
            foreach (var item in listResults)
                resultsKeysThatsValuesMoreThan60.Add(item.Key);

            return resultsKeysThatsValuesMoreThan60;
        }
    }
}

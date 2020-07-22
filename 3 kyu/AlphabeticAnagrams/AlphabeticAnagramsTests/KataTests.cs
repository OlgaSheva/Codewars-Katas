using AlphabeticAnagrams;
using NUnit.Framework;

namespace AlphabeticAnagramsTests
{
    public class KataTests
	{
		[TestCase("A", 1)]
		[TestCase("ABAB", 2)]
		[TestCase("AAAB", 1)]
		[TestCase("BAAA", 4)]
		[TestCase("BCCAB", 17)]
		[TestCase("CABBC", 19)]
		[TestCase("QUESTION", 24572)]
		[TestCase("BOOKKEEPER", 10743)]
		[TestCase("MUCHOCOMBINATIONS", 1938852339039)]
		[TestCase("ODTOGTWYMHJNLV", 11059004523)]
		public void TestNumberToOrdinal(string value, long expected)
		{
			Assert.AreEqual(expected, Kata.ListPosition(value), string.Format("Input {0}", value));
		}
	}
}
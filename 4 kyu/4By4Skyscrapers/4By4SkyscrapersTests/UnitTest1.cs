using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _4By4Skyscrapers;

namespace _4By4SkyscrapersTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RemoveRepeatedInRowsAndColumnsSkyscrapersTest()
        {
            var actual = new List<int>[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    actual[i, j] = new List<int>() { 1, 2, 3, 4 };
            actual[0, 2] = new List<int> { 4 };
            actual[0, 3] = new List<int> { 3 };
            Skyscrapers.RemoveRepeatedInRowsAndColumnsSkyscrapers(actual);

            var expected = new List<int>[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    expected[i, j] = new List<int>() { 1, 2, 3, 4 };
            expected[0, 0] = new List<int> { 1, 2 };
            expected[0, 1] = new List<int> { 1, 2 };
            expected[0, 3] = new List<int> { 3 };
            expected[1, 2] = new List<int> { 1, 2, 3 };
            expected[2, 2] = new List<int> { 1, 2, 3 };
            expected[3, 2] = new List<int> { 1, 2, 3 };

            CollectionAssert.AreEqual(expected[0,0], actual[0,0]);
        }

        [TestMethod]
        public void SolveSkyscrapers1()
        {
            var clues = new[]{ 2, 2, 1, 3,
                               2, 2, 3, 1,
                               1, 2, 2, 3,
                               3, 2, 1, 3};

            var expected = new[]{  new []{1, 3, 4, 2},
                                   new []{4, 2, 1, 3},
                                   new []{3, 4, 2, 1},
                                   new []{2, 1, 3, 4 }};

            var actual = Skyscrapers.SolvePuzzle(clues);
            CollectionAssert.AreEqual(expected[0], actual[0]);
        }

        [TestMethod]
        public void SolveSkyscrapers2()
        {
            var clues = new[]{ 0, 0, 1, 2,
                               0, 2, 0, 0,
                               0, 3, 0, 0,
                               0, 1, 0, 0};

            var expected = new[]{  new []{2, 1, 4, 3},
                                   new []{3, 4, 1, 2},
                                   new []{4, 2, 3, 1},
                                   new []{1, 3, 2, 4}};

            var actual = Skyscrapers.SolvePuzzle(clues);
            CollectionAssert.AreEqual(expected[0], actual[0]);
        }

        [TestMethod]
        public void SolveSkyscrapers3()
        {
            var clues = new[]{ 0, 2, 0, 1,
                               1, 2, 2, 2,
                               0, 1, 0, 3,
                               0, 2, 1, 0};

            var expected = new[]{  new []{1, 2, 3, 4},
                                   new []{4, 1, 2, 3},
                                   new []{3, 4, 1, 2},
                                   new []{2, 3, 4, 1}};

            var actual = Skyscrapers.SolvePuzzle(clues);
            CollectionAssert.AreEqual(expected[0], actual[0]);
        }

        [TestMethod]
        public void SolveSkyscrapers4()
        {
            var clues = new[]{ 2, 2, 2, 0,
                               0, 2, 2, 2,
                               4, 0, 2, 3,
                               3, 2, 0, 0};

            var expected = new[]{  new []{1, 2, 3, 4},
                                   new []{4, 1, 2, 3},
                                   new []{3, 4, 1, 2},
                                   new []{2, 3, 4, 1}};

            var actual = Skyscrapers.SolvePuzzle(clues);
            CollectionAssert.AreEqual(expected[0], actual[0]);
        }

        [TestMethod]
        public void SolveSkyscrapers5()
        {
            var clues = new[]{ 0, 0, 0, 0,
                               3, 0, 0, 0,
                               0, 0, 1, 2,
                               0, 2, 4, 0};

            var expected = new[]{  new []{4, 3, 1, 2},
                                   new []{1, 2, 3, 4},
                                   new []{2, 1, 4, 3},
                                   new []{3, 4, 2, 1}};

            var actual = Skyscrapers.SolvePuzzle(clues);
            CollectionAssert.AreEqual(expected[0], actual[0]);
            CollectionAssert.AreEqual(expected[1], actual[1]);
            CollectionAssert.AreEqual(expected[2], actual[2]);
            CollectionAssert.AreEqual(expected[3], actual[3]);
        }

        [TestMethod]
        public void SolveSkyscrapers7()
        {
            var clues = new[]{ 0, 0, 3, 0,
                               3, 0, 0, 1,
                               0, 0, 0, 0,
                               0, 0, 1, 0};

            var expected = new[]{  new []{3, 4, 2, 1},
                                   new []{4, 1, 3, 2},
                                   new []{1, 2, 4, 3},
                                   new []{2, 3, 1, 4}};

            var actual = Skyscrapers.SolvePuzzle(clues);
            CollectionAssert.AreEqual(expected[0], actual[0]);
            CollectionAssert.AreEqual(expected[1], actual[1]);
            CollectionAssert.AreEqual(expected[2], actual[2]);
            CollectionAssert.AreEqual(expected[3], actual[3]);
        }

        [TestMethod]
        public void SolveSkyscrapers8()
        {
            var clues = new[]{ 0, 2, 0, 0,
                               0, 0, 4, 2,
                               0, 0, 0, 0,
                               0, 0, 0, 3};

            var expected = new[]{  new []{2, 1, 3, 4},
                                   new []{3, 4, 1, 2},
                                   new []{4, 3, 2, 1},
                                   new []{1, 2, 4, 3}};

            var actual = Skyscrapers.SolvePuzzle(clues);
            CollectionAssert.AreEqual(expected[0], actual[0]);
            CollectionAssert.AreEqual(expected[1], actual[1]);
            CollectionAssert.AreEqual(expected[2], actual[2]);
            CollectionAssert.AreEqual(expected[3], actual[3]);
        }

        [TestMethod]
        public void SolveSkyscrapers9()
        {
            var clues = new[]{ 2, 2, 2, 1,
                               1, 2, 2, 3,
                               4, 2, 3, 1,
                               1, 3, 2, 2};

            var expected = new[]{  new []{3, 1, 2, 4},
                                   new []{2, 4, 1, 3},
                                   new []{1, 3, 4, 2},
                                   new []{4, 2, 3, 1}};

            var actual = Skyscrapers.SolvePuzzle(clues);
            CollectionAssert.AreEqual(expected[0], actual[0]);
            CollectionAssert.AreEqual(expected[1], actual[1]);
            CollectionAssert.AreEqual(expected[2], actual[2]);
            CollectionAssert.AreEqual(expected[3], actual[3]);
        }

        [TestMethod]
        public void SolveSkyscrapers10()
        {
            var clues = new[]{ 0, 0, 3, 0,
                               0, 2, 0, 0,
                               0, 2, 2, 0,
                               0, 0, 0, 0};

            var expected = new[]{  new []{2, 3, 1, 4},
                                   new []{1, 4, 2, 3},
                                   new []{3, 1, 4, 2},
                                   new []{4, 2, 3, 1}};

            var actual = Skyscrapers.SolvePuzzle(clues);
            CollectionAssert.AreEqual(expected[0], actual[0]);
            CollectionAssert.AreEqual(expected[1], actual[1]);
            CollectionAssert.AreEqual(expected[2], actual[2]);
            CollectionAssert.AreEqual(expected[3], actual[3]);
        }

        [TestMethod]
        public void SolveSkyscrapers11()
        {
            var clues = new[]{ 0, 0, 0, 0,
                               3, 0, 0, 0,
                               2, 2, 2, 0,
                               0, 0, 0, 0};

            var expected = new[]{  new []{1, 4, 3, 2},
                                   new []{2, 1, 4, 3},
                                   new []{3, 2, 1, 4},
                                   new []{4, 3, 2, 1}};

            var actual = Skyscrapers.SolvePuzzle(clues);
            CollectionAssert.AreEqual(expected[0], actual[0]);
            CollectionAssert.AreEqual(expected[1], actual[1]);
            CollectionAssert.AreEqual(expected[2], actual[2]);
            CollectionAssert.AreEqual(expected[3], actual[3]);
        }

        [TestMethod]
        public void SolveSkyscrapers12()
        {
            var clues = new[]{ 0, 0, 0, 0,
                               0, 0, 0, 0,
                               3, 1, 2, 3,
                               3, 2, 4, 1};

            var expected = new[]{  new []{4, 1, 2, 3},
                                   new []{1, 2, 3, 4},
                                   new []{3, 4, 1, 2},
                                   new []{2, 3, 4, 1}};

            var actual = Skyscrapers.SolvePuzzle(clues);
            CollectionAssert.AreEqual(expected[0], actual[0]);
            CollectionAssert.AreEqual(expected[1], actual[1]);
            CollectionAssert.AreEqual(expected[2], actual[2]);
            CollectionAssert.AreEqual(expected[3], actual[3]);
        }
    }

}

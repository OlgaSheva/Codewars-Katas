using NUnit.Framework;
using Validator;

namespace ValidatorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCase()
        {
            int[,] field = new int[10, 10]
                           {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                            {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                            {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                            {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                            {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            Assert.IsTrue(BattleshipField.ValidateBattlefield(field));
        }

        [Test]
        public void TestCase2()
        {
            int[,] field = new int[10, 10]
                           {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                            {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                            {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 1, 0, 0, 0, 0, 0, 0, 1, 0},
                            {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                            {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            Assert.IsFalse(BattleshipField.ValidateBattlefield(field));
        }
    }
}
using NUnit.Framework;
using ReverseASinglyLinkedList;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(new Node(3, null), Kata.ReverseList(new Node(3, null)));

            //Assert.AreEqual(new Node(3, new Node(2, new Node(1, new Node(0, null)))), Kata.ReverseList(new Node(0 , new Node(1, new Node(2, new Node(3, null))))));

            // For simplicity, Node can also be constructed using any non-empty IEnumerable<int>:
            // Assert.AreEqual(new Node(new int[] { 5, 4, 3, 2, 1 }), Kata.ReverseList(new Node(new int[] { 1, 2, 3, 4, 5 })));

        }
    }
}
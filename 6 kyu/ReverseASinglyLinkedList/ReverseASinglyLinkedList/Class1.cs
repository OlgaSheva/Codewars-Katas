using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseASinglyLinkedList
{
    public class Node
    {       
        public int Value { get; private set; }
        public Node Next { get; set; }

        public Node(int value, Node next)
        {
            Value = value;
            Next = next;
        }
    }

    public class Kata
    {
        public static Node ReverseList(Node node)
        {
            if (node == null || node.Next == null)
                return node;

            Node reverseNode = ReverseList(node.Next);

            node.Next.Next = node;
            node.Next = null;

            return reverseNode;
        }
    }
}

using System;
using System.Collections.Generic;

namespace ParseALinkedListFromAString
{
    public class Node : Object
    {
        public int Data;
        public Node Next;

        public Node(int data, Node next = null)
        {
            this.Data = data;
            this.Next = next;
        }

        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType()) { return false; }

            return this.ToString() == obj.ToString();
        }

        public override string ToString()
        {
            List<int> result = new List<int>();
            Node curr = this;

            while (curr != null)
            {
                result.Add(curr.Data);
                curr = curr.Next;
            }

            return String.Join(" -> ", result) + " -> null";
        }
    }

    public static class Kata
    {
        public static Node Parse(string nodes)
        {
            if (nodes == "null")
                return null;

            nodes = nodes.Replace("-> ", string.Empty);
            nodes = nodes.Replace(" null", string.Empty);
            string[] nodesElements = nodes.Split(' ');

            int[] intNodes = new int[nodesElements.Length];

            for (int i = 0; i < nodesElements.Length; i++)
                intNodes[i] = Convert.ToInt32(nodesElements[i]);

            Node node = new Node(intNodes[intNodes.Length - 1]);
            for (int j = intNodes.Length - 2; j >= 0; j --)
            {
                node = new Node(intNodes[j], node);
            }

            return node;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace FunWithListsMap
{
    public class Node<T>
    {
        public T data;
        public Node<T> next;

        public Node(T data)
        {
            this.data = data;
        }

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
    } 

    public class Kata
    {
        public static Node<T2> Map<T, T2>(Node<T> head, Func<T, T2> f)
        {
            if (head == null)
                return null;

            Node<T2> newList = null;
            newList = new Node<T2>(f(head.data), null);

            while (head.next != null)
            {                
                head = head.next;
                newList = new Node<T2>(f(head.data), newList);
                
            }

            newList = ReverseList(newList);

            return newList;
        }

        public static Node<T> ReverseList<T>(Node<T> node)
        {
            Node<T> head = null;

            while (node != null)
            {
                head = new Node<T>(node.data, head);
                node = node.next;
            }

            return head;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Node<int> node = Kata.Map<int, int>(new Node<int>(1, new Node<int>(2, new Node<int>(3))), n => n);
            string s = Stringify(node);
            Console.WriteLine(s);
        }

        public static string Stringify(Node<int> list)
        {
            string stringList = "";

            while (list != null)
            {
                stringList += list.data + " -> ";
                list = list.next;
            }
            stringList += "null";


            return stringList;
        }
    }
}



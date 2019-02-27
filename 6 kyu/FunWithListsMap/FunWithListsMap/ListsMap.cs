using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

            newList = new Node<T2>(f(head.data));
            while (head.next != null)
            {
                head = head.next;                
                newList.next = new Node<T2>(f(head.data));
                newList = newList.next;
            }

            return newList;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Node<int> node = Kata.Map<int, int>(new Node<int>(1, new Node<int>(2, new Node<int>(3))), n => n);
            Console.WriteLine(node);
        }
    }
}



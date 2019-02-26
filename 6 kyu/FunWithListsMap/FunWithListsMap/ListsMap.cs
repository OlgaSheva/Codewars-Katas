using System;
using System.Collections;
using System.Collections.Generic;

namespace FunWithListsMap
{
    public class Node<T>
    {
        private T data;
        public Node<T> next;
        
        public T Data { get; set; }

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
        public static IEnumerable<Node<T2>> Map<T, T2>(Node<T> head, Func<T, T2> f)
        {
            int i = 0;

            while (head != null)
                yield return f(head.Data);


        }
    }
}



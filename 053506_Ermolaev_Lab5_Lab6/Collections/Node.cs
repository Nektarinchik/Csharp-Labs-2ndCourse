using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Ermolaev_Lab5
{
    class Node<T>
    {
        public Node(T data)
        {
            Data = data;
            Next = null;
        }

        public Node(T data, Node<T> next)
        {
            Data = data;
            Next = next;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
}

using System;

namespace GenericLinkedList
{

    public class Node<T>
    {
        public Node(T t)
        {
            Next = null;
            Data = t;
        }

        public Node<T> Next { get; set; }
        public T Data { get; set; }
    }

    public class GenericList<T>
    {
        public Node<T> head;
        public Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action) {
            for(Node<T> node = this.Head; node != null; node = node.Next)
            {
                action(node.Data);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //整型list
            GenericList<int> intlist = new GenericList<int>();
            for(int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }

            intlist.ForEach(i => Console.WriteLine(i));
            int max = 0, min = 0;
            intlist.ForEach
            (
                m => {
                    if (m >= max) max = m;
                    if (m <= min) min = m;
                }
            );
            Console.WriteLine("最大值：{0}，最小值：{1}", max, min);

            //字符串型list
            GenericList<string> strlist = new GenericList<string>();
            for (int x = 0; x < 10; x++)
            {
                strlist.Add("str" + x);
            }

            strlist.ForEach
                (
                s => { Console.WriteLine(s); }
                );


            Console.ReadKey();

        }
    }


}

using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public class Cache
    {
        private int capacity;

        public Cache()
        {
            capacity = 5;
        }
        private Dictionary<int, string> data = new Dictionary<int, string>();

        

        private LinkedList<int> cachelist = new LinkedList<int>();

       // private LinkedList<KeyValuePair<int, string>> list1 = new LinkedList<KeyValuePair<int, string>>();
       // private KeyValuePair<int, string> kvp = new KeyValuePair<int, string>();
        public void printList()
        {
            foreach (var i in cachelist)
                Console.Out.Write("{0}",i.ToString());
            Console.Out.WriteLine();

           
        }
        public string Get(int x)
        {           
            if (data.ContainsKey(x))
            {              
                if (data.TryGetValue(x, out string val))
                {
                    LinkedListNode<int>  node = cachelist.Find(x);
                    cachelist.Remove(x);
                    cachelist.AddBefore(cachelist.First, node);
                }
                return val;
            }
            else
                return "-1";
        }

        public void Set(int x,string y)
        {
              if (cachelist.Count < capacity)
                {

                cachelist.AddFirst(x);
                 data.TryAdd(x, y);
                }
                else if (cachelist.Count == capacity)
                {
                    cachelist.RemoveLast();
                    cachelist.AddFirst(x);
                    data.TryAdd(x, y);
               }
        }
    }
}

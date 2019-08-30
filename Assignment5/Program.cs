using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {

            //int[] ip = new int[] {4,5,2,25};
            int[] ip = new int[] { 13,7,6,12};
            // GetNGE(ip);

            // QueueMadeStack();
            // StackMadeOfQueue();

            //GetMinElement();

            //LRUCache();
            FindFirstNonRepeatingChar();
          
        }

       

        /***
* 
* 1.Given an array, 
* print the Next Greater Element (NGE) for every element.
* The Next greater Element for an element x is the first 
* greater element on the right side of x in array.
* Elements for which no greater element exist, 
* consider next greater element as -1
* */
        private static void GetNGE(int[] ip)
        {
            Dictionary<int, int> op = new Dictionary<int, int>();
            int steps = 0;

            for (int i=0;i<ip.Length; i++)
            {
                steps++;
                bool found = false;
                for (int j=i+1;j<ip.Length;j++)
                {
                    steps++;
                    if (ip[i] < ip[j])
                    {
                        found = true;
                        op.Add(ip[i], ip[j]);
                        break;
                    }
                    
                }
                if (!found)
                {
                    op.Add(ip[i], -1);
                }
            }
            Console.Out.WriteLine(" element  NGE");
            foreach(var d in op)
            {
                Console.Out.WriteLine("{0}  {1}",d.Key , d.Value);
            }
            Console.Out.WriteLine("steps : {0}",steps);
        }
        /**
         * 2.Implement a Queue using 2 stackss1 and s2 .
         * */
        private static void QueueMadeStack()
        {
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();

            //enqueu 
            s1.Push(1);
            s1.Push(2);
            s1.Push(3);
            s1.Push(4);

            //s1 = 1,2,3,4

            //dequeue
            while (s1.Count != 0)
            {
                s2.Push(s1.Pop());
            }
            //s2 = 4,3,2,1
            Console.Out.WriteLine("dequeu: {0}", s2.Pop());
        }
        /**
         * 3 .Implement stack using 2 queues
         */
        private static void StackMadeOfQueue()
        {
            Queue<int> q1 = new Queue<int>();
            Queue<int> q2 = new Queue<int>();


            //push  = 1,2,3,4 

            q1.Enqueue(1);
            q1.Enqueue(2);
            q1.Enqueue(3);
            q1.Enqueue(4);

            //pop 4
            
            while (q1.Count != 1)
            { 
                q2.Enqueue(q1.Dequeue());
            }
            Console.Out.WriteLine("pop : {0}", q1.Dequeue());
                
                
        }



        /**
         * 4.Implement a Stack in which you can get min element in O(1) time and O(1) space.
         */

        private static Stack<int> minStack = new Stack<int>();
        private static int minValue = Int32.MinValue;
        private static void GetMinElement()
        {
            push(2);
            push(4);
            push(3);
            push(5);
            push(6);
            push(1);

            Console.Out.WriteLine(minValue);
        }

        private static void push(int data)
        {
            minStack.Push(data);
            minValue = minValue== Int32.MinValue ? data :minValue;
            minValue = data < minValue ? data : minValue;
        }

        private static void LRUCache()
        {
            Cache c = new Cache();
            c.Set(1,"I am 1");
            c.Set(2, "I am 2");
            c.Set(3, "I am 3");
            c.Set(4, "I am 4");
            c.Set(5,"I am 5");
            c.printList();
            Console.Out.WriteLine("value : {0}",c.Get(5));
            c.printList();
            c.Set(6,"I am 6");
            c.printList();
            Console.Out.WriteLine("value : {0}", c.Get(7));
            c.printList();
        }


        /***
         * 
         *Given an input stream of n characters consisting 
         * only of small case alphabets the task is to find the 
         * first non repeating character each time a character
         * is inserted to the stream. 
         * If no non repeating element is found print -1. 
         */

        private static void FindFirstNonRepeatingChar()
        {
            Dictionary<char, int> op = new Dictionary<char, int>();
            List<char> inputChar = new List<char>();
            bool found = false;
            while (true)
            {
                Console.Out.Write("Input String :");
                char ip = Console.ReadKey().KeyChar;
                Console.WriteLine();
                inputChar.Add(ip);
                //try adding the elemet
                if (!op.TryAdd(ip, 1))
                {
                    //duplicate value 
                    op.TryGetValue(ip,out int val);
                     op[ip] = val + 1;
                    //  op[ip] = -1;
                    found = false;
                   
                }
                //set found to true 
                foreach (var o in op)
                {
                    if (o.Value == 1)
                    {
                        Console.WriteLine("1st non repeating element: {0}", o.Key);
                        found = true;
                        break;
                    }
                }
                if (!found) Console.WriteLine("no non repeating element -1");
              
                //print the input array 
                Console.Write("(");
                foreach (var i in inputChar) Console.Write("{0}",i); 
                Console.Write(")\n");
               

            }
            

        }
              
    }
}

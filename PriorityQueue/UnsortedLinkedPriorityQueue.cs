using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{

    public class UnsortedLinkedPriorityQueue<T> : PriorityQueue<T>
    {
        private class Node
        {
            public PriorityItem<T> Entry;
            public Node Next;
            public Node(PriorityItem<T> Entry)
            {
                this.Entry = Entry;
                this.Next = null;
            }

        }

        private Node head;
        
        //private readonly PriorityItem<T>() storage;
        //private readonly int capacity;
        //private int tailIndex;

        public UnsortedLinkedPriorityQueue(int size)
        {
            head = null;
        }

        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return getHighestPriortiy().Entry.Item;
        }

        public void Add(T item, int priority)
        {
            Node newEnt = new Node(new PriorityItem<T>(item, priority));
            newEnt.Next = head;
            head = newEnt;

        }


        public void Remove()
        {
            //if (IsEmpty())
            //{
            //    throw new QueueUnderflowException();
            //}

            //for (int i = getHighestPriortiy(); i < count; i++)
            //{
            //    storage[i] = storage[i + 1];
            //}
            //count--;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            string result = "[";
            Node current = head;
            while (current != null)
            {
                result += current.ToString();
                current = current.Next;
            }

            //for (int i = 0; i <= count; i++)
            //{
            //    if (i > 0)
            //    {
            //        result += ", ";
            //    }
            //    result += storage[i];
            //}
            result += "]";
            return result;
        }

        //function to find the highest priority by looping through the array
        private Node getHighestPriortiy()
        {
            Node highest = head;
            Node current = head;
            while (current != null)
            {
                if (current.Entry.Priority > highest.Entry.Priority)
                {
                    highest = current;
                }
                current = current.Next;
            }

            return highest;
        }
    }
}
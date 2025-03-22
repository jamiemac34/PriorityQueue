using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// linked list code referenced from geeksforgeeks
// https://www.geeksforgeeks.org/linked-list-implementation-in-c-sharp/
// unless specified otherwise, the functions are direct copies from UnsorteLinkedPriorityQueue.cs

namespace PriorityQueue
{

    public class SortedLinkedPriorityQueue<T> : PriorityQueue<T>
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
        private int capacity;
        private int count;

        // replacing the array initialisations with a single node head initialisation
        public SortedLinkedPriorityQueue(int size)
        {
            head = null;
            capacity = size;
            count = -1;
        }

        // simplification to always return the head as it is always the highest
        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return head.Entry.Item;
        }

        // expansion to order when added, loops through to find the correct position to put the new entry
        public void Add(T item, int priority)
        {
            count++;
            if (count == capacity)
            {
                count--;
                throw new QueueOverflowException();
            }

            Node newEnt = new Node(new PriorityItem<T>(item, priority));
            if (head == null || head.Entry.Priority < newEnt.Entry.Priority) {
                newEnt.Next = head;
                head = newEnt; }
            else
            {
                Node current = head;
                while (current.Next != null && current.Next.Entry.Priority > newEnt.Entry.Priority) 
                {
                    current = current.Next;
                }
                newEnt.Next = current.Next;
                current.Next = newEnt;
            }
        }



        // simplification to always remove the head as it is always the highest
        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            head = head.Next;
            count--;

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
                result += current.Entry.ToString();
                current = current.Next;
            }

            result += "]";
            return result;
        }

    }
}
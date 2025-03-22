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
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            Node highest = getHighestPriortiy();
            Node current = head;
            Node previous = null;
            while (current != null && current != highest) { 
            
                previous = current;
                current = current.Next;
            }

            //determining what to do if once at the highest, removes head if it is the highest otherwise skips over it
            if (previous == null)
            {
                head = head.Next;
            }
            else
            {
                previous.Next = current.Next;
            }

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

        //function to find the highest priority by looping through the list
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
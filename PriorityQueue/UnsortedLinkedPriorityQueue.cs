using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// linked list code referenced from geeksforgeeks
// https://www.geeksforgeeks.org/linked-list-implementation-in-c-sharp/
// unless specified otherwise, the functions are direct copies from UnsortedArrayPriorityQueue.cs

namespace PriorityQueue
{

    public class UnsortedLinkedPriorityQueue<T> : PriorityQueue<T>
    {

        // creating a class for the nodes
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

        // replacing the array initialisations with a single node head initialisation
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

        // creates a new node, inserting it first by setting it's next to the current head and head to it
        public void Add(T item, int priority)
        {
            Node newEnt = new Node(new PriorityItem<T>(item, priority));
            newEnt.Next = head;
            head = newEnt;

        }

        // removes the highest by either removing the head or by skipping over its link
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

        // checks the status of the head rather than the count
        public bool IsEmpty()
        {
            return head == null;
        }

        // small modification to loop through the linked list rather than an array
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
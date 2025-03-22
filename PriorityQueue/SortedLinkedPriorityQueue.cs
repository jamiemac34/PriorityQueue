using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public SortedLinkedPriorityQueue(int size)
        {
            head = null;
        }

        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return head.Entry.Item;
        }

        public void Add(T item, int priority)
        {
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




        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            head = head.Next;

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
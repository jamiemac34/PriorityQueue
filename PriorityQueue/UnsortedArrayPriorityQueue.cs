using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{

    public class UnsortedArrayPriorityQueue<T> : PriorityQueue<T>
    {
        private readonly PriorityItem<T>[] storage;
        private readonly int capacity;
        private int count;

        public UnsortedArrayPriorityQueue(int size)
        {
            storage = new PriorityItem<T>[size];
            capacity = size;
            count = -1;
        }

        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return storage[0].Item;
        }

        public void Add(T item, int priority)
        {
            count++;
            if (count >= capacity)
            {
                count--;
                throw new QueueOverflowException();
            }

            storage[count] = new PriorityItem<T>(item, priority);
        }

        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            if (count - 1 != -1)
            {
                storage[getHighestPriortiy()] = storage[count - 1];
            }
            
            count--;
        }

        public bool IsEmpty()
        {
            return count < 0;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            string result = "[";
            for (int i = 0; i <= count; i++)
            {
                if (i > 0)
                {
                    result += ", ";
                }
                result += storage[i];
            }
            result += "]";
            return result;
        }

        //function to find the highest priority by looping through the array
        private int getHighestPriortiy()
        {
               int index = 0;

            for (int i = 0; i < count; i++)
            {
                if (storage[i].Priority > storage[index].Priority)
                {
                    index = i;
                }

            }

            return index;
        }
    }
}
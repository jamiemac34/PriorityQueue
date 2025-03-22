using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PriorityQueue
{

    public class HeapPriorityQueue<T> : PriorityQueue<T>
    {
        private readonly List<PriorityItem<T>> storage;

        public HeapPriorityQueue(int size)
        {
            storage = new List<PriorityItem<T>>(size);
        }

        public void Add(T item, int priority)
        {
            storage.Add(new PriorityItem<T>(item, priority));
            int index = storage.Count - 1;

            while (index > 0) 
            { 
                int parent = (index - 1) / 2;
                if (storage[index].Priority <= storage[parent].Priority)
                {
                    break;
                }
                Swap(index, parent);
                index = parent;
            }
        }

        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return storage[0].Item;
        }

        public bool IsEmpty()
        {
            return storage.Count() == 0;
        }

        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            storage[0] = storage[storage.Count - 1];
            storage.RemoveAt(storage.Count - 1);

            int index = 0;
            int priorIndex = storage.Count - 1;
            while (true)
            {
                int lc = 2 * index + 1;
                int rc = 2 * index + 2;
                int largest = index;

                if (lc <= priorIndex && storage[lc].Priority > storage[largest].Priority)
                {
                    largest = lc;
                }
                if (rc <= priorIndex && storage[rc].Priority > storage[largest].Priority)
                {
                    largest = rc;
                }
                if (largest == index)
                {
                    break;
                }
                Swap(index, largest);
                index = largest;
            }
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            return "[" + String.Join(", ", storage) + "]";
        }

        private void Swap(int i, int j)
        {
            var temp = storage[i];
            storage[i] = storage[j];
            storage[j] = temp;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

// code references from geeksforgeeks
// https://www.geeksforgeeks.org/priority-queue-using-binary-heap/

namespace PriorityQueue
{

    public class HeapPriorityQueue<T> : PriorityQueue<T>
    {
        private readonly List<PriorityItem<T>> storage;
        private readonly int capacity;

        public HeapPriorityQueue(int size)
        {
            storage = new List<PriorityItem<T>>(size);
            capacity = size;
        }

        public void Add(T item, int priority)
        {
            if (storage.Count == capacity)
            {
                throw new QueueOverflowException();
            }

            storage.Add(new PriorityItem<T>(item, priority));
            int index = storage.Count - 1;

            // ensuring the highest priority element is at top of the heap
            while (index > 0) 
            { 
                // getting the parent index of the current entry
                int parent = (index - 1) / 2;
                // when the destination for the current priority has been found through it's priority matching or being less than the parent's, break
                if (storage[index].Priority <= storage[parent].Priority)
                {
                    break;
                }
                // then swap
                Swap(index, parent);
                //reorientate the tree back to the parent, to continue the loop until all are sorted
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

            // move the last to root, then remove the original last
            storage[0] = storage[storage.Count - 1];
            storage.RemoveAt(storage.Count - 1);

            int index = 0;
            int priorIndex = storage.Count - 1;
            while (true)
            {

                // find the left & right child of the index
                int lc = 2 * index + 1;
                int rc = 2 * index + 2;
                int largest = index;

                // when the left child exists and has a higher priority, set it as the largest
                if (lc <= priorIndex && storage[lc].Priority > storage[largest].Priority)
                {
                    largest = lc;
                }
                // likewise with the right child
                if (rc <= priorIndex && storage[rc].Priority > storage[largest].Priority)
                {
                    largest = rc;
                }
                // when the current is greater or equal than both children, break 
                if (largest == index)
                {
                    break;
                }
                // swap the current to the largest
                Swap(index, largest);
                // reorientate to the largest's position
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

        // function to swap the order of two entries in the heap, used for reordering after adding or removing
        private void Swap(int i, int j)
        {
            var temp = storage[i];
            storage[i] = storage[j];
            storage[j] = temp;
        }
    }
}


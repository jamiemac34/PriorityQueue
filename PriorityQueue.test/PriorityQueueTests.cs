using System;
using NUnit.Framework;
using PriorityQueue;

namespace PriorityQueue.test
{
    [TestFixture]
    public class PriorityQueueTests
    {
        [SetUp]
        public void Setup()
        {
            heapQueue = new HeapPriorityQueue<Person>(8);
            sortedArrayQueue = new SortedArrayPriorityQueue<Person>(8);
            sortedLinkedQueue = new SortedLinkedPriorityQueue<Person>(8);
            unsortedArrayQueue = new UnsortedArrayPriorityQueue<Person>(8);
            unsortedLinkedQueue = new UnsortedLinkedPriorityQueue<Person>(8);
        }

        private HeapPriorityQueue<Person> heapQueue;
        private SortedArrayPriorityQueue<Person> sortedArrayQueue;
        private SortedLinkedPriorityQueue<Person> sortedLinkedQueue;
        private UnsortedArrayPriorityQueue<Person> unsortedArrayQueue;
        private UnsortedLinkedPriorityQueue<Person> unsortedLinkedQueue;

        [Test]
        public void TestAdd_ExceedingCapacity_ShouldThrowQueueOverflowException()
        {
            // filling queues
            heapQueue.Add(new Person("entry 0"), 0);
            heapQueue.Add(new Person("entry 1"), 1);
            heapQueue.Add(new Person("entry 2"), 2);
            heapQueue.Add(new Person("entry 3"), 3);
            heapQueue.Add(new Person("entry 4"), 4);
            heapQueue.Add(new Person("entry 5"), 5);
            heapQueue.Add(new Person("entry 6"), 6);
            heapQueue.Add(new Person("entry 7"), 7);

            sortedArrayQueue.Add(new Person("entry 0"), 0);
            sortedArrayQueue.Add(new Person("entry 1"), 1);
            sortedArrayQueue.Add(new Person("entry 2"), 2);
            sortedArrayQueue.Add(new Person("entry 3"), 3);
            sortedArrayQueue.Add(new Person("entry 4"), 4);
            sortedArrayQueue.Add(new Person("entry 5"), 5);
            sortedArrayQueue.Add(new Person("entry 6"), 6);
            sortedArrayQueue.Add(new Person("entry 7"), 7);

            sortedLinkedQueue.Add(new Person("entry 0"), 0);
            sortedLinkedQueue.Add(new Person("entry 1"), 1);
            sortedLinkedQueue.Add(new Person("entry 2"), 2);
            sortedLinkedQueue.Add(new Person("entry 3"), 3);
            sortedLinkedQueue.Add(new Person("entry 4"), 4);
            sortedLinkedQueue.Add(new Person("entry 5"), 5);
            sortedLinkedQueue.Add(new Person("entry 6"), 6);
            sortedLinkedQueue.Add(new Person("entry 7"), 7);

            unsortedArrayQueue.Add(new Person("entry 0"), 0);
            unsortedArrayQueue.Add(new Person("entry 1"), 1);
            unsortedArrayQueue.Add(new Person("entry 2"), 2);
            unsortedArrayQueue.Add(new Person("entry 3"), 3);
            unsortedArrayQueue.Add(new Person("entry 4"), 4);
            unsortedArrayQueue.Add(new Person("entry 5"), 5);
            unsortedArrayQueue.Add(new Person("entry 6"), 6);
            unsortedArrayQueue.Add(new Person("entry 7"), 7);

            unsortedLinkedQueue.Add(new Person("entry 0"), 0);
            unsortedLinkedQueue.Add(new Person("entry 1"), 1);
            unsortedLinkedQueue.Add(new Person("entry 2"), 2);
            unsortedLinkedQueue.Add(new Person("entry 3"), 3);
            unsortedLinkedQueue.Add(new Person("entry 4"), 4);
            unsortedLinkedQueue.Add(new Person("entry 5"), 5);
            unsortedLinkedQueue.Add(new Person("entry 6"), 6);
            unsortedLinkedQueue.Add(new Person("entry 7"), 7);


            // testing exception once max capacity is reached
            Assert.Throws<QueueOverflowException>(() =>
                heapQueue.Add(new Person("entry 8"), 8)
            );

            Assert.Throws<QueueOverflowException>(() =>
                sortedArrayQueue.Add(new Person("entry 8"), 8)
            );

            Assert.Throws<QueueOverflowException>(() =>
                sortedLinkedQueue.Add(new Person("entry 8"), 8)
            );

            Assert.Throws<QueueOverflowException>(() =>
                unsortedArrayQueue.Add(new Person("entry 8"), 8)
            );

            Assert.Throws<QueueOverflowException>(() =>
                unsortedLinkedQueue.Add(new Person("entry 8"), 8)
            );
        }
    }
}

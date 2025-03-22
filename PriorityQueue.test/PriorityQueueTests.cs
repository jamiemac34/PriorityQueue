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

        // tests the overflow exception, succesfully executing this also confirms the add function works
        [Test]
        public void TestOverflow()
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

        // tests the underflow exception, succesfully executing this also confirms the remove function works
        [Test]
        public void TestUnderflow()
        {
            Assert.Throws<QueueUnderflowException>(() =>
                heapQueue.Remove()
            );

            Assert.Throws<QueueUnderflowException>(() =>
                sortedArrayQueue.Remove()
            );

            Assert.Throws<QueueUnderflowException>(() =>
                sortedLinkedQueue.Remove()
            );

            Assert.Throws<QueueUnderflowException>(() =>
                unsortedArrayQueue.Remove()
            );

            Assert.Throws<QueueUnderflowException>(() =>
                unsortedLinkedQueue.Remove()
            );
        }

        // tests if each implementation properly handles the priorities
        [Test]
        public void TestCorrectPriority()
        {
            // Filling queues
            heapQueue.Add(new Person("entry 1"), 1);
            heapQueue.Add(new Person("entry 2"), 2);
            heapQueue.Add(new Person("entry 0"), 0);

            sortedArrayQueue.Add(new Person("entry 1"), 1);
            sortedArrayQueue.Add(new Person("entry 2"), 2);
            sortedArrayQueue.Add(new Person("entry 0"), 0);

            sortedLinkedQueue.Add(new Person("entry 1"), 1);
            sortedLinkedQueue.Add(new Person("entry 2"), 2);
            sortedLinkedQueue.Add(new Person("entry 0"), 0);

            unsortedArrayQueue.Add(new Person("entry 1"), 1);
            unsortedArrayQueue.Add(new Person("entry 2"), 2);
            unsortedArrayQueue.Add(new Person("entry 0"), 0);

            unsortedLinkedQueue.Add(new Person("entry 1"), 1);
            unsortedLinkedQueue.Add(new Person("entry 2"), 2);
            unsortedLinkedQueue.Add(new Person("entry 0"), 0);

            // Testing correct priority on insert
            Assert.That(heapQueue.Head().ToString(), Is.EqualTo("entry 2"));
            Assert.That(sortedArrayQueue.Head().ToString(), Is.EqualTo("entry 2"));
            Assert.That(sortedLinkedQueue.Head().ToString(), Is.EqualTo("entry 2"));
            Assert.That(unsortedArrayQueue.Head().ToString(), Is.EqualTo("entry 2"));
            Assert.That(unsortedLinkedQueue.Head().ToString(), Is.EqualTo("entry 2"));

            // Testing after remove
            heapQueue.Remove();
            sortedArrayQueue.Remove();
            sortedLinkedQueue.Remove();
            unsortedArrayQueue.Remove();
            unsortedLinkedQueue.Remove();

            Assert.That(heapQueue.Head().ToString(), Is.EqualTo("entry 1"));
            Assert.That(sortedArrayQueue.Head().ToString(), Is.EqualTo("entry 1"));
            Assert.That(sortedLinkedQueue.Head().ToString(), Is.EqualTo("entry 1"));
            Assert.That(unsortedArrayQueue.Head().ToString(), Is.EqualTo("entry 1"));
            Assert.That(unsortedLinkedQueue.Head().ToString(), Is.EqualTo("entry 1"));
        }

        // tests the isEmpty function on each implementation
        [Test]
        public void TestIsEmpty()
        {
            // test while they should be empty
            Assert.That(heapQueue.IsEmpty(), Is.EqualTo(true));
            Assert.That(sortedArrayQueue.IsEmpty(), Is.EqualTo(true));
            Assert.That(sortedLinkedQueue.IsEmpty(), Is.EqualTo(true));
            Assert.That(unsortedArrayQueue.IsEmpty(), Is.EqualTo(true));
            Assert.That(unsortedLinkedQueue.IsEmpty(), Is.EqualTo(true));

            // adding then testing when should be empty
            heapQueue.Add(new Person("entry 1"), 1);
            sortedArrayQueue.Add(new Person("entry 1"), 1);
            sortedLinkedQueue.Add(new Person("entry 1"), 1);
            unsortedArrayQueue.Add(new Person("entry 1"), 1);
            unsortedLinkedQueue.Add(new Person("entry 1"), 1);

            Assert.That(heapQueue.IsEmpty(), Is.EqualTo(false));
            Assert.That(sortedArrayQueue.IsEmpty(), Is.EqualTo(false));
            Assert.That(sortedLinkedQueue.IsEmpty(), Is.EqualTo(false));
            Assert.That(unsortedArrayQueue.IsEmpty(), Is.EqualTo(false));
            Assert.That(unsortedLinkedQueue.IsEmpty(), Is.EqualTo(false));

        }

    }
}

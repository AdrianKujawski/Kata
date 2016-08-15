using System;

namespace TypyOgolne
{
    class Program
    {
        static void Main(string[] args)
        {
			Queue<int> queue = new Queue<int>();
			Random radnom = new Random();

	        for (int i = 0; i <= 16; i++)
	        {
		        queue.Enqueue(radnom.Next(20));
	        }

			for (int i = 0; i <= 16; i++)
			{
				Console.Out.WriteLine(queue.Dequeue());
			}
		}
    }

    class Queue <T>
    {
        private const int Defaultqueuesize = 100;
        private readonly T[] _data;
        private int _head = 0, tail = 0;
        private int _numElements = 0;

        public Queue()
        {
            _data = new T[Defaultqueuesize];
        }

        public Queue(int size)
        {
            if (size > 0)
            {
                _data = new T[size];
            }
            else
            {
                throw new ArgumentOutOfRangeException("size", "Must be greater than zero");
            }
        }

        public void Enqueue(T item)
        {
            if (_numElements == _data.Length)
            {
                throw new Exception("Queue full");
            }

            _data[_head] = item;
            _head++;
            _head %= _data.Length;
            _numElements++;
        }

        public T Dequeue()
        {
            if (_numElements == 0)
            {
                throw new Exception("Queue empty");
            }

            T queueItem = _data[tail];
            tail++;
            tail %= _data.Length;
            _numElements--;
            return queueItem;
        }
    }
}

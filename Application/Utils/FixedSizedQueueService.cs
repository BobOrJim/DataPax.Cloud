using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public class FixedSizedQueue<T>
    {
        public readonly ConcurrentQueue<T> Queue = new ConcurrentQueue<T>(); //Thread safe FIFO :)
        public int Size { get; private set; }
        public FixedSizedQueue(int size)
        {
            Size = size;
        }
        public void Push(T obj)
        {
            Queue.Enqueue(obj);
            while (Queue.Count > Size)
            {
                T ObjectToThrowAway;
                Queue.TryDequeue(out ObjectToThrowAway);
                Debug.WriteLine($"In FixedSizedQueue, ett objekt faller ur då kön är full");
            }
        }
    }
}





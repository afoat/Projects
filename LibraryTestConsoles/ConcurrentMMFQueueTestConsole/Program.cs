namespace ConcurrentMMFQueueTestConsole
{
    using Foat.Collections.Generic.MMF;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int itemCapacity = 100000000;
            int itemCacheCapacity = 1000000;

            int updateFrequency = 1000000;

            using (ConcurrentMMFQueue queue = new ConcurrentMMFQueue("queue", sizeof(int), itemCapacity, itemCacheCapacity))
            {
                queue.TryEnqueue(BitConverter.GetBytes(1));
                Console.WriteLine("Queued 1");
                queue.TryEnqueue(BitConverter.GetBytes(2));
                Console.WriteLine("Queued 2");
                queue.TryEnqueue(BitConverter.GetBytes(3));
                Console.WriteLine("Queued 3");
                queue.TryEnqueue(BitConverter.GetBytes(4));
                Console.WriteLine("Queued 4");
                queue.TryEnqueue(BitConverter.GetBytes(5));
                Console.WriteLine("Queued 5");
                queue.TryEnqueue(BitConverter.GetBytes(6));
                Console.WriteLine("Queued 6");
                queue.TryEnqueue(BitConverter.GetBytes(7));
                Console.WriteLine("Queued 7");
                queue.TryEnqueue(BitConverter.GetBytes(8));
                Console.WriteLine("Queued 8");
                queue.TryEnqueue(BitConverter.GetBytes(9));
                Console.WriteLine("Queued 9");
                queue.TryEnqueue(BitConverter.GetBytes(10));
                Console.WriteLine("Queued 10");

                byte[] bytes;
                queue.TryDequeue(out bytes);
                Console.WriteLine("Deuqued {0:N0}", BitConverter.ToInt32(bytes, 0));
                queue.TryDequeue(out bytes);
                Console.WriteLine("Deuqued {0:N0}", BitConverter.ToInt32(bytes, 0));
                queue.TryDequeue(out bytes);
                Console.WriteLine("Deuqued {0:N0}", BitConverter.ToInt32(bytes, 0));
                queue.TryDequeue(out bytes);
                Console.WriteLine("Deuqued {0:N0}", BitConverter.ToInt32(bytes, 0));
                queue.TryDequeue(out bytes);
                Console.WriteLine("Deuqued {0:N0}", BitConverter.ToInt32(bytes, 0));
                queue.TryDequeue(out bytes);
                Console.WriteLine("Deuqued {0:N0}", BitConverter.ToInt32(bytes, 0));
                queue.TryDequeue(out bytes);
                Console.WriteLine("Deuqued {0:N0}", BitConverter.ToInt32(bytes, 0));
                queue.TryDequeue(out bytes);
                Console.WriteLine("Deuqued {0:N0}", BitConverter.ToInt32(bytes, 0));
                queue.TryDequeue(out bytes);
                Console.WriteLine("Deuqued {0:N0}", BitConverter.ToInt32(bytes, 0));
                queue.TryDequeue(out bytes);
                Console.WriteLine("Deuqued {0:N0}", BitConverter.ToInt32(bytes, 0));

                for (int i = 0; i < itemCapacity; ++i)
                {
                    if (!queue.TryEnqueue(BitConverter.GetBytes(i)))
                    {
                        throw new InvalidOperationException("Queue full");
                    }

                    if (queue.Count % updateFrequency == 0)
                        Console.WriteLine("Queued {0:N0} Items", queue.Count);
                }

                if (!queue.TryEnqueue(BitConverter.GetBytes(1)))
                {
                    Console.WriteLine("DONT DO THAT NOW");
                }

                for (int i = 0; i < itemCapacity; ++i)
                {
                    byte[] b;
                    if (!queue.TryDequeue(out b))
                    {
                        throw new InvalidOperationException("Queue empty");
                    }

                    if (queue.Count % updateFrequency == 0)
                        Console.WriteLine("Dequeued {0:N0}", BitConverter.ToInt32(b, 0));
                }

                if (!queue.TryDequeue(out bytes))
                {
                    Console.WriteLine("DONT DO THAT NOW");
                }
            }
        }
    }
}

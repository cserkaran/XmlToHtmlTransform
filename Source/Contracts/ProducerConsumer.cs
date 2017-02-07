using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProducerConsumer<T>
    {
        private readonly Queue<T> queue = new Queue<T>();

        private readonly object queueLocker = new object();

        private readonly AutoResetEvent queueWaitHandle = new AutoResetEvent(false);

        private readonly CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        private readonly Action<T> consumerAction;

        private readonly Task _consumerTask;

        public ProducerConsumer(Action<T> consumerAction)
        {
            if (consumerAction == null)
            {
                throw new ArgumentNullException("consumerAction");
            }

            this.consumerAction = consumerAction;
            _consumerTask = 
                Task.Factory.StartNew(ConsumeItems, _cancelTokenSource.Token,
                TaskCreationOptions.LongRunning);

        }

        public void Enqueue(T item)
        {
            lock (this.queueLocker)
            {
                this.queue.Enqueue(item);
                // After enqueuing the item, signal the consumer thread.
                this.queueWaitHandle.Set();
            }
        }

        private void ConsumeItems(object obj)
        {
            while (true)
            {
                T nextItem = default(T);

                // Later on, we'll need to know whether there was an item in the queue.
                bool doesItemExist;

                lock (queueLocker)
                {
                    doesItemExist = queue.Count > 0;
                    if (doesItemExist)
                    {
                        nextItem = queue.Dequeue();
                    }
                }

                if (doesItemExist)
                {
                    // If there was an item in the queue, process it...
                    consumerAction(nextItem);
                }
                else
                {
                    // ...otherwise, wait for the an item to be queued up.
                    queueWaitHandle.WaitOne();
                }
            }
        }
    }
}

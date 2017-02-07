using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// Generic Producer Consumer Class implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ProducerConsumer<T>
    {
        /// <summary>
        /// The queue
        /// </summary>
        private readonly Queue<T> queue = new Queue<T>();

        /// <summary>
        /// The queue locker for synchronization access to the queue.
        /// </summary>
        private readonly object queueLocker = new object();

        /// <summary>
        /// The queue wait handle to wait for the consumer thread for a new message on the queue.
        /// </summary>
        private readonly AutoResetEvent queueWaitHandle = new AutoResetEvent(false);

        /// <summary>
        /// The cancel token source
        /// </summary>
        private readonly CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        /// <summary>
        /// The consumer action
        /// </summary>
        private readonly Action<T> consumerAction;

        /// <summary>
        /// The consumer task
        /// </summary>
        private readonly Task _consumerTask;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProducerConsumer{T}"/> class.
        /// </summary>
        /// <param name="consumerAction">The consumer action.</param>
        /// <exception cref="System.ArgumentNullException">consumerAction</exception>
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

        /// <summary>
        /// Enqueues the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Enqueue(T item)
        {
            lock (this.queueLocker)
            {
                this.queue.Enqueue(item);
                // After enqueuing the item, signal the consumer thread.
                this.queueWaitHandle.Set();
            }
        }

        /// <summary>
        /// Consumes the items.
        /// </summary>
        /// <param name="obj">The object.</param>
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

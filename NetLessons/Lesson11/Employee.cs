using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lesson11
{
    

    public class Employee
    {
        private static object Marker = new object();

        private Semaphore _semaphore;
        private readonly Mutex _mutex;

        public string Name { get; set; }

        public Employee()
        {

        }

        public Employee(Semaphore semaphore)
        {
            _semaphore = semaphore;
        }

        public Employee(Mutex mutex)
        {
            _mutex = mutex;
        }

        public void Work(object obj)
        {
            
            Console.WriteLine($"Employee {Name} started working! Thread Id - {Thread.CurrentThread.ManagedThreadId}");
            lock (Marker)
            {
                if (obj is WorkingParam param)
                {
                    for (int i = 0; i < param.Count; i++)
                    {
                        Console.WriteLine($"Employee {Name} working...");
                        Thread.Sleep(param.SleepMil);
                    }
                }

                Console.WriteLine($"Employee {Name} finished working!");
            }
        }

        public void Work2(object obj)
        {
            _semaphore?.WaitOne();
            Console.WriteLine($"Employee {Name} started working! Thread Id - {Thread.CurrentThread.ManagedThreadId}");

            if (obj is WorkingParam param)
            {
                for (int i = 0; i < param.Count; i++)
                {
                    Console.WriteLine($"Employee {Name} working... Thread Id - {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(param.SleepMil);
                }
            }

            Console.WriteLine($"Employee {Name} finished working!");
            _semaphore?.Release();
        }

        public void Work3(object obj)
        {
            _mutex.WaitOne();
            Console.WriteLine($"Employee {Name} started working! Thread Id - {Thread.CurrentThread.ManagedThreadId}");

            if (obj is WorkingParam param)
            {
                for (int i = 0; i < param.Count; i++)
                {
                    Console.WriteLine($"Employee {Name} working... Thread Id - {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(param.SleepMil);
                }
            }

            Console.WriteLine($"Employee {Name} finished working!");
            _mutex.ReleaseMutex();
        }
    }
}

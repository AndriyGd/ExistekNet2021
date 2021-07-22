using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lesson11
{
    class Program
    {
        private static int n = 25;
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread Id - {Thread.CurrentThread.ManagedThreadId}");
            var m = new Mutex();

            var e = new Employee(m) { Name = "John" };

            var rn = new Random();
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(e.Work3, new WorkingParam { Count = rn.Next(20), SleepMil = rn.Next(700, 1000) });
                Thread.Sleep(200);
            }

            ThreadPool.QueueUserWorkItem(obj =>
            {
                m.WaitOne();
                Console.WriteLine($"L Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                if (obj is WorkingParam param)
                {
                    for (int i = 0; i < param.Count; i++)
                    {
                        Console.WriteLine($"Lm. i = {i}");
                        Thread.Sleep(param.SleepMil);
                    }
                }

                m.ReleaseMutex();
            }, new WorkingParam { Count = 10, SleepMil = 1350 });

            Console.ReadKey();
        }

        private static void Run1()
        {
            Console.WriteLine($"Main Thread Id - {Thread.CurrentThread.ManagedThreadId}");
            Thread th = new Thread(Loading);
            //th.IsBackground = true;
            th.Start();

            var thParam = new Thread(Increment);
            thParam.Start(23);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main Method Loading");
                Thread.Sleep(1800);
            }
        }

        private static void Run2()
        {
            var e1 = new Employee { Name = "Viktor" };
            var e2 = new Employee { Name = "Ira" };

            var thParam = new Thread(Increment);
            var te1 = new Thread(e1.Work) { IsBackground = true };
            var te2 = new Thread(e2.Work);

            //thParam.Start(23);
            te1.Start(new WorkingParam { Count = 15, SleepMil = 350 });
            //te1.Join();    

            te2.Start(new WorkingParam { Count = 18, SleepMil = 750 });

            Console.WriteLine("After Join");
        }

        private static void Run3()
        {
            var e1 = new Employee { Name = "Viktor" };
            var e2 = new Employee { Name = "Ira" };

            ThreadPool.QueueUserWorkItem(e1.Work, new WorkingParam { Count = 15, SleepMil = 1350 });
            ThreadPool.QueueUserWorkItem(e2.Work, new WorkingParam { Count = 18, SleepMil = 750 });
        }

        private static void Run4()
        {
            var e2 = new Employee { Name = "Ira" };
            var te2 = new Thread(e2.Work);
            te2.Start(new WorkingParam { Count = 18, SleepMil = 1750 });

            Console.WriteLine("Press 'S' to stop thred. \n");
            if (Console.ReadLine() == "S")
            {
                te2.Abort();
            }
        }

        private static void Run5()
        {
            var s = new Semaphore(4, 4);
            var e = new Employee(s) { Name = "John" };

            var rn = new Random();
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(e.Work2, new WorkingParam { Count = rn.Next(20), SleepMil = rn.Next(1200, 2000) });
                Thread.Sleep(200);
            }

            ThreadPool.QueueUserWorkItem(obj =>
            {
                s.WaitOne();
                Console.WriteLine($"L Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                if (obj is WorkingParam param)
                {
                    for (int i = 0; i < param.Count; i++)
                    {
                        Console.WriteLine($"L. i = {i}");
                        Thread.Sleep(param.SleepMil);
                    }
                }

                s.Release();
            }, new WorkingParam { Count = 17, SleepMil = 1350 });
        }

        private static void Run6()
        {
            var m = new Mutex(false, "Test M");
            m.SetAccessControl(new System.Security.AccessControl.MutexSecurity());
            try
            {
                m.WaitOne();
                Console.WriteLine("Hello");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadKey();

            m.Dispose();
        }

        private static void Loading()
        {
            Console.WriteLine($"Loading Thread Id - {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Loading...");
                Thread.Sleep(1500);
            }
        }

        private static void Increment(object init)
        {
            if(init is int start)
            {
                for (int i = 0; i < start; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1250);
                }
            }
        }
    }
}

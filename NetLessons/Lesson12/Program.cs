using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Lesson12
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.ReadKey();
        }

        private static void Run3()
        {
            var em = new Employee { Name = "HELLO", Age = 34 };
            var room = new Room { Employee = em };
            var teem = new Teem { Employee = room.Employee };

            Console.WriteLine($"Generation: {GC.GetGeneration(em)}");
            room = null;
            Console.WriteLine($"Generation: {GC.GetGeneration(em)}");
            GC.Collect();
            Console.WriteLine($"Generation: {GC.GetGeneration(em)}");

            teem = null;
            GC.Collect();
            Console.WriteLine($"Generation: {GC.GetGeneration(em)}");
            em = null;
            //Console.WriteLine($"TotalMemory: {GC.GetTotalMemory(true)}");

            Thread.Sleep(5000);
            GC.Collect();
            //Console.WriteLine($"TotalMemory after: {GC.GetTotalMemory(true)}");
            Console.WriteLine("Time");
        }

        private static void Run2()
        {
            //Console.WriteLine($"TotalMemory: {GC.GetTotalMemory(true)}");

            var e = new Employee { Name = "", Age = 34 };
            //Console.WriteLine($"TotalMemory: {GC.GetTotalMemory(true)}");
            Console.WriteLine($"Generation: {GC.GetGeneration(e)}");
            //GC.Collect(2);
            Console.WriteLine($"Generation: {GC.GetGeneration(e)}");
            GC.SuppressFinalize(e);
            e = null;

            var m = new Manager();
            m.Make(100000);

            //Console.WriteLine($"TotalMemory: {GC.GetTotalMemory(true)}");
            Console.WriteLine($"Generation: {GC.GetGeneration(m)}");
            GC.Collect();
            //Console.WriteLine($"TotalMemory: {GC.GetTotalMemory(true)}");
            //GC.SuppressFinalize(m);
            m.Employees = null;
            //Console.WriteLine($"TotalMemory after Clear: {GC.GetTotalMemory(true)}");
            GC.Collect();
            //Console.WriteLine($"TotalMemory: {GC.GetTotalMemory(true)}");
            m = null;

            GC.Collect();
            //Console.WriteLine($"TotalMemory after null: {GC.GetTotalMemory(true)}");
        }

        private static void Run()
        {
            Load5();

            Console.WriteLine("Main");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1800);
            }

            //var sw = new StreamWriter(new FileStream("", FileMode.Create, FileAccess.Write));
            //sw.WriteAsync("");
        }

        private static async void Load()
        {
            var loadTask = LoadDataAsync(10);
            await loadTask;
            /*
             * 
             * 
             * 
             * 
             * 
             */



            Console.WriteLine("Loaded");
        }

        private static async void Load2()
        {
            await LoadDataAsync(16);

            Console.WriteLine("Load2");
        }

        private static async void Load3()
        {
            await LoadDataAndParseAsync(17);

            Console.WriteLine("Load3");
        }

        private static async void Load4()
        {
            var lst = new List<int> { 45, 56, 12, 56, 78, 78, 54, 23, 434, 3 };

            var sum = await CalcAsync(lst);
            Console.WriteLine($"Sum: {sum}");
        }

        private static async void Load5()
        {
            var lst = new List<int> { 45, 56, 12, 56, 78, 78, 54, 23, 434, 3 };
            var sum = await CalcAsync(lst);
            Console.WriteLine($"Sum: {sum}");

            var mul = await Calc2Async(lst);
            Console.WriteLine($"Mul: {mul}");

            await Task.Run(() => 
            {
                Thread.Sleep(3000);
                Console.WriteLine("Async");
            });
        }

        private static Task LoadDataAsync(int n) //Task = void
        {
            return Task.Run(() => 
            {
                Console.WriteLine($"IsBackground: {Thread.CurrentThread.IsBackground}. Id: {Thread.CurrentThread.ManagedThreadId}");

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Loading...");
                    Thread.Sleep(1000);
                    //Console.Clear();
                }
            });
        }


        private static async Task LoadDataAndParseAsync(int n) //Task = void
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"IsBackground: {Thread.CurrentThread.IsBackground}. Id: {Thread.CurrentThread.ManagedThreadId}");

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Loading...");
                    Thread.Sleep(1000);
                    //Console.Clear();
                }
            });

            Console.WriteLine($"Id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Parsing after load");
        }

        private static Task<int> CalcAsync(List<int> list)
        {
            return Task.Run(() => 
            {
                var sum = 0;
                foreach (var item in list)
                {
                    sum += item;
                    Thread.Sleep(1000);
                }

                return sum;
            });
        }

        private static Task<long> Calc2Async(List<int> list)
        {
            return Task.Run(() => Calc(list));
        }

        private static long Calc(List<int> list)
        {
            long sum = list[0];
            for(var i = 1; i < list.Count; i++)
            {
                sum *= list[i];
                Thread.Sleep(500);
            }

            return sum;
        }
    }
}

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Lesson10
{
    class Program
    {
        static void Main(string[] args)
        {

            var arr = new List<int> { 56, 34, 67, 25, 7, 77 };
            var res = arr.Where(n => n > 30).ToList();
            res.ForEach(Console.WriteLine);

            Console.WriteLine();

            var app = AppDomain.CurrentDomain;

            var nApp = AppDomain.CreateDomain("Lesson10 Doamin");
            var path = @"D:\projects\net\Existek\ExistekNet2121\NetLessons\Lesson10\bin\Debug\Lesson9.exe";

            var ass = Assembly.LoadFrom(path);
            nApp.Load(ass.FullName);

            

            foreach (var assem in nApp.GetAssemblies())
            {
                Console.WriteLine($"Full Name: {assem.FullName}");
            }

            Console.ReadLine();
        }

        private static void StartProc2(string[] args)
        {
            //var path = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            //var url = "https://docs.telerik.com/devtools/wpf/controls/radgridview/columns/columntypes/checkbox-column";

            //var mozilla = Process.Start(path, url);

            Console.ReadLine();

            if (args.Length > 0)
            {
                foreach (var path in args)
                {
                    ReadText(path);
                }
            }
        }

        private static void ReadText(string path)
        {
            Console.WriteLine(File.ReadAllText(path));
        }

        private static void StartProc1()
        {
            var path = @"D:\projects\net\Existek\ExistekNet2121\NetLessons\Lesson9\bin\Debug\Lesson9.exe";
            var lesson9 = Process.Start(path);
            var name = lesson9.ProcessName;

            PrintProcesInfo(lesson9);

            lesson9.WaitForExit();

            Console.WriteLine($"Process '{name}' closed");
        }

        private static void KillProc()
        {
            Console.Write("Process PID: ");
            if (int.TryParse(Console.ReadLine(), out var pid))
            {
                var proc = Process.GetProcessById(pid);
                PrintProcesInfo(proc);
                Console.Write("Press 'K' to Kill the Process: ");
                if (Console.ReadLine() == "K")
                {
                    proc.Kill();
                    Console.WriteLine($"Process '{proc.ProcessName}' killed!");
                }

            }
        }

        private static void PrintProcesses()
        {
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                PrintProcesInfo(process);
            }

        }

        private static void PrintProcesInfo(Process process)
        {
            try
            {
                Console.WriteLine($"Name: {process.ProcessName}\tPID: {process.Id}\tStart Time: {process.StartTime}\tFolder: {process.StartInfo.WorkingDirectory}");
            }
            catch (Exception)
            {
                //ignore
            }
        }
    }
}

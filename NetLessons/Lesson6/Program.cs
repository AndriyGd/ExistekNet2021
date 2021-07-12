using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Point<int>();

            a.X = 4;
            a.Y = -5;

            var b = new Point<double>(12.5, -39.422);

            Console.WriteLine(a);
            Console.WriteLine("----------");
            Console.WriteLine(b);

            //var p1 = new Point<Employee>(new JuniorEmployee("Tom"), new JuniorEmployee("John"));
            //Console.WriteLine(p1);

            var m = new TopManager<JuniorEmployee>();

            m.Add(new JuniorEmployee("Tom") { Age = 30 });
            m.Add(new JuniorEmployee("Viktor"));

            var exists = m.Find("Tom");
            if(exists != null)
            {
                Console.WriteLine($"Name: {exists.Name}\nAge: {exists.Age}");
            }
            else
            {
                Console.WriteLine("Eployee does not exist!");
            }

            //var m2 = new TopManager<Employee>();

            Console.ReadLine();
        }

        private static void Run2()
        {
            var emp = new Employee { Name = "John" };
            var manager = new Manager(emp);

            emp.WorkStarted += Employee_WorkStarted;
            emp.Work(7);

            Console.WriteLine("-----------");

            var junior = new JuniorEmployee("Aldin");
            junior.WorkStarted += Employee_WorkStarted;

            junior.Work(8);
        }

        private static void Run1()
        {
            var emp = new Employee { Name = "Tom" };
            var manager = new Manager(emp);

            //emp.WorkFinished += new EventHandler(Employee_WorkFinished);
            emp.WorkFinished += Employee_WorkFinished;
            emp.WorkFinished += delegate (object sender, EventArgs args1)
            {
                Console.WriteLine("Anon Method. Employee finished working");
            };
            emp.WorkFinished += (sender, args1) =>
            {
                Console.WriteLine("Lambda Method. Employee finished working");
            };

            emp.Work(5);

            Console.WriteLine("------------------");
            emp.WorkFinished -= Employee_WorkFinished;
            emp.Work(6);

            var emp2 = new Employee();

            Console.WriteLine("===================");
            //manager.UnsubscribeWorkFinished(emp2);
            manager.UnsubscribeWorkFinished(emp);
            emp.Work(4);
        }

        public static void Employee_WorkFinished(object sender, EventArgs args)
        {
            if(sender is Employee employee)
            {
                Console.WriteLine($"Class Program. Employee '{employee.Name}' finished working");
            }
            else
            {
                Console.WriteLine("Class Program. Employee finished working");
            }  
        }

        public static void Employee_WorkStarted(object sender, EmployeeEventArgs args)
        {
            Console.WriteLine($"Class Program. Employee '{args.EmployeeName}' started working");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.Name = "Tom";
            employee.LastName = "Fort";
            employee.CardId = 5666;
            employee.Birthday = new DateTime(1990, 5, 20);
            //Console.WriteLine(employee);

            //Console.WriteLine(employee.Name);
            //Console.WriteLine(employee.GetAge());

            Employee employee1 = new Employee
            {
                Name = "John",
                LastName = "Nort",
                Birthday = new DateTime(1992, 10, 24),
                CardId = 8934
            };

            //Console.WriteLine(employee1);

            Manager m = new Manager("Mmfg", "Golt", new DateTime(1990, 4, 26), 10456);

            Console.WriteLine(m.Salary);

            var top = new TopManager();
            Console.WriteLine(top.Employees.Count);


            var lst = new List<Employee> { employee };
            lst.Add(employee1);

            Console.WriteLine();
            var top2 = new TopManager("John", "Gold", new DateTime(), 25678, lst);
            top2.PrintInfo();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Human h = new Employee
            {
                Name = "Ihor",
                LastName = "Lomn",
                Birthday = new DateTime(1993, 5, 21),
                Sound = "Lenguage",
                CardId = 5555
            };

            Console.WriteLine(h.Name);

            Employee ihor = (Employee)h;
            Console.WriteLine(ihor.CardId);

            Console.WriteLine();

            var ihor2 = h as Employee;
            ihor2.CardId = 7777;
            h.Name = "Petro";
            Console.WriteLine(ihor2.CardId);
            Console.WriteLine(ihor.CardId);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(h.Name);
            Console.WriteLine(ihor2.Name);
            Console.WriteLine(ihor.Name);

            Print(h);
            Print(ihor2);
            Print(m);

            Human hm = m;

            Console.WriteLine(hm.Name);

            Console.ReadKey();
        }

        public static void Print(Human human)
        {
            Console.WriteLine(human.Name);
            Console.WriteLine(human.LastName);
            Console.WriteLine(human.Birthday);

            if(human is Employee employee)
            {
                Console.WriteLine($"CardId: {employee.CardId}");
            }

            if(human is Manager manager)
            {
                Console.WriteLine($"Salary: {manager.Salary}");
            }
        }
    }
}

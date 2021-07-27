using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst = new List<Employee> 
            {
                new Employee("John", 27, 9500.56),
                new Employee("Anna", 25, 19500.56),
                new Employee("Viktor", 29, 7500.56),
                new Employee("Oleg", 31, 12500.66),
                new Employee("Tom", 46, 11500),
                new Employee("Andrew", 20, 14500.26),
                new Employee("Alex", 19, 11500.16),
                new Employee("Inna", 27, 7500.56),
                new Employee("Vika", 25, 20700.00),
                new Employee("Saravana", 27, 10300.46),
            };

            var res = lst.All(em => em.Salary > 10000);
            Console.WriteLine(res);

            //var f1 = lst.First(emp => emp.Age == 18);
            var f1 = lst.FirstOrDefault(emp => emp.Age == 18);
            if(f1 != null)
            {
                Console.WriteLine(f1.Name);
            }

            var f2 = lst.FirstOrDefault(emp => emp.Age == 25);
            if (f2 != null)
            {
                Console.WriteLine(f2.Name);
            }
            
            Console.WriteLine("===============");
            var res2 = lst.Where(e => e.Salary >= 14000).OrderBy(e => e.Age).ToList();
            foreach (var item in res2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-=-=-=--=-=-");
            var names = lst.Where(e => e.Age > 25).Select(e => e.Name).OrderBy(e => e);
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----Short-----");
            var shortLst = lst.Where(e => e.Salary > 17000).Select(e => new ShortEmployee { Name = e.Name, Salary = e.Salary }).ToList();
            shortLst.ForEach(Console.WriteLine);

            Console.WriteLine("=====TAKE=====");
            var take = lst.TakeWhile(e => e.Salary != 11500).ToList();
            take.ForEach(Console.WriteLine);

            Console.ReadKey();
        }

        private static void Run1()
        {
            var lst = new List<int> { 45, -5, 41, 56, 20, 18, 18, 35, -12 };

            var resLst = from item in lst where item >= 20 select item;
            var resLstOrdered = from item in lst where item >= 20 orderby item select item;
            var resList = (from item in lst where item >= 20 orderby item descending select item).ToList();
            var list = from item in lst
                       where item >= 20 && item % 2 == 0
                       select item;

            foreach (var item in resLst)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Ordered");
            foreach (var item in resLstOrdered)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("List");
            for (int i = 0; i < resList.Count; i++)
            {
                Console.WriteLine(resList[i]);
            }

            Console.WriteLine("------");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static void Run2()
        {
            var lst = new List<Employee>
            {
                new Employee("John", 27, 9500.56),
                new Employee("Anna", 25, 19500.56),
                new Employee("Viktor", 29, 7500.56),
                new Employee("Oleg", 31, 12500.66),
                new Employee("Tom", 46, 11500.56),
                new Employee("Andrew", 20, 14500.26),
                new Employee("Alex", 19, 11500.16),
                new Employee("Inna", 27, 7500.56),
                new Employee("Vika", 25, 20700.00),
                new Employee("Saravana", 27, 10300.46),
            };

            var res = (from emp in lst where emp.Salary > 10000.00 select emp).ToList();
            res.ForEach(Console.WriteLine);

            Console.WriteLine("-----Short------");
            var shortRes = from emp in lst select new ShortEmployee { Name = emp.Name, Salary = emp.Salary };
            shortRes.ToList().ForEach(Console.WriteLine);

            Console.WriteLine("-----Only Names-----");
            var onlyNames = from emp in lst where emp.Salary > 15000 select new { Name = emp.Name };
            foreach (var item in onlyNames)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("---- LET ----");
            var useLet = (from emp in lst let p = emp.GetPercent() where p > 30 orderby emp.Salary select emp).ToList();
            useLet.ForEach(Console.WriteLine);
        }
    }
}

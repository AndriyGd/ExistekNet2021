using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lesson12
{
    public class Manager
    {
        public List<Employee> Employees { get; set; }

        public Manager()
        {
            Employees = new List<Employee>();
        }

        public void Make(int n)
        {
            var rn = new Random();
            for (int i = 0; i < n; i++)
            {
                var e = new Employee { Name = $"Emp_{i}", Age = rn.Next(18, 40) };
                GC.SuppressFinalize(e);
                Employees.Add(e);
                //Thread.Sleep(100); 
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class TopManager : Manager
    {
        public List<Employee> Employees { get; private set; }

        public TopManager() : base("Empty", "Empty", DateTime.Now, 0.00)
        {
            Employees = new List<Employee>();
        }

        public TopManager(string name, string lastName, DateTime birthday, double salary, List<Employee> employees) : base(name, lastName, birthday, salary)
        {
            Employees = employees;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}\nLast name: {LastName}\nSalary: {Salary:n}\n\nEmployees:");
            foreach (var employee in Employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}

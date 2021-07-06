using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class Manager : Human
    {
        public double Salary { get; set; }

        public Manager(string name, string lastName, DateTime birthday, double salary)
        {
            Name = name;
            LastName = lastName;
            Birthday = birthday;
            Salary = salary;
        }
    }
}

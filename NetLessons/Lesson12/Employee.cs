using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }


        ~Employee()
        {
            Console.WriteLine("Final");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    public class JuniorEmployee : Employee, IPerson
    {
        public int Age { get; set; }

        public JuniorEmployee()
        {

        }

        public JuniorEmployee(string name)
        {
            Name = name;
        }

        protected override void OnWorkStarted()
        {
            Console.WriteLine("JuniorEmployee.OnWorkStarted");
            base.OnWorkStarted();
        }
    }
}

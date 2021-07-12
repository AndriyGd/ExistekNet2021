using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    public class EmployeeEventArgs : EventArgs
    {
        public string EmployeeName { get; }

        public EmployeeEventArgs(string employeeName)
        {
            EmployeeName = employeeName;
        }
    }
}

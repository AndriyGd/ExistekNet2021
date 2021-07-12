using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    public class Manager
    {
        private List<Employee> _employeis;

        private Employee _empTemp;

        public Manager(Employee emp)
        {
            _employeis = new List<Employee> { emp };
            emp.WorkFinished += Employee_WorkFinishedEventHandler;
        }

        private void Employee_WorkFinishedEventHandler(object sender, EventArgs args)
        {
            Console.WriteLine("Class Manager. Employee finished working");
        }

        public void AddEmployee(Employee employee)
        {
            _employeis.Add(employee);
        }

        public void UnsubscribeWorkFinished(Employee emp)
        {
            _empTemp = emp;
            var exists = _employeis.FirstOrDefault(e => e.Id == emp.Id);
            //var exists = _employeis.FirstOrDefault(Find);

            if(exists != null)
            {
                exists.WorkFinished -= Employee_WorkFinishedEventHandler;
            }
        }

        private bool Find(Employee employee)
        {
            return _empTemp.Id == employee.Id;
        }
    }
}

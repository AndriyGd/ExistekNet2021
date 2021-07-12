using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lesson6
{
    public delegate void WorkStartedEventHandler(object sender, EmployeeEventArgs args);

    public class Employee
    {
        public event EventHandler WorkFinished;
        public event WorkStartedEventHandler WorkStarted;

        public Guid Id { get; }
        public string Name { get; set; }

        public Employee()
        {
            Id = Guid.NewGuid();
        }

        public void Work(int n)
        {

            Console.WriteLine("Start working");

            OnWorkStarted();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Working... {i}");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Fnished working");

            OnWorkFinished();
        }

        protected virtual void OnWorkFinished()
        {
            //if(WorkFinished != null)
            //{
            //    WorkFinished(this, EventArgs.Empty);
            //}

            WorkFinished?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnWorkStarted()
        {
            WorkStarted?.Invoke(this, new EmployeeEventArgs(Name));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class Employee : Human
    {
        public int CardId { get; set; }


        //public override string ToString()
        //{
        //    base.ToString();
        //    return $"Name: {Name}\nLast name: {LastName}\nBirthday: {Birthday}\nAge: {GetAge()}\nCardId: {CardId}\nSound: {Sound}\n";
        //}

        public new int GetAge()
        {
            return (DateTime.Now - Birthday).Days;
        }

        public override void PrintMessage()
        {
            Console.WriteLine($"From Employee: {Name}");
        }

        public void BasePrintMessage()
        {
            base.PrintMessage();
        }

        
    }
}

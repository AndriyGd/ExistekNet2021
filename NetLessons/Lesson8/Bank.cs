using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class Bank
    {
        private static int Id;
        public static double CreditPercent { get; set; }

        private string _state;

        public string Name { get; set; }
        public double Balance { get; set; }
        public double Bonus { get; set; }

        public Phone Phone { get; set; }

        public Bank(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }

        static Bank()
        {
            CreditPercent = 3.75;
            Id = 833238;
            PrintInfo();
        }

        public double GetCredit(double amount)
        {
            Console.WriteLine($"Balance: {Balance}\tCredit percent: {CreditPercent}%\tId: {Id}");
            if(Balance - amount > 0)
            {
                var percent = CreditPercent / 100.0;

                Balance -= amount;
                var credit = amount * percent + amount;
                Bonus += credit;

                Console.WriteLine($"Gives credit {amount} of Bank: {Name}");
                return credit;
            }

            return -1;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nBalance: {Balance}\nPhone: {Phone?.Number}";
        }

        public static void PrintInfo()
        {
            Console.WriteLine($"Credit percent: {CreditPercent}%");
            Console.WriteLine($"Id: {Id}");

            //Console.WriteLine(Balance);
            //var s = GetCredit(555);
        }
    }
}

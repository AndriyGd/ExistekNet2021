using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson8.FileHelper;
using Lesson8.ExtensionLesson8;

namespace Lesson8
{
    class Program
    {
        static void Main(string[] args)
        {
            //var lst = new List<int> { 45, 65, 22, 78, 15, 15, 19, 6 };
            //var res = lst.Where(n => n > 20).ToList();

            //var str = "Lesson8 static classes, methods";
            //var words = str.CountWords();

            //Console.WriteLine($"Words: {words}");

            var phone = new Phone { Name = "Mobile", Number = "524678-99" };
            Console.WriteLine();
            var bank = new Bank("SD", 999999);
            Console.WriteLine();
            Console.WriteLine(bank);
            Console.WriteLine("-----------");

            bank.AddPhone(phone); // = BankHelper.AddPhone(bank, phone)
            Console.WriteLine(bank);

            Console.ReadLine();
        }

        public static void Run3()
        {
            var p = new Phone();
        }

        public static void Run1()
        {
            //Bank.CreditPercent = 3.6;
            //Console.WriteLine(Bank.CreditPercent);
            var bank = new Bank("ATL", 5000);
            var bank2 = new Bank("JP&T", 6500);

            var sumReturn = bank.GetCredit(1000);
            Console.WriteLine($"Sum to return: {sumReturn}");

            Console.WriteLine();
            var sumReturn2 = bank2.GetCredit(1000);
            Console.WriteLine($"Sum to return: {sumReturn2}");


            Console.WriteLine("---------");
            Bank.CreditPercent = 3.23;
            sumReturn = bank.GetCredit(1000);
            Console.WriteLine($"Sum to return: {sumReturn}");

            Console.WriteLine();
            sumReturn2 = bank2.GetCredit(1000);
            Console.WriteLine($"Sum to return: {sumReturn2}");

            Console.WriteLine();
            Bank.PrintInfo();
        }

        public static void Run2()
        {
            var isExists = IsExists(@"c:\txt.1");

            Console.WriteLine(isExists);
            Console.WriteLine($"FG: {Fg}");

            Fg = 1294;
            Console.WriteLine($"FG: {Fg}");
        }
    }
}

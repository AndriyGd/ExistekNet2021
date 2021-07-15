using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    namespace ExtensionLesson8
    {
        public static class StringHelper
        {
            public static int CountWords(this string text)
            {
                var temp = text.Split(' ');
                return temp.Length;
            }
        }

        public static class BankHelper
        {
            public static void AddPhone(this Bank bank, Phone phone)
            {
                bank.Phone = phone;
            }
        }
    }
}

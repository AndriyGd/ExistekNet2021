using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class Human
    {
        private DateTime _birthday;

        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                if (value.Year < 1920) throw new HumanException("Рік народження не може бути менший за 1920 рік!!!!", this);

                _birthday = value;
            }
        }

        public int GetAge()
        {
            return DateTime.Now.Year - Birthday.Year;
        }

        public virtual void PrintMessage()
        {
            Console.WriteLine("From Human");
        }

        public override string ToString()
        {
            return $"Human.ToString()";
        }
    }
}

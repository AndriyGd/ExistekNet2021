using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class Human: Animal
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public int GetAge()
        {
            return DateTime.Now.Year - Birthday.Year;
        }
    }
}

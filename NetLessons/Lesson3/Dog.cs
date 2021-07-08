using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class Dog : Animal
    {
        public string Species { get; set; }

        public Dog()
        {
            var f = 33;
        }

        public override string Sound()
        {
            return "Gav-gav-gav";
        }
    }
}

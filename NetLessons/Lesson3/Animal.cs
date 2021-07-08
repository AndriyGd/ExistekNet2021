using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public Animal()
        {
            var b = 67;
        }

        public abstract string Sound();
        public virtual int Add()
        {
            return 45;
        }
    }
}

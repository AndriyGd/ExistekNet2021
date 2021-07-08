using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public sealed class Pitbull: Dog
    {
        public Pitbull()
        {
            var h = 67;
        }

        public override string Sound()
        {
            return "GAV-GAV-GAV-GAV";
        }
    }
}

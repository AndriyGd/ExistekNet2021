using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    public class UpperCaseAttribute: Attribute
    {
        public bool IsUpperCase { get; set; }
    }
}

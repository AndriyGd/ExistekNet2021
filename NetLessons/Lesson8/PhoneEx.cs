using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public partial class Phone
    {
        partial void OnCreated()
        {
            Console.WriteLine($"Phone '{Name}' created");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public partial class Phone
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public Phone()
        {
            Name = "Sumsung G34";
            OnCreated();
        }

        partial void OnCreated();
    }
}

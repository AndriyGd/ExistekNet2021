using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    partial class Point<T> where T: struct
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Point()
        {
            X = default(T);
            Y = default(T);
        }

        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }

        

        public override string ToString()
        {
            return $"X = {X}\nY = {Y}";
        }
    }
}

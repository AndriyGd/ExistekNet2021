using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLessons
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Book();
            //a.Add();
            //a.Sum();
            a.Init(10, 5);

            Console.WriteLine();

            var st = new Student();
            st.Start(20);


            int b = st.Bonus(459);
            string str = st.BonusStr(100);

            Console.WriteLine($"Bonus {b}");
            Console.WriteLine(str);

            Console.WriteLine();
            Console.WriteLine(a);

            Console.WriteLine();
            Console.WriteLine(st);

            st.Age = 27;
            st.Name = "Tom";

            var name = st.Name;
            //st.Address = "rtrtr";

            Console.WriteLine($"Name: {st.Name}");
            Console.WriteLine($"Age: {st.Age}");
            Console.WriteLine(st.Address) ;

            Console.ReadLine();
        }
    }

    public partial class Book
    {
        public void Add()
        {
            Result();
        }

        private void Result()
        {
            Console.WriteLine("Result");
        }

        public void Init(int a, int n)
        {
            for (var i = 0; i < n; i++)
            {
                Create($"({i + 1}) Book Result a + b", a, 56 * (i + 2));
            }
        }

        protected void Create(string text, int a, int b)
        {
            var res = a + b;
            Console.WriteLine($"{text} = {res}");
        }
    }

    class Student : Book
    {
        private Book _book;
        private string _name;

        public int Age { get; set; }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        } 

        public string Address 
        {
            get => "Soborna 45";
        }

        public void Start(int a)
        {
            Create("Student Result a + b", a, 100);
        }

        public int Bonus(int sum)
        {
            var bal = 8000;

            return bal + sum;
        }

        public string BonusStr(int sum)
        {
            var bal = 8000;
            var bonus = bal + sum;

            var res = $"{bonus}";

            return bonus.ToString();    
        }

        public override string ToString()
        {
            return "Hello NET Lessons";
        }
    }
}

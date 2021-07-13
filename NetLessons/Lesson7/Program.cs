using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            Run3();

            Console.ReadLine();
        }

        private static void Run1()
        {
            var lib = new Library();

            //var lib = new List<Book>();
            lib.Add(new Book { Author = "Tom", Name = "C#" });
            lib.Add(new Book { Author = "John", Name = "ASP.NET" });
            lib.Add(new Book { Author = "Aldin", Name = "Java" });
            lib.Add(new Book { Author = "Hamzik", Name = "CSS" });

            foreach (var book in lib)
            {
                Console.WriteLine(book);
            }

            var res = lib.Where(b => b.Name.Contains("C"));

            var t = 90;
            var s = "hello";

        }

        private static void Run2()
        {
            var a = GetNextItem();

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------");

            var nx = GetNextItem().ToList();
            Console.WriteLine("*******************");

            foreach (var item in nx)
            {
                Console.WriteLine(item);
            }
        }

        private static void Run3()
        {
            var collection = new MyCollection();

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<int> GetNextItem()
        {
            yield return 45;
            Console.WriteLine("Next 2");
            yield return 456;
            Console.WriteLine("Next 3");
            yield return 924;
            Console.WriteLine("Next 4");
            Console.WriteLine("Next 5");
            Console.WriteLine("Next 6");
            Console.WriteLine("Next 7");
            Console.WriteLine("Next 8");
            Console.WriteLine("Next 9");
            Console.WriteLine("Next 10");
            Console.WriteLine("Next 11");
            Console.WriteLine("Next 12");
            yield return -48855;
            Console.WriteLine("Finish");
            Console.WriteLine("Finish");
            Console.WriteLine("Finish");
            Console.WriteLine("Finish");
            Console.WriteLine("Finish");
            Console.WriteLine("Finish");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lesson9
{
    class Program
    {
        static void Main(string[] args)
        {
            Run1();

            //var book = new Book { Name = "Lessons .NET", Year = 2021, Author = "Davi" };
            //var fs = new FileStream("books.bin", FileMode.Create, FileAccess.Write);
            var bs = new BinaryFormatter();

            //bs.Serialize(fs, book);
            //fs.Close();
            //Console.WriteLine("OK");


            try
            {
                Console.WriteLine($"Current Dir: {Directory.GetCurrentDirectory()}");

                var fs = new FileStream("books.bin", FileMode.Open, FileAccess.Read);
                var dsBook = (Book)bs.Deserialize(fs);
                PrintPorps(dsBook.GetType(), dsBook);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        private static void Run1()
        {
            object obj = new Book { Name = "Food", Year = 2020 };
            var type = obj.GetType();
            Console.WriteLine($"Type: {type.FullName}");

            var atr = type.GetCustomAttributes(false);

            var upper = atr.FirstOrDefault(at => at is UpperCaseAttribute);

            if(upper != null)
            {
                var attribute = upper as UpperCaseAttribute;

                var s = attribute.IsUpperCase;
            }

            PrintPorps(type, obj);

            Console.WriteLine("-Set Value-");

            var propYear = type.GetProperty(nameof(Book.Year));
            propYear.SetValue(obj, 2015);
            Console.WriteLine($"Year New value: {propYear.GetValue(obj)}");

            var propPages = type.GetProperty(nameof(Book.Pages));
            if (propPages.CanWrite)
            {
                propPages.SetValue(obj, 1250);
                Console.WriteLine($"Pages New value: {propPages.GetValue(obj)}");
            }

            Console.WriteLine("Method===");
            var m = type.GetMethod("SetAuthor");
            m.Invoke(obj, new object[] { "Fog" });

            PrintPorps(type, obj);

            Console.WriteLine("Private Method");

            var m2 = type.GetMethod("Print");
            m2?.Invoke(obj, new object[] { });

            Console.WriteLine("------");
            var getIdM = type.GetMethod("GetId");
            var id = (Guid)getIdM.Invoke(obj, new object[] { });
            Console.WriteLine($"Book Id: {id}");
        }

        private static void PrintPorps(Type type, object obj)
        {
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine($"Property: {property.Name}, Type: {property.PropertyType.FullName}, Value: {property.GetValue(obj)}");
            }
        }
    }
}

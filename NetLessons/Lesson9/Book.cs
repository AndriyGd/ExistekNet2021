using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    [Serializable]
    [UpperCase(IsUpperCase = true)]
    public class Book
    {
        private readonly Guid _id;
        public string Name { get; set; }
        public int Year { get; set; }
        public int Pages { get; }
        public string Author { get; set; }

        public Book()
        {
            _id = Guid.NewGuid();

            Pages = 200;
        }

        public void SetAuthor(string author)
        {
            Author = author;
        }

        private void Print()
        {
            Console.WriteLine($"Print->Book Name: {Name}");
        }

        public Guid GetId() => _id;
    }
}

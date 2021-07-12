using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    //public class TomManager<T, Entity> where T: IPerson 
    //                               where Entity : new()

    public class TopManager<T> where T : IPerson, new()
    {
        private List<T> _persons;

        public TopManager()
        {
            _persons = new List<T>();

            T a = new T();
        }

        public void Add(T person)
        {
            _persons.Add(person);
        }

        public T Find(string name)
        {
            var person = _persons.FirstOrDefault(p => p.Name == name);

            return person;
        }
    }
}

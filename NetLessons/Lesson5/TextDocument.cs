using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public class TextDocument : IDocument
    {
        string _name;

        public byte[] Data { get ; set ; }
        //public string Name 
        //{
        //    get => $"Class Name: {_name}";
        //    set => _name = value;
        //}

        string IDocument.Name { get; set; }

        public DateTime CreationDate { get; set; }

        public TextDocument()
        {

        }

        public TextDocument(string name)
        {
            //Name = name;
        }


        string IDocument.ReadData()
        {
            return "TEST";
            //return $"TextDocument.{IDocument.Name}. ReadData()";
        }

        public void WriteData(string data)
        {
            //Console.WriteLine($"TextDocument.{Name}. WriteData()\nData: {data}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson5
{
    public class PdfDocument : IDocument, IFileUpload
    {
        public byte[] Data { get ; set ; }
        public string Name { get ; set ; }

        public string ReadData()
        {
            return $"PdfDocument.{Name}. ReadData()";
        }

        public bool Upload()
        {
            var i = 5;
            while (i != 0)
            {
                Console.WriteLine("PdfDocument.Uploading...");
                Thread.Sleep(500);

                i--;
            }

            return true;
        }

        public void WriteData(string data)
        {
            Console.WriteLine($"PdfDocument.{Name}. WriteData()\nData: {data}");
        }
    }
}

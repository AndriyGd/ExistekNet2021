using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    delegate void Message(string message);

    class Program
    {
        static void Main(string[] args)
        {
            Message dlg = new Message(Msg);
            dlg("Cool");

            var pdf = new PdfDocument { Name = "LOREM IPSUM" };

            dlg += pdf.WriteData;

            dlg += (msg) =>
            {
                Console.WriteLine(msg);
            };

            Console.WriteLine("----------");

            dlg("BADA BUM");

            var lst = dlg.GetInvocationList();

            var t = dlg.GetType();

            Console.ReadKey();
        }

        private static void Msg(string message)
        {
            Console.WriteLine($"Msg(): {message}");
        }

        private static void Run2()
        {
            IDocument text1 = new TextDocument("ASP.NET");
            //Console.WriteLine($"Document name: {text1.Name}");



            PrintName(text1);
            SetName(text1, "MVC");
            PrintName(text1);
        }

        private static void SetName(IDocument document, string name)
        {
            document.Name = name;
        }

        private static void PrintName(IDocument document)
        {
            Console.WriteLine($"Document name: {document.Name}");
        }

        private static void Run1()
        {
            IDocument textDocument = new TextDocument("NET 4.7");
            textDocument.WriteData("HELLO FROM MAIN");

            var pdfDocument = new PdfDocument { Name = "Lorem Ipsum" };
            pdfDocument.WriteData("LEsson5");

            //textDocument = pdfDocument;
            //Console.WriteLine();
            //textDocument.WriteData("TeST");

            Console.WriteLine("--------------");

            Console.WriteLine(Read(textDocument));
            Console.WriteLine(Read(pdfDocument));

            if (Upload(pdfDocument))
            {
                Console.WriteLine($"File '{pdfDocument.Name}' uploaded.");
            }
        }

        private static string Read(IDocument document)
        {
            return document.ReadData();
        }

        private static bool Upload(IFileUpload file)
        {
            return file.Upload();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScannerBL;


namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание объекта a с помощью перегруженного конструктора
            Scanner a = new Scanner("фирма", "тип", new Resolution(1000, 1000));

            Console.WriteLine(a.Firm);
            Console.WriteLine(a.ScannerType);
            Console.WriteLine(a.MaxResolution.ToString());

            // Создание объекта b с помощью конструктора по умолчанию
            Scanner b = new Scanner();

            b.Firm = "фирма2";
            b.ScannerType = "тип2";
            b.MaxResolution = new Resolution(0, 0);
            Console.WriteLine(b.Firm);
            Console.WriteLine(b.ScannerType);
            Console.WriteLine(b.MaxResolution.ToString());
            Console.ReadKey();
        }
    }
}

using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Создание объекта a с помощью перегруженного конструктора
            Scanner a = new Scanner("фирма", "тип", new Resolution(1000, 1000));

            Console.WriteLine("Объект созданный с помощью перегруженного конструктора:");
            Console.WriteLine(a.Firm);
            Console.WriteLine(a.ScannerType);
            Console.WriteLine(a.MaxResolution.ToString());
            #endregion
            Console.WriteLine();
            #region Создание объекта b с помощью конструктора по умолчанию
            Scanner b = new Scanner();

            Console.WriteLine("Объект созданный с помощью конструктора по умоланию:");
            b.Firm = "фирма2";
            b.ScannerType = "тип2";
            b.MaxResolution = new Resolution(0, 0);
            Console.WriteLine(b.Firm);
            Console.WriteLine(b.ScannerType);
            Console.WriteLine(b.MaxResolution.ToString());
            Console.ReadKey();
            #endregion
        }
    }
}

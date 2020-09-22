using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ввод
            int count = PareseInt("Введите количество объектов");
            Scanners scanners = new Scanners(count);
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine();
                string firm = ParseSring("Введите фирму:");
                string scannerType = ParseSring("Тип сканера:");
                int resWidth = PareseInt("Введите разрешение(ширина):");
                int resHeight = PareseInt("Введите разрешение(высота):");
                Resolution maxResolution = new Resolution(resWidth, resHeight);
                Scanner scanner = new Scanner(firm, scannerType, maxResolution);
                scanners[i] = scanner;
            }
            #endregion

            string fileName = "scaner.bin";

            #region сериализация
            Save(scanners, fileName);
            Console.WriteLine("\nОбьекты сериализованы\n");
            #endregion

            #region десериализация
            Scanners newScanners = Load(fileName);
            if(newScanners == null)
            {
                throw new Exception("newScanner равен null");
            }
            Console.WriteLine("Обьекты десериализованы\n");
            #endregion

            #region вывод
            foreach(Scanner s in scanners)
            {
                Console.WriteLine(s.GetInformation() + "\n");
            }
            #endregion
            Console.ReadKey();
        }

        static void Save(Scanners scanners, string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, scanners);
            }
        }

        static Scanners Load(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is Scanners item)
                {
                    return item;
                }
                else
                {
                    return null;
                }
            }
        }

        static string ParseSring(string message)
        {
            string str = string.Empty;
            while (str.Trim() == "")
            {
                Console.WriteLine(message);
                str = Console.ReadLine();
            }
            return str;
        }

        static int PareseInt(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                if (int.TryParse(Console.ReadLine(), out int i))
                {
                    return i;
                }
            }
        }
    }
}

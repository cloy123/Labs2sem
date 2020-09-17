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
            string firm = ParseSring("Введите фирму:");
            string scannerType = ParseSring("Тип сканера:");
            int resWidth = PareseInt("Введите разрешение(ширина):");
            int resHeight = PareseInt("Введите разрешение(высота):");

            Resolution maxResolution = new Resolution(resWidth, resHeight);

            int countFormats = PareseInt("Введите количество форматов:");

            string[] formats = new string[countFormats];

            for (int i = 0; i < countFormats; i++)
            {
                formats[i] = ParseSring($"Введите формат {i + 1}:");
            }
            #endregion

            string fileName = "scaner.bin";
            Scanner scanner = new Scanner(firm, scannerType, maxResolution, formats);

            #region сериализация
            Save(scanner, fileName);
            #endregion

            #region десериализация
            Scanner newScanner = Load(fileName);
            if(newScanner == null)
            {
                throw new Exception("newScanner равен null");
            }
            #endregion


            #region вывод
            Console.WriteLine(newScanner.GetInformation());
            Console.WriteLine("Форматы:");
            foreach (string s in newScanner.Formats)
            {
                Console.WriteLine(s);
            }
            #endregion

            Console.ReadKey();
        }

        

        static void Save(Scanner scanner, string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, scanner);
            }
        }

        static Scanner Load(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is Scanner item)
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

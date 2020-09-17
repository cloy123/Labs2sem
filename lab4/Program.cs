using System;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            string firm = ParseSring("Введите фирму:");
            string scannerType = ParseSring("Тип сканера:");

            int resWidth = PareseInt("Введите разрешение(ширина):");
            int resHeight = PareseInt("Введите разрешение(высота):");
            Resolution maxResolution = new Resolution(resWidth, resHeight);

            int countFormats = PareseInt("Введите количество форматов:");

            string[] formats = new string[countFormats];

            for(int i = 0; i < countFormats; i++)
            {
                formats[i] = ParseSring($"Введите формат {i + 1}:");
            }

            Scanner scanner = new Scanner(firm, scannerType, maxResolution, formats);

            Console.WriteLine(scanner.GetInformation());

            Console.WriteLine("Форматы:");
            foreach(string s in scanner.Formats)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }

        static string ParseSring(string name)
        {
            string str = string.Empty;
            while (str.Trim() == "")
            {
                Console.WriteLine(name);
                str = Console.ReadLine();
            }
            return str;
        }

        static int PareseInt(string name)
        {
            while (true)
            {
                Console.WriteLine(name);
                if (int.TryParse(Console.ReadLine(), out int i))
                {
                    return i;
                }
            }
        }

    }
}

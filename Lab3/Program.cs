using System;

namespace Lab3
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

            string connectionInterface = ParseSring("Введите интерфейс подключения");

            Scanner scanner = new Scanner(firm, scannerType, maxResolution);
            FlatbedScanner flatbedScanner = new FlatbedScanner(firm, maxResolution, connectionInterface);

            Console.WriteLine();
            Console.WriteLine(scanner.GetInformation());
            Console.WriteLine();
            Console.WriteLine(flatbedScanner.GetInformation());
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

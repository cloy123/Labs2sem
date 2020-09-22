using System;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = PareseInt("Введите количество объектов:");
            Scanners scanners = new Scanners(count);
            for (int i = 0; i < count; i++)
            {
                string firm = ParseSring("Введите фирму:");
                string scannerType = ParseSring("Тип сканера:");
                int resWidth = PareseInt("Введите разрешение(ширина):");
                int resHeight = PareseInt("Введите разрешение(высота):");
                Resolution maxResolution = new Resolution(resWidth, resHeight);
                Scanner scanner = new Scanner(firm, scannerType, maxResolution);
                scanners[i] = scanner;
            }

            foreach(Scanner s in scanners)
            {
                Console.WriteLine();
                Console.WriteLine(s.GetInformation());
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

using System;
using System.Diagnostics;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ввод
            int count = PareseInt("Введите количество объектов: ");
            Console.WriteLine();
            Scanners scanners = new Scanners(count);
            for (int i = 0; i < count; i++)
            {
                scanners[i] = new Scanner();
            }
            scanners.RandomNumbers();
            bool IsPrintArray = false;
            Console.Write("Выводить массивы(y/n)?  ");
            if(Console.ReadKey().Key == ConsoleKey.Y)
            { IsPrintArray = true; }
            Console.WriteLine("\n");
            #endregion
            Stopwatch timer = new Stopwatch();
            Scanners scannersClone = (Scanners)scanners.Clone();

            #region сортировка пузырьком
            Console.WriteLine("Сортировка пызырьком: ");
            if (IsPrintArray)
            {
                Console.Write("Массив до: ");
                PrintNumbersToCMD(scannersClone);
            }
            timer.Start();
            scannersClone.BubbleSort();
            timer.Stop();
            if (IsPrintArray)
            {
                Console.Write("Массив после: ");
                PrintNumbersToCMD(scannersClone);
            }
            Console.WriteLine($"Время:    {timer.ElapsedMilliseconds} ms\n");
            #endregion
            timer.Reset();
            scannersClone = (Scanners)scanners.Clone();

            #region Сортировка массива методом прямого выбора
            Console.WriteLine("Сортировка массива методом прямого выбора: ");
            if (IsPrintArray)
            {
                Console.Write("Массив до: ");
                PrintNumbersToCMD(scannersClone);
            }
            timer.Start();
            scannersClone.SelectionSort();
            timer.Stop();
            if (IsPrintArray)
            {
                Console.Write("Массив после: ");
                PrintNumbersToCMD(scannersClone);
            }
            Console.WriteLine($"Время:    {timer.ElapsedMilliseconds} ms\n");
            #endregion
            timer.Reset();
            scannersClone = (Scanners)scanners.Clone();

            #region сортировка прямыми включениями
            Console.WriteLine("Сортировка прямыми включениями: ");
            if (IsPrintArray)
            {
                Console.Write("Массив до: ");
                PrintNumbersToCMD(scannersClone);
            }
            timer.Start();
            scannersClone.InclusionSort();
            timer.Stop();
            if (IsPrintArray)
            {
                Console.Write("Массив после: ");
                PrintNumbersToCMD(scannersClone);
            }
            Console.WriteLine($"Время:    {timer.ElapsedMilliseconds} ms\n");
            #endregion
            timer.Reset();
            scannersClone = (Scanners)scanners.Clone();

            #region шейкерная сортировка
            Console.WriteLine("Шейкерная сортировка: ");
            if (IsPrintArray)
            {
                Console.Write("Массив до: ");
                PrintNumbersToCMD(scannersClone);
            }
            timer.Start();
            scannersClone.ShakerSort();
            timer.Stop();
            if (IsPrintArray)
            {
                Console.Write("Массив после: ");
                PrintNumbersToCMD(scannersClone);
            }
            Console.WriteLine($"Время:    {timer.ElapsedMilliseconds} ms\n");
            #endregion
            timer.Reset();
            scannersClone = (Scanners)scanners.Clone();

            #region Сортировка методом Шелла
            Console.WriteLine("Сортировка методом Шелла: ");
            if (IsPrintArray)
            {
                Console.Write("Массив до: ");
                PrintNumbersToCMD(scannersClone);
            }
            timer.Start();
            scannersClone.ShellSort();
            timer.Stop();
            if (IsPrintArray)
            {
                Console.Write("Массив после: ");
                PrintNumbersToCMD(scannersClone);
            }
            Console.WriteLine($"Время:    {timer.ElapsedMilliseconds} ms\n");
            #endregion
            Console.ReadLine();
        }

        static void PrintNumbersToCMD(Scanners s)
        {
            Console.Write("[ ");
            foreach(Scanner scanner in s)
            {
                Console.Write(scanner.Number + ", ");
            }
            Console.WriteLine("]");
        }

        static int PareseInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int i))
                {
                    return i;
                }
            }
        }
    }
}

using System;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;
using ScannerBL;

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
            Console.WriteLine($"Время:    {timer.ElapsedMilliseconds}\n");
            #endregion

            timer.Reset();
            scannersClone = (Scanners)scanners.Clone();

            #region обычная сортировка
            Console.WriteLine("Обычная сортировка: ");

            if (IsPrintArray)
            {
                Console.Write("Массив до: ");
                PrintNumbersToCMD(scannersClone);
            }

            timer.Start();
            scannersClone.Sort();
            timer.Stop();

            if (IsPrintArray)
            {
                Console.Write("Массив после: ");
                PrintNumbersToCMD(scannersClone);
            }
            Console.WriteLine($"Время:    {timer.ElapsedMilliseconds}\n");
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
            Console.WriteLine($"Время:    {timer.ElapsedMilliseconds}\n");
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
            Console.WriteLine($"Время:    {timer.ElapsedMilliseconds}\n");
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
            Console.WriteLine($"Время:    {timer.ElapsedMilliseconds}\n");
            #endregion
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

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Сортировка массива методом прямого выбора
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int[] Sort(int[] arr)
        {
            for(int i = 0; i < arr.Length - 1; i++)
            {
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[j] < arr[i])
                    {
                        Swap(ref arr[i], ref arr[j]);
                    }
                }
            }
            return arr;
        }

        /// <summary>
        /// Сортировка массива методом прямого обмена (пузырьковым методом)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int[] BubbleSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for(int j = 0; j < arr.Length - i; j++)
                {
                    if (arr[j + 1] < arr[j]) 
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }    
            }
                return arr;
        }

        /// <summary>
        /// Сортировка прямыми включениями
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int[] InclusionSort(int[] arr)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                int value = arr[i];
                int index = i;
                while((index > 0 ) && (arr[index - 1] > value))
                {
                    arr[index] = arr[index - 1];
                    index--;
                }
                arr[index] = value;
            }
            return arr;
        }

        /// <summary>
        /// Шейкерная сортировка
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int[] ShakerSort(int[] arr)
        {
            for(int i = 0; i < arr.Length / 2; i++)
            {
                bool swapFlag = false;
                for(int j = i; j < arr.Length - i -1; j++)
                {
                    if(arr[j] > arr[j+1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        swapFlag = true;
                    }
                }

                for(int j = arr.Length - 2 - i; j > i; j--)
                {
                    if(arr[j - 1] > arr[j])
                    {
                        Swap(ref arr[j - 1], ref arr[j]);
                        swapFlag = true;
                    }
                }
                if(!swapFlag)
                {
                    break;
                }
            }
            return arr;
        }

        /// <summary>
        /// Сортировка методом Шелла
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int[] ShellSort(int[] arr)
        {
            int interval = arr.Length / 2;
            while(interval >= 1)
            {
                for(int i = interval; i < arr.Length; i++)
                {
                    int j = i;
                    while((j >= interval) && (arr[j - interval] > arr[j]))
                    {
                        Swap(ref arr[j], ref arr[j - interval]);
                        j = j - interval;
                    }
                }
                interval /= 2;
            }
            return arr;
        }




    }
}

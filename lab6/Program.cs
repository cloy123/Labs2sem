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
            Scanner scanner = new Scanner();

            int arrCount = PareseInt("Введите количество элементов массива");
            scanner.ArrForSort = new int[arrCount];

            Random random = new Random();
            for(int i = 0; i < arrCount; i++)
            {
                
                scanner.ArrForSort[i] = random.Next(1, 150);
                //scanner.ArrForSort[i] = PareseInt($"Введите {i + 1} элемент массива:");
            }
            #endregion



            
            Stopwatch timer = new Stopwatch();
            int[] array;
            #region сортировка пузырьком
            timer.Start();
            array = BubbleSort((int[])scanner.ArrForSort.Clone());
            timer.Stop();
            Console.WriteLine($"Сортировка пызырьком:    {timer.ElapsedMilliseconds}");
            //PrintArrayToCMD(array);
            #endregion


            timer.Reset();

            #region обычная сортировка
            timer.Start();
            array = Sort((int[])scanner.ArrForSort.Clone());
            timer.Stop();
            Console.WriteLine($"Обычная сортировка:    { timer.ElapsedMilliseconds}");
            //PrintArrayToCMD(array);
            #endregion


            timer.Reset();

            #region сортировка прямыми включениями
            timer.Start();
            array = InclusionSort((int[])scanner.ArrForSort.Clone());
            timer.Stop();
            Console.WriteLine($"Cортировка прямыми включениями:    { timer.ElapsedMilliseconds}");
            //PrintArrayToCMD(array);
            #endregion


            timer.Reset();


            #region шейкерная сортировка
            timer.Start();
            array = ShakerSort((int[])scanner.ArrForSort.Clone());
            timer.Stop();
            Console.WriteLine($"Шейкерная сортировка:    { timer.ElapsedMilliseconds}");
            //PrintArrayToCMD(array);
            #endregion


            timer.Reset();


            #region Сортировка методом Шелла
            timer.Start();
            array = ShellSort((int[])scanner.ArrForSort.Clone());
            timer.Stop();
            Console.WriteLine($"Сортировка методом Шелла:    { timer.ElapsedMilliseconds}");
            //PrintArrayToCMD(array);
            #endregion


            timer.Reset();




        }


        static void PrintArrayToCMD(int[] arr)
        {
            foreach(int i in arr)
            {
                Console.WriteLine(i.ToString());
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

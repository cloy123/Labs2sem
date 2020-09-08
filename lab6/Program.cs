using System;
using System.Diagnostics;
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
                
                scanner.ArrForSort[i] = random.Next(1, 15);
                //scanner.ArrForSort[i] = PareseInt($"Введите {i + 1} элемент массива:");
            }
            #endregion

            //int[] array = (int[])scanner.ArrForSort.Clone();

            ////foreach(int i in BubbleSort(array))
            ////{
            ////    Console.WriteLine(i);
            ////}


            Stopwatch timer = new Stopwatch();

            //#region сортировка пузырьком

            //timer.Start();
            //BubbleSort((int[])scanner.ArrForSort.Clone());
            //timer.Stop();
            //Console.WriteLine((timer.ElapsedMilliseconds).ToString());

            //#endregion

            timer.Reset();



            // (int[])scanner.ArrForSort.Clone();


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


        static int[] BubbleSort(int[] arr)
        {
            int temp;
            for(int i = 0; i < arr.Length - 1; i++)
            {
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[j] < arr[i])
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            return arr;
        }
    }
}

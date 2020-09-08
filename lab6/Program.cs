using System;
using ScannerBL;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ввод
            Scanner scanner = new Scanner();

            int arrCount = PareseInt("введите количество элементов массива");
            scanner.ArrForSort = new int[arrCount];

            for(int i = 0; i < arrCount; i++)
            {
                scanner.ArrForSort[i] = PareseInt($"Введите {i + 1} элемент массива:");
            }
            #endregion

            int[] arr = (int[])scanner.ArrForSort.Clone();


            #region сортировка пузырьком
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            #endregion

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

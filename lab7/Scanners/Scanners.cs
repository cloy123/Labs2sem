using System;
using System.Collections;

namespace lab7
{
    class Scanners: IEnumerable, ICloneable
    {
        Scanner[] scanners;
        public int Lenght;
        public Scanner this [int pos]
        {
            get
            {
                if (pos >= 0 || pos < scanners.Length)
                { return scanners[pos]; }
                else
                { throw new IndexOutOfRangeException("Вне диапазона!"); }
            }
            set { scanners[pos] = value; }
        }
        public Scanners(int length)
        {
            if (length <= 0 || length > int.MaxValue)
            {
                throw new Exception("Длина массива не может быть меньше нуля или равна нулю");
            }
            scanners = new Scanner[length];
            for(int i = 0; i < length; i++)
            {
                scanners[i] = new Scanner();
            }
            Lenght = length;
        }
        public IEnumerator GetEnumerator()
        { return scanners.GetEnumerator(); }
        public object Clone()
        {
            Scanners s = new Scanners(this.scanners.Length);
            for(int i = 0; i < this.scanners.Length; i++)
            {
                s[i] = (Scanner)this[i].Clone();
            }
            return s;
        }
        public void RandomNumbers()
        {
            Random rnd = new Random();
            foreach(Scanner s in scanners)
            {
                s.Number = rnd.Next(1, 1000);
            }
        }
        private void Swap(ref Scanner a, ref Scanner b)
        {
            Scanner temp = a;
            a = b;
            b = temp;
        }
        public void SelectionSort()
        {
            for (int i = 0; i < scanners.Length - 1; i++)
            {
                for (int j = i + 1; j < scanners.Length; j++)
                {
                    if (scanners[j].Number < scanners[i].Number)
                    {
                        Swap(ref scanners[i], ref scanners[j]);
                    }
                }
            }
        }
        public void BubbleSort()
        {
            for (int i = 1; i < scanners.Length; i++)
            {
                for (int j = 0; j < scanners.Length - i; j++)
                {
                    if (scanners[j + 1].Number < scanners[j].Number)
                    {
                        Swap(ref scanners[j], ref scanners[j + 1]);
                    }
                }
            }
        }
        public void InclusionSort()
        {
            for (int i = 1; i < scanners.Length; i++)
            {
                Scanner value = scanners[i];
                int index = i;
                while ((index > 0) && (scanners[index - 1].Number > value.Number))
                {
                    scanners[index] = scanners[index - 1];
                    index--;
                }
                scanners[index] = value;
            }
        }
        public void ShakerSort()
        {
            for (int i = 0; i < scanners.Length / 2; i++)
            {
                bool swapFlag = false;
                for (int j = i; j < scanners.Length - i - 1; j++)
                {
                    if (scanners[j].Number > scanners[j + 1].Number)
                    {
                        Swap(ref scanners[j], ref scanners[j + 1]);
                        swapFlag = true;
                    }
                }
                for (int j = scanners.Length - 2 - i; j > i; j--)
                {
                    if (scanners[j - 1].Number > scanners[j].Number)
                    {
                        Swap(ref scanners[j - 1], ref scanners[j]);
                        swapFlag = true;
                    }
                }
                if (!swapFlag)
                { break; }
            }
        }
        public void ShellSort()
        {
            int interval = scanners.Length / 2;
            while (interval >= 1)
            {
                for (int i = interval; i < scanners.Length; i++)
                {
                    int j = i;
                    while ((j >= interval) && (scanners[j - interval].Number > scanners[j].Number))
                    {
                        Swap(ref scanners[j], ref scanners[j - interval]);
                        j = j - interval;
                    }
                }
                interval /= 2;
            }
        }
    }
}

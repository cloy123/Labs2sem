using System;
using System.Collections;

namespace lab5
{
    [Serializable]
    class Scanners: IEnumerable
    {
        Scanner[] scanners;
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
        }
        public IEnumerator GetEnumerator()
        { return scanners.GetEnumerator(); }
    }
}

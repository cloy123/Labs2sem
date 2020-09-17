using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Resolution
    {
        public int Width;
        public int Height;

        public Resolution(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Resolution()
        {
        }

        public override string ToString()
        {
                return $"{Width} * {Height}";
        }

    }
}

using System;

namespace lab6
{
    [Serializable]
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

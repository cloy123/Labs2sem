﻿using System;

namespace lab6
{
    public class Resolution: ICloneable
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

        public object Clone()
        {
            return new Resolution(this.Width, this.Height);
        }
    }
}

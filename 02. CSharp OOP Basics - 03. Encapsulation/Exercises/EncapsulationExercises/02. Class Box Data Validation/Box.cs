using System;

namespace ClassBoxDataValidation
{
    class Box
    {
        private double length;
        private double width;
        private double height;

        private double Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException($"Length cannot be zero or negative.");
                }
                length = value;
            }
        }
        private double Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException($"Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        private double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException($"Height cannot be zero or negative.");
                }
                height = value;
            }
        }


        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double GetSurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }
        public double GetLateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }
        public double GetVolume()
        {
            return Length * Width * Height;
        }
    }
}

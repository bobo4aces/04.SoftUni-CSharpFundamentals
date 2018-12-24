using System;

namespace ClassBox
{
    class Box
    {
        private double Length { get; set; }
        private double Width { get; set; }
        private double Height { get; set; }

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

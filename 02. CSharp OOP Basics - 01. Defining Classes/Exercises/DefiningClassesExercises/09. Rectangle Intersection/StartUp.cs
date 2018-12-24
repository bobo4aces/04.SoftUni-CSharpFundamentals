using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleIntersection
{
    public class StartUp
    {
        static void Main()
        {
            int[] info = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rectanglesCount = info[0];
            int intersectionChecksCount = info[1];

            List<Rectangle> rectangles = new List<Rectangle>();
            ReadRectangles(rectanglesCount, rectangles);

            for (int i = 0; i < intersectionChecksCount; i++)
            {
                string[] ids = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (IsRectangleExists(rectangles, ids[0]) && IsRectangleExists(rectangles, ids[1]))
                {
                    Rectangle firstRectangle = GetRectangle(rectangles, ids[0]);
                    Rectangle secondRectangle = GetRectangle(rectangles, ids[1]);
                    bool isIntersect = Rectangle.IsIntersect(firstRectangle, secondRectangle);
                    Console.WriteLine(isIntersect.ToString().ToLower());
                }

            }
        }

        private static bool IsRectangleExists(List<Rectangle> rectangles, string rectangleName)
        {
            return rectangles.Any(r => r.Id == rectangleName);
        }

        private static Rectangle GetRectangle(List<Rectangle> rectangles, string rectangleName)
        {
            return rectangles.Where(r => r.Id == rectangleName).First();
        }

        private static void ReadRectangles(int rectanglesCount, List<Rectangle> rectangles)
        {
            for (int i = 0; i < rectanglesCount; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Rectangle rectangle = new Rectangle(
                    info[0],
                    double.Parse(info[1]),
                    double.Parse(info[2]),
                    new Point(double.Parse(info[3]), double.Parse(info[4])));
                rectangles.Add(rectangle);
            }
        }
    }
}

using System;

namespace RectangleIntersection
{
    public class Rectangle
    {
        public string Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Point TopLeftCorner { get; set; }

        public Rectangle(string id, double width, double height, Point topLeftCorner)
        {
            Id = id;
            Width = width;
            Height = height;
            TopLeftCorner = topLeftCorner;
        }

        public static bool IsIntersect(Rectangle firstRectagle, Rectangle secondRectangle)
        {

            
            bool isOnBottomRight = firstRectagle.TopLeftCorner.X + firstRectagle.Width <
                                   secondRectangle.TopLeftCorner.X;
            bool isOnBottomLeft = secondRectangle.TopLeftCorner.X + secondRectangle.Width <
                                  firstRectagle.TopLeftCorner.X;
            bool isOnTopLeft = firstRectagle.TopLeftCorner.Y + firstRectagle.Height <
                               secondRectangle.TopLeftCorner.Y;
            bool isOnTopRight = secondRectangle.TopLeftCorner.Y + secondRectangle.Height <
                                firstRectagle.TopLeftCorner.Y;
            return !(isOnTopLeft || isOnTopRight || isOnBottomLeft || isOnBottomRight);
        }
    }
}

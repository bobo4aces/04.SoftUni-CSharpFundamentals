using System;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        //public int LeftX { get; set; }
        //public int TopY { get; set; }
        private int leftX;
        private int topY;

        public int LeftX
        {
            get
            {
                return leftX;
            }
            set
            {
                if (value < 0 || value > Console.WindowWidth)
                {
                    throw new IndexOutOfRangeException();
                }
                leftX = value;
            }
        }
        public int TopY
        {
            get
            {
                return topY;
            }
            set
            {
                if (value < 0 || value > Console.WindowHeight)
                {
                    throw new IndexOutOfRangeException();
                }
                topY = value;
            }
        }

        public Point(int leftX, int topY)
        {
            LeftX = leftX;
            TopY = topY;
        }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(LeftX, TopY);
            Console.Write(symbol);
        }
        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }

    }
}

using System;
using System.Collections.Generic;

namespace SimpleSnake.GameObjects.Foods
{
    abstract class Food : Point
    {
        private char foodSymbol;
        Random random = new Random();
        public int FoodPoints { get; private set; }

        public Food(Wall wall, char foodSymbol, int points)
            :base(leftX, topY)
        {
            
        }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            LeftX = random.Next(2, Wall)
        }
    }
}

namespace SnakeConsoleGame.GameObjects.Foods
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public abstract class Food : Point
    {
        private readonly Wall wall;
        private readonly Random random;
        private readonly char foodSymbol;
 

        protected Food(Wall wall, char foodSymbol, int foodPoints)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            FoodPoints = foodPoints;

            random = new Random();
        }

        public int FoodPoints { get;}

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);

            bool isPointOfSnake = IsPointOfSnake(snakeElements);

            while (isPointOfSnake)
            {
                LeftX = random.Next(2, wall.LeftX - 2);
                TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnake = IsPointOfSnake(snakeElements);
            }

            //Console.BackgroundColor = ConsoleColor.Red;
            Draw(foodSymbol);
           //Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
            => LeftX == snake.LeftX
            && TopY == snake.TopY;

        private bool IsPointOfSnake(Queue<Point> snakeElements)
        => snakeElements.Any(x => x.LeftX == LeftX && x.TopY == TopY);
        
    }
}

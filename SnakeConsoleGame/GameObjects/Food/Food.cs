namespace SnakeConsoleGame.GameObjects.Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private readonly Random random;
        private readonly Wall wall;
 

        protected Food(Wall wall, char symbol, int foodPoints)
            : base(wall.LeftX, wall.TopY)
        {
            Symbol = symbol;
            FoodPoints = foodPoints;
            this.wall = wall; 

            random = new Random();
        }

        public char Symbol { get;}

        public int FoodPoints { get;}

        public void SetRandomPosition(Queue<Point> snake)
        {
            //wall
            //snake
            LeftX = random.Next(1, wall.LeftX - 1);
            TopY = random.Next(1, wall.TopY - 1);

            var isPartOfSnake = snake.Any(x => x.LeftX == LeftX && x.TopY == TopY);

            while (isPartOfSnake)
            {
                LeftX = random.Next(1, wall.LeftX - 1);
                TopY = random.Next(1, wall.TopY - 1);

                isPartOfSnake = snake.Any(x => x.LeftX == LeftX && x.TopY == TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Draw(LeftX, TopY, Symbol);
            Console.BackgroundColor = ConsoleColor.White;

        }

        public bool isFoodPoint(Point snake)
            => LeftX == snake.LeftX
            && TopY == snake.TopY;
    }
}

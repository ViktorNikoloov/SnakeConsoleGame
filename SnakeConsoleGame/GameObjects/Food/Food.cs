using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeConsoleGame.GameObjects
{
    public class Food : Point
    {
        private readonly Random random;
        private readonly Wall wall;


        protected Food(Wall wall, char symbol, int foodPoints)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;

            random = new Random();
        }

        public void SetRandomPosition(Queue<Point> snake)
        {
            //wall
            //snake
            LeftX = random.Next(1, wall.LeftX);
            TopY = random.Next(1, wall.TopY);

            var isPartOfSnake = snake.Any(x => x.LeftX == LeftX && x.TopY == TopY);

            while (isPartOfSnake)
            {
                LeftX = random.Next(1, wall.LeftX);
                TopY = random.Next(1, wall.TopY);

                isPartOfSnake = snake.Any(x => x.LeftX == LeftX && x.TopY == TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Draw(LeftX, TopY, '$');
            Console.BackgroundColor = ConsoleColor.White;

        }

        public bool isFoodPoint(Point snake)
            => LeftX == snake.LeftX
            && TopY == snake.TopY;
    }
}

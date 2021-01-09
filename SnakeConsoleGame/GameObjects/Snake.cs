namespace SnakeConsoleGame.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Foods;

    public class Snake : Point
    {
        private const char SnakeSymbol = '\u25CF';

        private readonly Queue<Point> snakeElements;
        private readonly Food[] foods;
        private readonly Wall wall;

        private int foodIndex;

        public Snake(Wall wall, int leftX, int topY) 
            : base(leftX, topY)
        {
            this.wall = wall;
            foods = new Food[3];

            foodIndex = RandomFoodNumber;
            snakeElements = new Queue<Point>();

            CreateSnake();
        }

        private void CreateSnake()
        {
            for (int i = 0; i <= 6; i++)
            {
                var point = new Point(LeftX + i, TopY);
                point.Draw(SnakeSymbol);

                snakeElements.Enqueue(point);
            }
        }

        public int RandomFoodNumber
            => new Random().Next(0, foods.Length);

        public bool isMoving(Point direction)
        {
            var currentSnakeHead = snakeElements.Last();

            GetNextDirection(currentSnakeHead, direction);

            if (LeftX == 0 || TopY == 0 || LeftX == wall.LeftX || TopY == wall.TopY)
            {
                return false;
            }

            if (snakeElements.Any(x=> LeftX == LeftX && TopY==TopY))
            {
                return false;
            }

            var snakeNewHead = new Point(LeftX, TopY);
            snakeNewHead.Draw(SnakeSymbol);
            snakeElements.Enqueue(snakeNewHead);

            if (foods[foodIndex].isFoodPoint(snakeNewHead))
            {
                GetNextDirection(snakeNewHead, direction);
                snakeNewHead = new Point(LeftX, TopY);
                snakeNewHead.Draw(SnakeSymbol);
                snakeElements.Enqueue(snakeNewHead);
            }

            var tail = snakeElements.Dequeue();
            tail.Draw(' ');

            


            return true;
        }

        private void GetNextDirection(Point head, Point direction)
        {
            LeftX = head.LeftX + direction.LeftX;
            TopY = head.TopY + direction.TopY;
        }


        private void GetFoods()
        {
            foods[0] = new FoodHash(wall);
            foods[1] = new FoodDollar(wall);
            foods[2] = new FoodAsterisk(wall);
        }
    }
}

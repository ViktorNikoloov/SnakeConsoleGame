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

            GetFoods();
            CreateSnake();

        }

        private void CreateSnake()
        {
            for (int leftX = 0; leftX < 6; leftX++)
            {
                var point = new Point(LeftX + leftX, TopY);
                point.Draw(SnakeSymbol);

                snakeElements.Enqueue(point);
            }

            foods[foodIndex].SetRandomPosition(snakeElements);
        }

        public int RandomFoodNumber
            => new Random().Next(0, foods.Length);

        public int Length
        => snakeElements.Count;

        public bool isMoving(Point direction)
        {
            var currentSnakeHead = snakeElements.Last();

            GetNextDirection(currentSnakeHead, direction);

            if (LeftX == 0 || TopY == 0 || LeftX == wall.LeftX - 1 || TopY == wall.TopY - 1)
            {
                return false;
            }



            if (IsPointOfSnake())
            {
                return false;
            }

            Point snakeNewHead = CreateNewHead();

            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                Eat(direction, snakeNewHead);
            }

            RemoveTail();

            return true;
        }

        private void RemoveTail()
        {
            Point tail = snakeElements.Dequeue();
            tail.Draw(' ');
        }

        private Point CreateNewHead()
        {
            Point snakeNewHead = new Point(LeftX, TopY);
            snakeNewHead.Draw(SnakeSymbol);
            snakeElements.Enqueue(snakeNewHead);
            return snakeNewHead;
        }

        private void Eat(Point direction, Point snakeNewHead)
        {
            for (int i = 0; i < foods[foodIndex].FoodPoints; i++)
            {
                GetNextDirection(snakeNewHead, direction);

                snakeNewHead = new Point(LeftX, TopY);
                snakeNewHead.Draw(SnakeSymbol);

                snakeElements.Enqueue(snakeNewHead);
            }

            foods[foodIndex].SetRandomPosition(snakeElements);
        }

        private bool IsPointOfSnake()
        => snakeElements.Any(x => x.LeftX == LeftX && x.TopY == TopY);
        
        private void GetFoods()
        {
            foods[0] = new FoodHash(wall);
            foods[1] = new FoodDollar(wall);
            foods[2] = new FoodAsterisk(wall);
        }

        private void GetNextDirection(Point head, Point direction)
        {
            LeftX = head.LeftX + direction.LeftX;
            TopY = head.TopY + direction.TopY;
        }
    }
}

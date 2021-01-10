namespace SnakeConsoleGame.GameObjects
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

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
            for (int leftX = 1; leftX <= 6; leftX++)
            {
                snakeElements.Enqueue(new Point(leftX, 2));
            }

            foods[foodIndex].SetRandomPosition(snakeElements);
        }

        public int RandomFoodNumber
            => new Random().Next(0, foods.Length);

        public int Length
        => snakeElements.Count;

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = snakeElements.Last();

            GetNextDirection(currentSnakeHead, direction);

            if (IsPointOfSnake())
            {
                return false;
            }

            Point snakeNewHead = new Point(LeftX, TopY);

            if (wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(SnakeSymbol);

            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                Eat(direction, currentSnakeHead);
            }

            RemoveTail();

            return true;
        }

        private void RemoveTail()
        {
            Point tail = snakeElements.Dequeue();
            tail.Draw(' ');
        }

        //private Point CreateNewHead()
        //{
        //    Point snakeNewHead = new Point(LeftX, TopY);
        //    snakeElements.Enqueue(snakeNewHead);
        //    snakeNewHead.Draw(SnakeSymbol);
        //    return snakeNewHead;
        //}

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = foods[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Point(LeftX, TopY));
                GetNextDirection(currentSnakeHead, direction);
            }

            wall.Addpoints(snakeElements);
            wall.PlayerInfo();

            foodIndex = RandomFoodNumber;
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

        private void GetNextDirection(Point snakeHead, Point direction)
        {
            LeftX = snakeHead.LeftX + direction.LeftX;
            TopY = snakeHead.TopY + direction.TopY;
        }
    }
}

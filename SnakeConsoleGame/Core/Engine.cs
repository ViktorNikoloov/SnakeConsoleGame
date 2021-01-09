using SimpleSnake.Enums;
using SnakeConsoleGame.GameObjects;
using System;
using System.Threading;

namespace SnakeConsoleGame.Core
{
    public class Engine
    {
        private Direction direction;
        private readonly Snake snake;

        private Point[] directionPoints;
        private int sleepTime = 100;

        public Engine(Snake snake)
        {
            this.snake = snake;

            direction = Direction.Right;

            directionPoints = new Point[]
            {
                new Point(1,0),
                new Point(-1,0),
                new Point(0,1),
                new Point(0,-1),
            };
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                var canMove = snake.isMoving(directionPoints[(int)direction]);

                if (!canMove)
                {
                    Environment.Exit(0);
                }

                Thread.Sleep(sleepTime);
            }
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (input.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (input.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
        }
    }
}

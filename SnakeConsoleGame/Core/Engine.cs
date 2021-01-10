using SimpleSnake;
using SimpleSnake.Enums;
using SnakeConsoleGame.GameObjects;
using System;
using System.IO;
using System.Threading;

namespace SnakeConsoleGame.Core
{
    public class Engine
    {
        private Direction direction;
        private readonly Snake snake;
        private readonly Wall wall;

        private Point[] directionPoints;
        private int sleepTime = 100;

        public object DataTime { get; private set; }

        public Engine(Snake snake, Wall wall)
        {
            this.snake = snake;
            this.wall = wall;
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
                    Console.SetCursorPosition(0, wall.TopY + 2);

                    //TODO: Refactoring after DB course
                    File.AppendAllText("../../../Database/Scores.txt", $"Nikolov - {snake.Length} - {DateTime.Now.ToString("MM/dd/yyyy HH:mm")}{Environment.NewLine}");

                    var results = File.ReadAllText("../../../Database/Scores.txt");

                    Console.WriteLine(results);
                    Console.WriteLine("Game Over!"); 

                    Thread.Sleep(2000);

                    StartUp.Main();
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

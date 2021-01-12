namespace SnakeConsoleGame.Core
{
    using System;
    using System.IO;
    using System.Threading;

    using Enums;
    using GameObjects;

    public class Engine
    {
        private readonly Point[] directionPoints;
        private readonly Snake snake;
        private readonly Wall wall;

        private Direction direction;
        private double sleepTime;

        public object DataTime { get; private set; }

        public Engine(Snake snake, Wall wall)
        {
            this.snake = snake;
            this.wall = wall;

            direction = Direction.Right;

            directionPoints = new Point[4];

            sleepTime = 100;
        }

        public void Run()
        {
            CreateDiractions();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool canMove = snake.IsMoving(directionPoints[(int)direction]);

                if (!canMove)
                {
                    ////TODO: Refactoring after DB course !
                    File.AppendAllText("../../../Database/Scores.txt", $"Nikolov - {snake.Length} - {DateTime.Now.ToString("MM/dd/yyyy HH:mm")}{Environment.NewLine}");

                    AskUserForRestart();
                }

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int leftX = wall.LeftX + 2;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");
            Console.WriteLine();

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
        }

        private void CreateDiractions()
        {
            directionPoints[0] = new Point(1, 0);
            directionPoints[1] = new Point(-1, 0);
            directionPoints[2] = new Point(0, 1);
            directionPoints[3] = new Point(0, -1);
        }
    }
}

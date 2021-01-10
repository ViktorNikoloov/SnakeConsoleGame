namespace SimpleSnake
{
    using SnakeConsoleGame.Core;
    using SnakeConsoleGame.GameObjects;
    using System;
    using System.IO;
    using System.Linq;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);
            Snake snake = new Snake(wall, 1, 6);

            Engine engine = new Engine(snake, wall);

            Console.SetCursorPosition(0, wall.TopY + 2);

            var results = File.ReadAllLines("../../../Database/Scores.txt").OrderByDescending(x=>int.Parse(x.Split(" - ", StringSplitOptions.RemoveEmptyEntries)[1])).Take(10);

            Console.WriteLine(string.Join(Environment.NewLine, results));

            engine.Run();

        }
    }
}

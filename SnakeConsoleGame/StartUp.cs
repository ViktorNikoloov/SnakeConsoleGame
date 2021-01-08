namespace SimpleSnake
{
    using SnakeConsoleGame.GameObjects;
    using System.Collections.Generic;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            //Point point = new Point(0, 0);

            //point.Draw('@');
            //point.Draw(1, 1, '1');
            //point.Draw(2, 2, '2');
            //point.Draw(0, 1, '0');

            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);

            Food food = new Food(wall, 0, 0);
            food.SetRandomPosition(new Queue<Point>());
        }
    }
}

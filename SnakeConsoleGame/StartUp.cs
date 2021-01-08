namespace SimpleSnake
{
    using SnakeConsoleGame.GameObjects;
    using SnakeConsoleGame.GameObjects.Food;
    using System.Collections.Generic;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);

            Food food = new FoodHash(wall);
            food.SetRandomPosition(new Queue<Point>());
        }
    }
}

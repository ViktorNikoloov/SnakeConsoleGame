namespace SimpleSnake
{
    using SnakeConsoleGame.GameObjects;
    using SnakeConsoleGame.GameObjects.Foods;
    using System.Collections.Generic;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            Food
            Wall wall = new Wall(60, 20);

            Food food = new FoodHash(wall);
            food.SetRandomPosition(new Queue<Point>());

            Snake snake = new Snake(1, 1);
            snake.isMoving(new Point(1,0));
            snake.isMoving(new Point(1,0));
            snake.isMoving(new Point(1,0));
            snake.isMoving(new Point(1,0));
            snake.isMoving(new Point(1,0));
            snake.isMoving(new Point(1,0));
            snake.isMoving(new Point(0,1));
            snake.isMoving(new Point(0,1));
            snake.isMoving(new Point(0,1));
            snake.isMoving(new Point(0,1));
            snake.isMoving(new Point(0,1));

        }
    }
}

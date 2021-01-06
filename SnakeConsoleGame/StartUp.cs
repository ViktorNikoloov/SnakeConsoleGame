namespace SimpleSnake
{
    using SnakeConsoleGame.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            //Point point = new Point(0, 0);

            //point.Draw('@');
            //point.Draw(1, 1, '1');
            //point.Draw(2, 2, '2');
            //point.Draw(0, 1, '0');


            Wall wall = new Wall(20, 15);


        }
    }
}

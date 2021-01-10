namespace SnakeConsoleGame.GameObjects
{
    using System;

    public class Point
    {
        private int leftX;
        private int topY;

        public Point(int leftX, int topY)
        {
            LeftX = leftX;
            TopY = topY;
        }

        public int LeftX
        {
            get => leftX;
            set
            {
                if (value < - 1 || value > Console.WindowWidth)
                {
                    throw new IndexOutOfRangeException();
                }

                leftX = value;
            }
        }

        public int TopY
        {
            get => topY;
            set
            {
                if (value < -1 || value > Console.WindowHeight)
                {
                    throw new IndexOutOfRangeException();
                }

                topY = value;
            }
        }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(LeftX, TopY);
            Console.Write(symbol);
        }

        public void Draw(int left, int top, char symbol)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(symbol);
        }
    }
}

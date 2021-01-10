namespace SnakeConsoleGame.GameObjects
{
    using System;
    using System.Collections.Generic;

    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';  //■

        private int playerPoints;
       
        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            InitializeWallBorders();
        }

        public bool IsPointOfWall(Point snake)
            => snake.LeftX == 0
            || snake.LeftX == LeftX
            || snake.TopY == 0
            || snake.TopY == TopY - 1;

        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(TopY - 1);

            SetVerticalLine(0);
            SetVerticalLine(LeftX);
        }

        private void SetHorizontalLine(int top)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                Draw(leftX, top, WallSymbol);
            }
        }

        private void SetVerticalLine(int left)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                Draw(left, topY, WallSymbol);
            }
        }

        public void Addpoints(Queue<Point> snakeElements)
        => playerPoints = snakeElements.Count - 6;
        
        public void PlayerInfo()
        {
            Console.SetCursorPosition(LeftX + 3, 0);
            Console.Write($"Player points: {this.playerPoints}");

            Console.SetCursorPosition(LeftX + 3, 1);
            Console.Write($"Player level: {this.playerPoints / 10}");
        }

    }
}

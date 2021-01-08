namespace SnakeConsoleGame.GameObjects
{
    using System;

    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';  //■
       
        public Wall(int leftX, int topY) 
            : base(leftX, topY)
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
    }
}

using System;

namespace SnakeConsoleGame.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';  //■
       
        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            SetHorizontalLine(0);
            SetHorizontalLine(TopY - 1);

            SetVerticallLine(0);
            SetVerticallLine(LeftX);
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }

        private void SetVerticallLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }
    }
}

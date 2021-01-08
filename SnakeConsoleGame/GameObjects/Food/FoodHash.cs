namespace SnakeConsoleGame.GameObjects.Food
{
    public class FoodHash : Food
    {
        private const char FoodSymbol = '#';
        private const int Points = 4;

        public FoodHash(Wall wall) 
            : base(wall, FoodSymbol, Points)
        {

        }
    }
}

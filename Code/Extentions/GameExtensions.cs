using System.Collections.Generic;
using System.Linq;

namespace _GAME.Code.Extentions
{
    public static class GameExtensions
    {
        public static float CalculatePercentageOfTheNumber(int percentage, int number)
        {
            float cof = number / 100f;
            
            return cof * percentage;
        }
    }
}
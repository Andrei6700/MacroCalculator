using MacroCalculator.Interfaces;
using System;

namespace MacroCalculator.Logic
{
    public class MaintainCaloriesCalculator : ICalorieCalculator
    {
        public double CalculateCalories(double bmr, double activityFactor, int surplusOrDeficit)
        {
            return bmr * activityFactor;
        }
    }
}

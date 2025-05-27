using MacroCalculator.Interfaces;
using System;

namespace MacroCalculator.Logic
{
    public class MaintenanceCaloriesCalculator : ICalorieCalculator
    {
        public double CalculateCalories(double bmr, double activityFactor, int surplusOrDeficit)
        {
            double tdee = bmr * activityFactor;
            return tdee + 0;
        }
    }
}
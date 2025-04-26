using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroCalculator.Interfaces
{
    public interface ICalorieCalculator
    {
        double CalculateCalories(double bmr, double activityFactor, int surplusOrDeficit);
    }
}

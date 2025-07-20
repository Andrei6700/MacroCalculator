using System;
using System.Data;

namespace MacroCalculator.Logic
{
    public class MacroCalculatorLogic
    {
        // logic for calculating BMR, TDEE, and macros
        public double CalculateBMR(double weight, double height, int age, bool isMale)
        {
            if (isMale)
                return 10 * weight + 6.25 * height - 5 * age + 5;
            else
                return 10 * weight + 6.25 * height - 5 * age - 161;
        }

        // logic of total daily energy expenditure
        public double CalculateTDEE(double bmr, double activityFactor)
        {
            return bmr * activityFactor;
        }

        // logic gor calculating calories for bulk and cut
        public double CalculateTotalCaloriesForBulk(double bmr, double activityFactor, int surplus)
        {
            return CalculateTDEE(bmr, activityFactor) + surplus;
        }

        public double CalculateTotalCaloriesForCut(double bmr, double activityFactor, int deficit)
        {
            return CalculateTDEE(bmr, activityFactor) - deficit;
        }

        public DataTable BuildMacroTable(double totalCalories, double weight, double proteinRatio)
        {
            var table = new DataTable();
            table.Columns.Add("Macro", typeof(string));
            table.Columns.Add("Value", typeof(string));

            int cal = (int)Math.Round(totalCalories);
            table.Rows.Add("Total calories", cal + " kcal");
            table.Rows.Add("Carbs", ((int)Math.Round((totalCalories * 0.5) / 4)).ToString());
            table.Rows.Add("Protein", ((int)Math.Round(weight * proteinRatio)).ToString());
            table.Rows.Add("Fats", ((int)Math.Round((totalCalories * 0.25) / 9)).ToString());
            table.Rows.Add("Fiber", ((int)Math.Round((totalCalories / 1000) * 14)).ToString());

            return table;
        }

        // logic for calculating days needed to reach the target in cut (aggresive or lean)
        public int CalculateDaysNeeded(double currentWeight, double targetWeight, int dailyDeficit)
        {
            double diff = currentWeight - targetWeight;
            if (diff <= 0)
                return 0;
            double days = (diff * 7700) / dailyDeficit; // 7700 kcal = 1 kg of fat
            return (int)Math.Ceiling(days);
        }
    }
}
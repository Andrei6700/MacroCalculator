using MacroCalculator.Maintain;
using System;
using MacroCalculator.BulkPage;
using MacroCalculator.CutPage;

namespace MacroCalculator.Factory_MacroCalculator
{
    // create instances based of the diet choosed
    public static class DietPlanFactory
    {
        public static IDietPlanPage CreateDietPlan(string dietType)
        {
            switch (dietType)
            {
                case "Bulk":
                    return new MacroCalculator.BulkPage.BulkPage();
                case "Cut":
                    return new MacroCalculator.CutPage.CutPage();
                case "Maintain":
                    return new MacroCalculator.Maintain.MaintainPage();
                default:
                    throw new ArgumentException("Invalid diet type");
            }
        }
    }
}
using MacroCalculator.Maintain;
using System;
using MacroCalculator.BulkPage;
using MacroCalculator.CutPage;
using MacroCalculator.Factory_MacroCalculator;

namespace MacroCalculator.Factory_MacroCalculator
{
    public abstract class DietPlanFactory
    {
        public abstract IDietPlanPage CreatePage();
    }
}
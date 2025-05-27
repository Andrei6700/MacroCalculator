using MacroCalculator.Maintain;
using System;
using MacroCalculator.BulkPage;
using MacroCalculator.CutPage;
using MacroCalculator.Factory_MacroCalculator;

namespace MacroCalculator.Factory_MacroCalculator
{
    // Creatorul – defineşte semnătura metodei de fabricaţie
    public abstract class DietPlanFactory
    {
        public abstract IDietPlanPage CreatePage();
    }
}
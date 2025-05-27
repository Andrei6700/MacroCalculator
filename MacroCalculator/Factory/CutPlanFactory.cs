using MacroCalculator.CutPage;
using MacroCalculator.Factory_MacroCalculator;

namespace MacroCalculator.Factory_MacroCalculator
{
    public class CutPlanFactory : DietPlanFactory
    {
        public override IDietPlanPage CreatePage()
            => new MacroCalculator.CutPage.CutPage();
    }
}
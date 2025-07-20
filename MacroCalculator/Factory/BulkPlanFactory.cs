using MacroCalculator.BulkPage;
using MacroCalculator.Factory_MacroCalculator;

namespace MacroCalculator.Factory_MacroCalculator
{
    public class BulkPlanFactory : DietPlanFactory
    {
        public override IDietPlanPage CreatePage()
            => new MacroCalculator.BulkPage.BulkPage();
    }
}
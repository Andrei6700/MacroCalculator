using MacroCalculator.Maintain;
using MacroCalculator.Factory_MacroCalculator;

namespace MacroCalculator.Factory_MacroCalculator
{
    public class MaintainPlanFactory : DietPlanFactory
    {
        public override IDietPlanPage CreatePage()
            => new MacroCalculator.Maintain.MaintainPage();
    }
}
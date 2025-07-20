using Microsoft.VisualStudio.TestTools.UnitTesting;
using MacroCalculator.Logic;
using MacroCalculator.Interfaces;

namespace UnitTest
{
    [TestClass]
    public class StrategyTests
    {
        [TestMethod]
        public void BulkCaloriesCalculator_ShouldAddSurplusCorrectly()
        {
            ICalorieCalculator strategy = new BulkCaloriesCalculator();
            double bmr = 1600;
            double activity = 1.55;
            int surplus = 250;

            double total = strategy.CalculateCalories(bmr, activity, surplus);

            Assert.AreEqual(2730, total, 0.01);
        }
    }
}

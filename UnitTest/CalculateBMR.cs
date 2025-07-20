using Microsoft.VisualStudio.TestTools.UnitTesting;
using MacroCalculator.Logic;

namespace UnitTest
{
    [TestClass]
    public class LogicTests
    {
        [TestMethod]
        public void CalculateBMR_ShouldReturnCorrectValue_ForMale()
        {
            var logic = new MacroCalculatorLogic();
            double weight = 70; 
            double height = 175; 
            int age = 25;
            bool isMale = true;

            double bmr = logic.CalculateBMR(weight, height, age, isMale);


            Assert.AreEqual(1673.75, bmr, 0.01); 
        }
    }
}

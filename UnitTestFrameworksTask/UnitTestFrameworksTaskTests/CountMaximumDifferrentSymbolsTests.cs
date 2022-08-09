using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestFrameworksTask.Tests
{
    [TestClass()]
    public class CountMaximumDifferrentSymbolsTests
    {
        [TestMethod()]
        [DataRow("q1w2e33",6)]
        [DataRow("q1w2ee3r4t55",6)]
        public void CountMaximumDifferrentSymbolsTest(string value, int expected)
        {
            // arrange
            int result;
            Calculation calculation = new Calculation();

            //act
            result = calculation.CountMaximumDifferrentSymbols(value);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
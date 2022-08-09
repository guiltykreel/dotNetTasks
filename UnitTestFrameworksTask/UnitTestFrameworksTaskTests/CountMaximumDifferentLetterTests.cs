using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestFrameworksTask.Tests
{
    [TestClass()]
    public class CountMaximumDifferentLetterTests
    {
        [TestMethod()]
        [DataRow("qwertyy", 6)]
        [DataRow("qwe123rr",3)]
        [DataRow("qwerrtyuioopas",6)]
        public void CountMaximumDifferentLetterTest(string value, int expected)
        {
            // arrange
            int result;
            Calculation calculation = new Calculation();
            
            //act
            result = calculation.CountMaximumDifferentLetter(value);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
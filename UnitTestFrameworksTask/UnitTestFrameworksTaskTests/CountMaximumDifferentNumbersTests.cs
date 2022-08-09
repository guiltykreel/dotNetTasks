using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestFrameworksTask.Tests
{
    [TestClass()]
    public class CountMaximumDifferentNumbersTests
    {
        [TestMethod()]
        [DataRow("12344", 4)]
        [DataRow("123441234566",7)]
        [DataRow("1234qwer11",4)]
        public void CountMaximumDifferentNumbersTest(string value, int expected)
        {
            // arrange
            int result;
            Calculation calculation = new Calculation();

            //act
            result = calculation.CountMaximumDifferentNumbers(value);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
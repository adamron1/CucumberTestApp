using System;
using Xunit;
using CucumberBankApp.Models;

namespace CucumberBankApp.UnitTests
{
    public class NumeralsToEnglish_SplitWholeNumbersAndDecimalsShould
    {
        [Theory]
        [InlineData("1")]
        [InlineData("1000.32")]
        [InlineData("-1000")]
        public void PassesStringsOfValidNumbers(string value)
        {
            Assert.True(NumeralsToEnglish.VerifyValidNumberString(value) );
        }

    }
}

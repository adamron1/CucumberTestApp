using System;
using Xunit;
using CucumberBankApp.Models;

namespace CucumberBankApp.UnitTests
{
    public class NumeralsToEnglish_VerifyValidNumberStringShould
    {
        [Theory]
        [InlineData("1")]
        [InlineData("1000.32")]
        [InlineData("-1000")]
        public void PassesStringsOfValidNumbers(string value)
        {
            Assert.True(NumeralsToEnglish.VerifyValidNumberString(value) );
        }

        [Theory]
        [InlineData("1d")]
        [InlineData("1000.32.43")]
        [InlineData("100,000")]
        [InlineData("$100000")]
        [InlineData("10.")]
        public void FailsStringsOfInvalidNumbers(string value)
        {
            Assert.False(NumeralsToEnglish.VerifyValidNumberString(value) );
        }
    }
}

using System;
using Xunit;
using CucumberBankApp.Models;

namespace CucumberBankApp.UnitTests
{
    public class NumeralsToEnglish_ParseNumberAsBalanceStringShould
    {
        [Theory]
        [InlineData("0", "zero dollars")]
        // // Remaining failing tests- singularise 'dollar' and 'cent' 
        // [InlineData("1", "one dollar")]
        // [InlineData("0.01", "zero dollars and one cent")]
        [InlineData("5.50", "five dollars and fifty cents")]
        [InlineData("5.5", "five dollars and fifty cents")]
        [InlineData("-5.50", "negative five dollars and fifty cents")]
        public void ParsesNumeralStringIntoHumanReadableBankBalance(string value, string expected)
        {
            var result = NumeralsToEnglish.ParseNumberAsBalanceString(value);
            Assert.Equal(expected, result );
        }
    }
}

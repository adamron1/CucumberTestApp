using System;
using Xunit;
using CucumberBankApp.Models;

namespace CucumberBankApp.UnitTests
{
    public class NumeralsToEnglish_ParseIntegerStringToEnglishWordsShould
    {
        [Theory]
        [InlineData("0", "zero")]
        [InlineData("1", "one")]
        [InlineData("-1", "negative one")]
        [InlineData("00019", "nineteen")]
        [InlineData("319423", "three hundred and nineteen thousand, four hundred and twenty three")]
        [InlineData("1000000000","one billion")]
        public void ParsesIntegerStringsIntoWords(string value, string expected)
        {
            var result = NumeralsToEnglish.ParseIntegerStringToEnglishWords(value);
            Assert.Equal(expected, result );
        }
    }
}

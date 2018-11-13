using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CucumberBankApp.Models
{
    /*
    The class for the logic required to turn numeral strings into 
    english words
    */
    public class NumeralsToEnglish
    {   
        private static string[] _toTwenty = {
            "", "one", "two", "three", "four",
            "five", "six", "seven", "eight", "nine",
            "ten", "eleven", "twelve", "thirteen", "fourteen",
            "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        };
        private static string[] _tens = {
            "", "", "twenty", "thirty", "fourty", 
            "fifty", "sixty", "seventy", "eighty", "ninety"
        };

        private static string[] _magnitudes = {
            "", "thousand", "million", "billion", "trillion", "quadrillion",
            "quintillion", "sextillion", "septillion", "octillion", "nonillion"
        };

        private static string _invalidInputMessage = "Invalid input. Input must be a valid number";

        public NumeralsToEnglish(){}

        public static string ParseNumberAsBalanceString(string numString)
        {
            if (!VerifyValidNumberString(numString))
            {
                return _invalidInputMessage;
            }
            if (numString.Contains('.') )
            {
                var wholeAndDecimal = numString.Split('.');
                var wholeNumString = ParseIntegerStringToEnglishWords(wholeAndDecimal[0]);
                var decimalString = wholeAndDecimal[1] + "00";
                decimalString = ParseIntegerStringToEnglishWords(decimalString.Substring(0,2));
                return wholeNumString + " dollars and " + decimalString + " cents";
            }
            return ParseIntegerStringToEnglishWords(numString) + " dollars";
        }

        public static string ParseIntegerStringToEnglishWords(string numString)
        {
            var str = "";
            var negative = "";
        
            if (Int64.Parse(numString) == 0)
            {
                return "zero";
            }
            if (IsNegative(numString))
            {
                // take away minus operator and write 'minus' at beginning of string
                negative = "negative ";
                numString = numString.Substring(1);
            }
            // number string now has length of multiple of 3 (for dividing into groups)
            numString = numString.PadLeft(numString.Length + 3-numString.Length%3,'0');

            for (int i = 0; i < numString.Length / 3; i++)
            {
                var groupString = ParseThreeDigitNumGroupToEnglish(numString.Substring(i*3,3), numString.Length / 3 - (i+1) );
                if ( !string.IsNullOrEmpty(groupString) )
                {
                    str += ", " + groupString;
                }
            }
            return negative + str.TrimStart(',').TrimStart(' ');
        }

        public static string ParseThreeDigitNumGroupToEnglish(string numString, int magGroup = 0)
        {
            var str = "";
            var num = Int32.Parse(numString);
            if (num == 0)
            {
                return str;
            }
            else if (num < 20 )
            {
                str = _toTwenty[num];
            }
            else if (num < 100 )
            {
                str = ParseTwoDigitNumGroupToEnglish(numString.Substring(1));
            }
            else if (num < 1000)
            {
                str += ParseHundredGroup(numString);
            }
            if (magGroup > 0)
            {
                str += " " +  _magnitudes[magGroup];
            }
            return str;
        }

        public static string ParseTwoDigitNumGroupToEnglish(string numString ) 
        {
            string str = "";
            var numAsInt = Int32.Parse(numString);
            if (numAsInt < 20)
            {
                return _toTwenty[numAsInt];
            }
            var tensIndex = (int)Char.GetNumericValue(numString[0]);
            var onesIndex = (int)Char.GetNumericValue(numString[1]);

            if ( !string.IsNullOrEmpty(_tens[tensIndex]) )
            {
                str = _tens[tensIndex] + " ";
            }

            if ( !string.IsNullOrEmpty(_toTwenty[onesIndex]) )
            {
                str += _toTwenty[onesIndex];
            }
            
            return str.Trim();
        }

        // Takes 3 digit numString only
        public static string ParseHundredGroup(string numString ) {
            var str = "";
            
            var hundredsIndex = (int)Char.GetNumericValue(numString[0]);
            if ( !string.IsNullOrEmpty(_toTwenty[hundredsIndex]) )
            {
                str = _toTwenty[hundredsIndex] + " hundred";
            }

            var lowerOrderNumbers = ParseTwoDigitNumGroupToEnglish(numString.Substring(1));
            if (! string.IsNullOrEmpty(lowerOrderNumbers) )
            {
                str += " and " + lowerOrderNumbers;
            }
            return str;
        }


        public static bool VerifyValidNumberString(string number)
        {
            var regex = new Regex(@"^-?\d+(?:\.?\d+)?$");
            return regex.IsMatch(number);
        }
        private static string[] SplitWholeNumbersAndDecimals(string number)
        {
            return number.Split('.');
        }

        private static bool IsZero(int number)
        {
            return number == 0;
        }

        private static bool IsLessThanTwenty(int number)
        {
            return number < 20;
        }

        private static bool IsNegative(string numString)
        {
            return numString[0] == '-';
        }


    }
}
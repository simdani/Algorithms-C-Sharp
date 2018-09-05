using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Leetcode.Problems1_99;
using Xunit;

namespace UnitTests.LeetcodeTests.Problems1_99
{
    public class StringToIntegerTest
    {
        [Fact]
        public void TestStringToInteger()
        {
            StringToInteger stringToInteger = new StringToInteger();
            Assert.Equal(42, stringToInteger.MyAtoi("42"));
            Assert.Equal(-42, stringToInteger.MyAtoi("   -42"));
            Assert.Equal(4193, stringToInteger.MyAtoi("4193 with words"));
            Assert.Equal(0, stringToInteger.MyAtoi("words and 987"));
            Assert.Equal(-2147483648, stringToInteger.MyAtoi("-91283472332"));
            //Assert.Equal(3.14159, stringToInteger.MyAtoi("3.14159"));
        }
    }
}

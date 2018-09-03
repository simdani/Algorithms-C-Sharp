using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Leetcode.Problems100_199;
using Xunit;

namespace UnitTests.LeetcodeTests.Problems100_199
{
    public class ValidPalindromeTest
    {
        [Fact]
        public void TestValidPalindrome()
        {
            ValidPalindrome palindrome = new ValidPalindrome();
            Assert.True(palindrome.IsPalindromeInPlace("A man, a plan, a canal: Panama"));
            Assert.True(palindrome.IsPalindrome("neen"));
            Assert.True(palindrome.IsPalindrome("kemek"));
            Assert.False(palindrome.IsPalindrome("race a car"));
        }
    }
}

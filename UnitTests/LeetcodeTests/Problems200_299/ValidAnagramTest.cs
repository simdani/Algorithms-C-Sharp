using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Leetcode.Problems200_299;
using Xunit;

namespace UnitTests.LeetcodeTests.Problems200_299
{
    public class ValidAnagramTest
    {
        [Fact]
        public void TestValidAnagram()
        {
            ValidAnagram validAnagram = new ValidAnagram();
            Assert.True(validAnagram.IsAnagram("anagram", "nagaram"));
            Assert.False(validAnagram.IsAnagram("rat", "cat"));
        }
    }
}

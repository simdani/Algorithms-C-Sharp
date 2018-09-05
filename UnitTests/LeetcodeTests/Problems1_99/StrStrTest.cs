using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Leetcode.Problems1_99;
using Xunit;

namespace UnitTests.LeetcodeTests.Problems1_99
{
    public class StrStrTest
    {
        [Fact]
        public void TestHaystack()
        {
            StrStr haystack = new StrStr();
            Assert.Equal(0, haystack.Haystack("test", ""));
            Assert.Equal(2, haystack.Haystack("hello", "ll"));
            Assert.Equal(-1, haystack.Haystack("aaaaa", "bba"));
        }
    }
}

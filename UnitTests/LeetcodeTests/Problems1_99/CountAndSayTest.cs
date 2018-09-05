using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Leetcode.Problems1_99;
using Xunit;

namespace UnitTests.LeetcodeTests.Problems1_99
{
    public class CountAndSayTest
    {
        [Fact]
        public void TestCountAndSay()
        {
            CountAndSay countSay = new CountAndSay();
            Assert.Equal("1", countSay.CountAndSayProblem(1));
            Assert.Equal("11", countSay.CountAndSayProblem(2));
            Assert.Equal("21", countSay.CountAndSayProblem(3));
            Assert.Equal("1211", countSay.CountAndSayProblem(4));
        }
    }
}

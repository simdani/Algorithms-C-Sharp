using Algorithms.Leetcode.Problems300_399;
using Xunit;

namespace UnitTests.LeetcodeTests.Problems300_399
{
    public class FirstUniqueCharacterInStringTest
    {
        [Fact]
        public void TestFirstUniqChar()
        {
            FirstUniqueCharacterInString uniqChar = new FirstUniqueCharacterInString();
            Assert.Equal(0, uniqChar.FirstUniqChar("leetcode"));
            Assert.Equal(2, uniqChar.FirstUniqChar("loveleetcode"));
        }
    }
}
